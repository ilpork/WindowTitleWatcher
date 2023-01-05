using System;
using System.Windows.Forms;

namespace WindowTitleWatcher
{
    public partial class ConfigurationWindow : Form
    {
        public ConfigurationWindow()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string WatchText
        {
            get => TxtToWatch.Text;
            set => TxtToWatch.Text = value;
        }
    }
}
