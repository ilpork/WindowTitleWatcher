using System;
using System.Reflection;
using System.Windows.Forms;

namespace WindowTitleWatcher
{
    public partial class AboutWindow : Form
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            var assemblyInfo = Assembly.GetExecutingAssembly().GetName();
            LabelAppNameAndVersion.Text = $"{assemblyInfo.Name} {assemblyInfo.Version.ToString(3)}";
            LabelCopyright.Text = $"Copyright (c) {DateTime.Now.Year} by ilpork";
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
