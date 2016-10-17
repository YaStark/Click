using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Click.core {

    public enum KeyboardState {
        KeyDown=0x0100,
        KeyUp=0x0101,
        SysKeyDown=0x0104,
        SysKeyUp=0x0105
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct KBDLLHOOKSTRUCT {
        public int vkCode;
        public int scanCode;
        public int flags;
        public int time;
        public IntPtr dwExtraInfo;
    }
                
    public class KbHookEventArgs : EventArgs {

        public Keys KeyPressed { get; set; } 
        
        public bool Handled { get; set; }

        public KbHookEventArgs (Keys key) {
            KeyPressed = key;
            Handled = false;
        }
    }

	/// <summary>
	/// Использование:
    /// ...
	/// _kbHook = new KbHook ();
    ///  _kbHook.KbPressed += onKbPressed;
	/// ...
	/// private void onKbPressed (object sender, KbHookEventArgs e) {
    ///     if (e.KeyPressed == KeyStop) {
    ///     
	///		} else if (e.KeyPressed == KeyStart) {
    ///     
	///		} else if (e.KeyPressed == KeyExit) {
    ///         
    ///     }
    /// }
	/// </summary>
    public class KbHook : IDisposable {

        #region PInvoke

        [DllImport ("User32.dll", SetLastError=true)]
        static extern Int16 GetKeyState (
          [In] Int32 nVirtKey
        );

        [DllImport ("kernel32.dll")]
        static extern IntPtr LoadLibrary (
            [In] string lpFileName
        );

        [DllImport ("User32.dll", SetLastError=true)]
        static extern IntPtr SetWindowsHookEx (
            [In] int idHook,
            [In] HookProc lpfn,
            [In] IntPtr hMod,
            [In] int dwThreadId
        );

        [DllImport ("User32.dll", SetLastError=true)]
        public static extern bool UnhookWindowsHookEx (
            [In] IntPtr hHook
        );

        [DllImport ("USER32", SetLastError=true)]
        static extern IntPtr CallNextHookEx (
            [In] IntPtr hHook,
            [In] int code,
            [In] IntPtr wParam,
            [In] IntPtr lParam
        );

        #endregion

        #region Константы

        public const int WH_KEYBOARD_LL = 13;

        #endregion

        #region События

        /// <summary>
        /// При нажатии на клавишу
        /// </summary>
        public event EventHandler<KbHookEventArgs> KbPressed;

        private bool invokeKbPressedEvent (Keys keys) {
            var handler = KbPressed;
            var args = new KbHookEventArgs (keys);
            if (handler != null) {
                handler (this, args);
            }
            return args.Handled;
        }

        #endregion

        #region Данные

        delegate IntPtr HookProc (int nCode, IntPtr wParam, IntPtr lParam);

        private readonly IntPtr _windowsHook;

        private HookProc _callback;
        
        #endregion

        #region Инициализация

        public KbHook () {
            var hInstance = LoadLibrary ("User32");
            _callback = LowLevelKbProc;
            _windowsHook = SetWindowsHookEx (
                WH_KEYBOARD_LL, _callback, hInstance, 0);
        }

        #endregion

        #region Методы

        /// <summary>
        /// Переводит vkCode в System.Keys, добавляя модификаторы при необходимости
        /// </summary>
        private Keys translate (KBDLLHOOKSTRUCT kbHookStruct) {
            var key = (Keys)kbHookStruct.vkCode;
            var keys = new Dictionary<Keys, Keys> () {
                { Keys.ShiftKey, Keys.Shift },
                { Keys.Menu, Keys.Alt },
                { Keys.ControlKey, Keys.Control }
            };
            foreach(var mKey in keys) {
                checkModifierKey (ref key, mKey.Key, mKey.Value);
            }
            return key;
        }

        private void checkModifierKey (ref Keys mainKey, Keys checkKey, Keys modifierKey) {
            if ((0x8000 & GetKeyState ((int)checkKey)) != 0) {
                // ШТААА??? Чтобы работало, надо двигать код модификатора 
                //  на 8 бит вправо, проверено на калькуляторе
                mainKey |= (Keys)(((int)modifierKey) >> 8);
            }
        }

        public void Dispose () {
            UnhookWindowsHookEx (_windowsHook);
        }

        public IntPtr LowLevelKbProc (int nCode, IntPtr wParam, IntPtr lParam) {
            bool handled = false;                
            var wparamTyped = wParam.ToInt32 ();
            if (Enum.IsDefined (typeof (KeyboardState), wparamTyped)) {
                var obj = Marshal.PtrToStructure (
                            lParam, typeof (KBDLLHOOKSTRUCT));
                if (obj != null) {
                    handled = invokeKbPressedEvent (translate((KBDLLHOOKSTRUCT)obj));
                }
            }
            return handled ? (IntPtr)1 
                : CallNextHookEx (IntPtr.Zero, nCode, wParam, lParam);
        }

        #endregion
    }
}
