using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Click.core;

namespace Click {
    [ToolboxItem(true)]
    public partial class ParamCtrl : UserControl {

        #region Свойства

        /// <summary>
        /// Выставленная скорость
        /// </summary>
        [Browsable(false)]
        public int CurrentSpeed {
            get { return (int)editSpeed.Value; }
            set { editSpeed.Value = value; }
        }

        /// <summary>
        /// Клавиша запуска кликера
        /// </summary>
        [Browsable (false)]
        public Keys KeyBegin {
            get { return _hotkeyBegin.getHotkey (); }
            set { _hotkeyBegin.setHotkey (value); }
        }

        /// <summary>
        /// Клавиша остановки кликера
        /// </summary>
        [Browsable (false)]
        public Keys KeyEnd {
            get { return _hotkeyEnd.getHotkey (); }
            set { _hotkeyEnd.setHotkey (value); }
        }

        /// <summary>
        /// Клавиша выхода из программы
        /// </summary>
        [Browsable (false)]
        public Keys KeyExit {
            get { return _hotkeyExit.getHotkey (); }
            set { _hotkeyExit.setHotkey (value); }
        }

        #endregion

        #region Данные

        private HotkeyCtrl _hotkeyBegin;

        private HotkeyCtrl _hotkeyEnd;

        private HotkeyCtrl _hotkeyExit;
        
        #endregion

        #region Инициализация

        public ParamCtrl () {
            InitializeComponent ();
            initHotkeyCtrl (out _hotkeyBegin, panelBegin);
            initHotkeyCtrl (out _hotkeyEnd, panelEnd);
            initHotkeyCtrl (out _hotkeyExit, panelExit);
        }

        #endregion

        #region Методы

        /// <summary>
        /// Инициализирует контрол с хоткеем, выставляя его параметры 
        /// как параметры переданного контрола
        /// </summary>
        private void initHotkeyCtrl (out HotkeyCtrl hotkeyCtrl, Control container) {
            hotkeyCtrl = new HotkeyCtrl ();
            hotkeyCtrl.init (Handle, container.Location, container.Size);
            container.Visible = false;
        }
        
        #endregion

    }
}
