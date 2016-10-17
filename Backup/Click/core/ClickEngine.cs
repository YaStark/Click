using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.ComponentModel;

namespace Click.core{
    public class ClickEngine : IDisposable {

        #region События

        /// <summary>
        /// Событие при выходе 
        /// </summary>
        public event EventHandler Exit;

        private void invokeExitEvent () {
            var handler = Exit;
            if (handler != null) {
                handler (this, new EventArgs ());
            }
        }

        #endregion

        #region PInvoke

        [DllImport("User32.dll")]
        extern static void mouse_event(
            [In] Int32 dwFlags,
            [In] Int32 dx,
            [In] Int32 dy,
            [In] Int32 dwData,
            [In] IntPtr dwExtraInfo
        );

        #endregion

        #region Константы
        
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;

        private const int MOUSEEVENTF_LEFTUP = 0x0004;

        #endregion

        #region Свойства

        public Keys KeyStart { get; set; }

        public Keys KeyStop { get; set; }

        public Keys KeyExit { get; set; }

        public int Period { get; set; }
        
        #endregion

        #region Данные

        private KbHook _kbHook;

        private BackgroundWorker _clickWorker;
		 
        #endregion

        #region Инициализация

        public ClickEngine () {
            _kbHook = new KbHook ();
            _kbHook.KbPressed += onKbPressed;

            _clickWorker = new BackgroundWorker ();
            _clickWorker.WorkerSupportsCancellation = true;
            _clickWorker.DoWork += onClickWorker;
        }
        
        #endregion

        #region Методы

        public void Dispose() {
            pause ();
            _kbHook.Dispose ();
            _clickWorker.Dispose ();     
        }

        private void start () {
            if (!_clickWorker.IsBusy) {
                _clickWorker.RunWorkerAsync (Period);
            }
        }

        public void pause () {
            _clickWorker.CancelAsync ();
        }

        /// <summary>
        /// Выполняет одиночный клик
        /// </summary>
        private void click () {
            mouse_event (MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero);
            Thread.Sleep (0);
            mouse_event (MOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero);
        }

        #endregion

        #region Обработка событий

        private void onKbPressed (object sender, KbHookEventArgs e) {
            if (e.KeyPressed == KeyStop) {
                pause ();
            } else if (e.KeyPressed == KeyStart) {
                start ();
            } else if (e.KeyPressed == KeyExit) {
                pause ();
                invokeExitEvent ();
            }
        }

        private void onClickWorker (object sender, DoWorkEventArgs e) {
            var worker = (BackgroundWorker)sender;
            var speed = (int)e.Argument;
            if (speed < 1) {
                speed = 1;
            }
            int period = 1000 / speed;
            while (!worker.CancellationPending) {
                Thread.Sleep (period);
                click ();
            }
        }
        
        #endregion

    }
}
