using System;
using System.Windows.Forms;

namespace WindowTitleWatcher
{
    internal static class Program
    {   
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var initialText = args.Length == 1 ? args[0] : string.Empty;
            Application.Run(new TrayApplicationContext(initialText));
        }
    }
}
