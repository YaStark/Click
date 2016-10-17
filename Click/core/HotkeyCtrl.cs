using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Click.core {

    public struct INITCOMMONCONTROLSEX {
        public Int32 Size;
        public Int32 Icc;
    };
    
    public class HotkeyCtrl {

        #region Константы

        const Int32 HKM_SETHOTKEY = 0x401;

        const Int32 HKM_GETHOTKEY = 0x402;

        const Int32 WS_CHILD = 0x40000000;

        const Int32 WS_VISIBLE = 0x10000000;

        const Int32 ICC_HOTKEY_CLASS = 0x00000040;

        const string HOTKEY_CLASS = "msctls_hotkey32";

        const Int32 GWL_HINSTANCE = -6;

        #endregion

        #region PInvoke

        [DllImport("User32.dll")]
        extern static Int32 SendMessage(
            [In] IntPtr hwnd,
            [In] Int32 msg,
            [In] Int32 wParam,
            [In] Int32 lParam
        );

        [DllImport ("Comctl32.dll")]
        extern static bool InitCommonControlsEx (
            [Out] out INITCOMMONCONTROLSEX lpInitCtrls
        );

        [DllImport ("User32.dll")]
        extern static IntPtr CreateWindowEx (
            [In] Int32 exStyle,
            [In] string className,
            [In] string windowName,
            [In] Int32 style,
            [In] Int32 x,
            [In] Int32 y,
            [In] Int32 width,
            [In] Int32 height,
            [In] IntPtr hwndParent,
            [In] IntPtr hMenu,
            [In] IntPtr hInstance,
            [In] IntPtr lpParam
        );

        [DllImport ("User32.dll")]
        extern static IntPtr GetWindowLong(
          [In] IntPtr hWnd,
          [In] Int32  Index
        );
    
        #endregion

        #region Данные

        private IntPtr _hwnd;

        private IntPtr _hInstance;

        private IntPtr _hwndParent;
        
        #endregion

        #region Методы

        public void init (IntPtr hwnd, Point location, Size size) {
            _hwndParent = hwnd;
            INITCOMMONCONTROLSEX icex;
            icex.Size = Marshal.SizeOf (typeof (INITCOMMONCONTROLSEX));
            icex.Icc = ICC_HOTKEY_CLASS;
            InitCommonControlsEx (out icex);
            _hInstance = GetWindowLong (hwnd, GWL_HINSTANCE);
            _hwnd = CreateWindowEx (0, HOTKEY_CLASS, null,
                                     WS_CHILD | WS_VISIBLE,
                                     location.X, location.Y,
                                     size.Width, size.Height,
                                     _hwndParent, IntPtr.Zero, _hInstance, IntPtr.Zero);
        }

        /// <summary>
        /// Устанавливает значение хоткея
        /// </summary>
        public void setHotkey (Keys hotkeyValue) {
            SendMessage (_hwnd, HKM_SETHOTKEY, (int)hotkeyValue, 0);
        }

        /// <summary>
        /// Возвращает текущий хоткей
        /// </summary>
        public Keys getHotkey () {
            var value = SendMessage (_hwnd, HKM_GETHOTKEY, 0, 0);
            return (Keys)value;
        }

        #endregion

    }
}
