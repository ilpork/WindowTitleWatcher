// Original code by Tommy Carlier
// https://www.tcx.be/blog/2006/list-open-windows/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowTitleWatcher
{
    public static class WindowHelper
    {
        private delegate bool EnumWindowsProc(System.IntPtr hWnd, int lParam);

        [DllImport("USER32.DLL")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowText(System.IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowTextLength(System.IntPtr hWnd);

        [DllImport("USER32.DLL")]
        private static extern bool IsWindowVisible(System.IntPtr hWnd);

        [DllImport("USER32.DLL")]
        private static extern IntPtr GetShellWindow();

        /// <summary>
        /// Open windows and their handles
        /// </summary>
        /// <returns>A dictionary that contains the handle and title of all the open windows</returns>
        public static IDictionary<IntPtr, string> GetOpenWindows()
        {
            var shellWindow = GetShellWindow();
            var windows = new Dictionary<IntPtr, string>();

            EnumWindows(delegate (IntPtr hWnd, int lParam)
            {
                if (hWnd == shellWindow) return true;
                if (!IsWindowVisible(hWnd)) return true;

                int length = GetWindowTextLength(hWnd);
                if (length == 0) return true;

                var builder = new StringBuilder(length);
                GetWindowText(hWnd, builder, length + 1);

                windows[hWnd] = builder.ToString();
                return true;

            }, 0);

            return windows;
        }
    }
}
