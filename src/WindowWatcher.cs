using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace WindowTitleWatcher
{
    internal class WindowWatcher
    {
        public event EventHandler TextFound;
        private System.Windows.Forms.Timer _timer;

        [DllImport("user32.dll")]
        private static extern int FlashWindow(IntPtr Hwnd, bool Revert);        

        public WindowWatcher()
        {            
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;
        }

        public string WatchText { get; set; }

        public bool IsRunning => _timer.Enabled;

        public void Start()
        {
            if (!string.IsNullOrWhiteSpace(WatchText) && !_timer.Enabled)
            {   
                _timer.Start();                
            }
        }

        public void Stop()
        {   
            if (_timer.Enabled)
            {
                _timer.Stop();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var foundWindowHandle = IntPtr.Zero;
            var openWindowList = WindowHelper.GetOpenWindows();
            foundWindowHandle = openWindowList.FirstOrDefault(kvp =>
                kvp.Value.IndexOf(WatchText, StringComparison.OrdinalIgnoreCase) != -1).Key;

            if (foundWindowHandle != IntPtr.Zero)
            {
                FlashWindow(foundWindowHandle, false);
                _timer.Stop();

                TextFound?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
