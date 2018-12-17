namespace Mixture
    {
    partial class Login
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
            {
            if ( disposing && ( components != null ) )
                {
                components .Dispose ( );
                }
            base .Dispose ( disposing );
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
            {
                this.key_Software1 = new Key_Software.Key_Software();
                this.HelpProviderHG = new System.Windows.Forms.HelpProvider();
                this.SuspendLayout();
                // 
                // key_Software1
                // 
                this.HelpProviderHG.SetHelpKeyword(this.key_Software1, "Login.htm#Key_Software");
                this.HelpProviderHG.SetHelpNavigator(this.key_Software1, System.Windows.Forms.HelpNavigator.Topic);
                this.key_Software1.Location = new System.Drawing.Point(0, 0);
                this.key_Software1.Name = "key_Software1";
                this.HelpProviderHG.SetShowHelp(this.key_Software1, true);
                this.key_Software1.Size = new System.Drawing.Size(368, 248);
                this.key_Software1.TabIndex = 0;
                this.key_Software1.Load += new System.EventHandler(this.key_Software1_Load);
                // 
                // HelpProviderHG
                // 
                this.HelpProviderHG.HelpNamespace = "Mixture.chm";
                // 
                // Login
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(368, 247);
                this.Controls.Add(this.key_Software1);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.HelpProviderHG.SetHelpKeyword(this, "Login.htm");
                this.HelpProviderHG.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
                this.Name = "Login";
                this.HelpProviderHG.SetShowHelp(this, true);
                this.ShowIcon = false;
                this.ShowInTaskbar = false;
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Login";
                this.Load += new System.EventHandler(this.Login_Load);
                this.ResumeLayout(false);

            }

        #endregion

        private Key_Software.Key_Software key_Software1;
        private System.Windows.Forms.HelpProvider HelpProviderHG;
        }
    }