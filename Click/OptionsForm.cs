using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System;
using System.Threading;
using System.Collections.Generic;
using Click.Properties;
using Click.core;
using Microsoft.Win32;

namespace Click {
    public partial class OptionsForm : Form {

        #region Данные

        private ClickEngine _clickEngine;

        private List<int> _lastSpeedList = new List<int> ();

        #endregion

        #region Инициализация

        public OptionsForm () {
            InitializeComponent ();
            _clickEngine = new ClickEngine ();
            _clickEngine.Exit += onExit;
        }

        private void onShown (object sender, EventArgs e) {
            Visible = false;
            Opacity = 0;
            resetParams ();
        }

        #endregion

        #region Методы

        /// <summary>
        /// Переключает видимость формы с анимацией
        /// </summary>
        private void show () {
            var scrBounds = Screen.GetWorkingArea (this);
            var location = new Point (scrBounds.Right, scrBounds.Bottom);
            location.X -= Width;
            location.Y -= Height;
            Location = location;
            var visible = !Visible;
            Visible = true;
            Enabled = false;
            if(visible) {
                resetParams ();
            }
            if (!shownWorker.IsBusy) {
                shownWorker.RunWorkerAsync (visible);
            }
        }

        /// <summary>
        /// Кросспоточно устанавливает прозрачность формы
        /// </summary>
        private void setOpacity (double opacity) {
            var act = new Action<int> (n => {
                Opacity = opacity;
                Update ();
            });
            if (InvokeRequired) {
                Invoke (act, 0);
            } else {
                act (0);
            }
        }

        /// <summary>
        /// Выход из приложения
        /// </summary>
        private void exit () {
            Close ();
        }

        /// <summary>
        /// Сбрасывает параметры к изначальным значениям
        /// </summary>
        private void resetParams () {
            string msg = null;
            var param = RegistryModule.tryRead (ref msg);
            if (param == null) {
                MessageBox.Show (msg, "Ошибка загрузки параметров");
            } else {
                _lastSpeedList = param.PeriodList;
                _clickEngine.KeyExit = paramCtrl.KeyExit = param.KeyExit;
                _clickEngine.KeyStart = paramCtrl.KeyBegin = param.KeyStart;
                _clickEngine.KeyStop = paramCtrl.KeyEnd = param.KeyStop;
                _clickEngine.Period = paramCtrl.CurrentSpeed = param.Period;                
            }

        }

        /// <summary>
        /// Сохраняет параметры
        /// </summary>
        private void saveParams () {
            if (_lastSpeedList.Count > 0) {
                if (!_lastSpeedList.Contains(paramCtrl.CurrentSpeed)) {
                    _lastSpeedList.Insert (0, paramCtrl.CurrentSpeed);
                    while (_lastSpeedList.Count > 3) {
                        _lastSpeedList.RemoveAt (5);
                    }
                }
            } else {
                _lastSpeedList.Add (paramCtrl.CurrentSpeed);
            }
            updateCtxMenu ();
            _clickEngine.KeyExit = paramCtrl.KeyExit;
            _clickEngine.KeyStart = paramCtrl.KeyBegin;
            _clickEngine.KeyStop = paramCtrl.KeyEnd;
            _clickEngine.Period = paramCtrl.CurrentSpeed;

            string msg = null;
            if (!RegistryModule.tryWrite (ref msg, new ClickParam {
                KeyExit = paramCtrl.KeyExit,
                KeyStart = paramCtrl.KeyBegin,
                KeyStop = paramCtrl.KeyEnd,
                Period = paramCtrl.CurrentSpeed,
                PeriodList = _lastSpeedList
            })) {
                MessageBox.Show (msg, "Ошибка сохранения данных", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обновляет элементы контекстного меню
        /// </summary>
        private void updateCtxMenu () {
            var speedItems = new List<ToolStripItem>();
            foreach (ToolStripItem item in menuNotify.Items) {
                if (item.Tag != null && (bool)item.Tag) {
                    speedItems.Add (item);
                }
            }
            for (int i = 0; i<speedItems.Count; i++) {
                menuNotify.Items.Remove (speedItems[i]);
            }
            var newItems = new List<ToolStripItem>();
            foreach (var num in _lastSpeedList) {
                newItems.Add (createToolStripItem (num));
            }
            var first = 2;
            for(int i=0; i< newItems.Count; i++) {
                menuNotify.Items.Insert (i + first, newItems[i]);
            }            
        }

        /// <summary>
        /// Создает пункт контекстного меню с переданной скоростью
        /// </summary>
        private ToolStripItem createToolStripItem (int value) {
            var toolStripItem = new ToolStripMenuItem();
            toolStripItem.Text = String.Format ("{0} в секунду", value);
            toolStripItem.Click += (sender, args) => updateSpeed (value);
            toolStripItem.Checked = paramCtrl.CurrentSpeed == value;
            toolStripItem.Tag = true;
            return toolStripItem;
        }

        /// <summary>
        /// Изменяет значение скорости на переданное
        /// </summary>
        private void updateSpeed (int value) {
            _clickEngine.pause ();
            _clickEngine.Period = value;
            paramCtrl.CurrentSpeed = value;
        }

        #endregion

        #region Обработка событий

        /// <summary>
        /// При клике на иконку в панели задач
        /// </summary>
        private void onMouseClick (object sender, MouseEventArgs e) {
            switch (e.Button) {
                case MouseButtons.Left:
                    show ();
                    break;
            }
        }

        private void onShownWorker (object sender, DoWorkEventArgs e) {
            var visible = (bool)e.Argument;
            var targetOpacity = 1.0;
            var step = 0.1;
            if (visible) {
                for (double opacity = 0; opacity < targetOpacity; opacity += step) {
                    setOpacity (opacity);
                    Thread.Sleep (1);
                }
                setOpacity (targetOpacity);
            } else {
                for (double opacity = targetOpacity; opacity >= 0; opacity -= step) {
                    setOpacity (opacity);
                    Thread.Sleep (1);
                }
                setOpacity (0);
            }
            e.Result = visible;
        }

        private void onShownWorkerCompleted (object sender, RunWorkerCompletedEventArgs e) {
            Enabled = true;
            Visible = (bool)e.Result;
        }

        private void onCancel (object sender, EventArgs e) {
            resetParams ();
            show ();
        }

        private void onApply (object sender, EventArgs e) {
            saveParams ();
            show ();
        }

        private void onExit (object sender, EventArgs e) {
            exit ();
        }

        private void onMenuOptions (object sender, EventArgs e) {
            if (Enabled && !Visible) {
                show ();
            }
        }

        protected override void OnClosed (EventArgs e) {
            _clickEngine.Dispose ();
            if (!IsDisposed && !Disposing) {
                Dispose ();
            }
            base.OnClosed (e);
        }

        private void onCtxOpening (object sender, CancelEventArgs e) {
            updateCtxMenu ();
        }

        #endregion

    }
}
