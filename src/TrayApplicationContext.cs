using System;
using System.Reflection;
using System.Windows.Forms;

namespace WindowTitleWatcher
{
    internal class TrayApplicationContext : ApplicationContext
    {
        readonly ConfigurationWindow _configurationWindow;
        readonly WindowWatcher _windowWatcher;
        readonly string _appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;        
        NotifyIcon _notifyIcon;
        MenuItem _configMenuItem;
        MenuItem _startMenuItem;
        MenuItem _stopMenuItem;
        MenuItem _exitMenuItem;
        MenuItem _separatorMenuItem;

        public TrayApplicationContext(string initialText)
        {
            _configurationWindow = new ConfigurationWindow() { WatchText = initialText };
            _windowWatcher = new WindowWatcher() { WatchText = initialText };
            _windowWatcher.TextFound += WindowWatcher_TextFound;

            _configMenuItem = new MenuItem("&Configure", new EventHandler(ShowConfigurationWindow));            
            _startMenuItem = new MenuItem("&Start", new EventHandler(Start));
            _stopMenuItem = new MenuItem("S&top", new EventHandler(Stop));            
            _exitMenuItem = new MenuItem("&Exit", new EventHandler(Exit));
            _separatorMenuItem = new MenuItem("-");

            if (string.IsNullOrEmpty(initialText))
            { 
                ShowConfigurationWindow(null, null);
            }

            if (!string.IsNullOrEmpty(_windowWatcher.WatchText))
            {
                _windowWatcher.Start();
            }

            UpdateMenuItems();
        }

        void Exit(object sender, EventArgs e)
        {            
            _notifyIcon.Click -= NotifyIcon_Click;
            _notifyIcon.DoubleClick -= NotifyIcon_Click;
            _notifyIcon.Visible = false;
            _windowWatcher.TextFound -= WindowWatcher_TextFound;
            Application.Exit();
        }


        void NotifyIcon_Click(object sender, EventArgs e)
        {
            var mi = typeof(NotifyIcon).GetMethod("ShowContextMenu",
                        BindingFlags.Instance | BindingFlags.NonPublic);
            mi.Invoke(_notifyIcon, null);
        }

        void ShowConfigurationWindow(object sender, EventArgs e)
        {   
            if (_configurationWindow.Visible)
            {
                _configurationWindow.Activate();
            }
            else
            {
                _configurationWindow.ShowDialog();
                _windowWatcher.WatchText = _configurationWindow.WatchText;
                UpdateMenuItems();
            }
        }

        void Start(object sender, EventArgs e)
        {
            _windowWatcher.Start();       
            UpdateMenuItems();
        }

        void Stop(object sender, EventArgs e)
        {            
            _windowWatcher.Stop();
            UpdateMenuItems();
        }

        void UpdateMenuItems()
        {
            _startMenuItem.Text = string.IsNullOrEmpty(_windowWatcher.WatchText) ? 
                "&Start (no text configured)" : $"&Start (\"{_windowWatcher.WatchText}\")";             

            if (_notifyIcon == null)
            {
                _notifyIcon = new NotifyIcon();
                _notifyIcon.Icon = Properties.Resources.app;
                _notifyIcon.DoubleClick += NotifyIcon_Click;
                _notifyIcon.Click += NotifyIcon_Click;
                _notifyIcon.Visible = true;                
            }

            _notifyIcon.ContextMenu = new ContextMenu(new MenuItem[]
                    { _configMenuItem, _startMenuItem, _stopMenuItem, _separatorMenuItem, _exitMenuItem });
            
            if (_windowWatcher.IsRunning)
            {
                _notifyIcon.Text = $"{_appName}\nWatching for (\"{_windowWatcher.WatchText}\")";
                _startMenuItem.Enabled = false;
                _stopMenuItem.Enabled = true;
            }
            else
            {
                _notifyIcon.Text = $"{_appName}\nStopped";
                _startMenuItem.Enabled = !string.IsNullOrEmpty(_windowWatcher.WatchText);
                _stopMenuItem.Enabled = false;
            }    
        }        

        void WindowWatcher_TextFound(object sender, EventArgs e)
        {
            UpdateMenuItems();
        }
    }
}
