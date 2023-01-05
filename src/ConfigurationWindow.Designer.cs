namespace WindowTitleWatcher
{
    partial class ConfigurationWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationWindow));
            this.LabelText = new System.Windows.Forms.Label();
            this.TxtToWatch = new System.Windows.Forms.TextBox();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelText
            // 
            this.LabelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LabelText.Location = new System.Drawing.Point(8, 9);
            this.LabelText.Margin = new System.Windows.Forms.Padding(0);
            this.LabelText.Name = "LabelText";
            this.LabelText.Size = new System.Drawing.Size(108, 15);
            this.LabelText.TabIndex = 0;
            this.LabelText.Text = "Text to watch for:";
            // 
            // TxtToWatch
            // 
            this.TxtToWatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.TxtToWatch.Location = new System.Drawing.Point(8, 28);
            this.TxtToWatch.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.TxtToWatch.Name = "TxtToWatch";
            this.TxtToWatch.Size = new System.Drawing.Size(241, 20);
            this.TxtToWatch.TabIndex = 1;
            // 
            // ButtonClose
            // 
            this.ButtonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ButtonClose.Location = new System.Drawing.Point(174, 58);
            this.ButtonClose.Margin = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(75, 23);
            this.ButtonClose.TabIndex = 2;
            this.ButtonClose.Text = "Close";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // ConfigurationWindow
            // 
            this.AcceptButton = this.ButtonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(257, 90);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.TxtToWatch);
            this.Controls.Add(this.LabelText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationWindow";
            this.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Configure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelText;
        private System.Windows.Forms.TextBox TxtToWatch;
        private System.Windows.Forms.Button ButtonClose;
    }
}