namespace Mixture
    {
    partial class ShowMixtureInf
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
            this .groupBox1 = new System .Windows .Forms .GroupBox ( );
            this .txtcoutnmax = new System .Windows .Forms .TextBox ( );
            this .groupBox3 = new System .Windows .Forms .GroupBox ( );
            this .pb2 = new System .Windows .Forms .PictureBox ( );
            this .label3 = new System .Windows .Forms .Label ( );
            this .txtcount = new System .Windows .Forms .TextBox ( );
            this .label2 = new System .Windows .Forms .Label ( );
            this .groupBox2 = new System .Windows .Forms .GroupBox ( );
            this .state = new System .Windows .Forms .PictureBox ( );
            this .label4 = new System .Windows .Forms .Label ( );
            this .lblstate = new System .Windows .Forms .Label ( );
            this .label1 = new System .Windows .Forms .Label ( );
            this .pictureBox1 = new System .Windows .Forms .PictureBox ( );
            this .HelpProviderHG = new System .Windows .Forms .HelpProvider ( );
            this .groupBox1 .SuspendLayout ( );
            this .groupBox3 .SuspendLayout ( );
            ( ( System .ComponentModel .ISupportInitialize ) ( this .pb2 ) ) .BeginInit ( );
            this .groupBox2 .SuspendLayout ( );
            ( ( System .ComponentModel .ISupportInitialize ) ( this .state ) ) .BeginInit ( );
            ( ( System .ComponentModel .ISupportInitialize ) ( this .pictureBox1 ) ) .BeginInit ( );
            this .SuspendLayout ( );
            // 
            // groupBox1
            // 
            this .groupBox1 .Controls .Add ( this .txtcoutnmax );
            this .groupBox1 .Controls .Add ( this .groupBox3 );
            this .groupBox1 .Controls .Add ( this .label3 );
            this .groupBox1 .Controls .Add ( this .txtcount );
            this .groupBox1 .Controls .Add ( this .label2 );
            this .groupBox1 .Controls .Add ( this .groupBox2 );
            this .groupBox1 .Controls .Add ( this .label4 );
            this .groupBox1 .Location = new System .Drawing .Point ( 8 , 56 );
            this .groupBox1 .Name = "groupBox1";
            this .groupBox1 .Size = new System .Drawing .Size ( 248 , 160 );
            this .groupBox1 .TabIndex = 1;
            this .groupBox1 .TabStop = false;
            this .groupBox1 .Text = "اطلاعات";
            // 
            // txtcoutnmax
            // 
            this .txtcoutnmax .BackColor = System .Drawing .Color .White;
            this .txtcoutnmax .BorderStyle = System .Windows .Forms .BorderStyle .None;
            this .HelpProviderHG .SetHelpKeyword ( this .txtcoutnmax , "ShowMixtureInf.htm#txtcoutnmax" );
            this .HelpProviderHG .SetHelpNavigator ( this .txtcoutnmax , System .Windows .Forms .HelpNavigator .Topic );
            this .txtcoutnmax .Location = new System .Drawing .Point ( 72 , 118 );
            this .txtcoutnmax .Name = "txtcoutnmax";
            this .txtcoutnmax .ReadOnly = true;
            this .HelpProviderHG .SetShowHelp ( this .txtcoutnmax , true );
            this .txtcoutnmax .Size = new System .Drawing .Size ( 48 , 14 );
            this .txtcoutnmax .TabIndex = 51;
            // 
            // groupBox3
            // 
            this .groupBox3 .Controls .Add ( this .pb2 );
            this .groupBox3 .Location = new System .Drawing .Point ( 8 , 88 );
            this .groupBox3 .Name = "groupBox3";
            this .groupBox3 .Size = new System .Drawing .Size ( 60 , 68 );
            this .groupBox3 .TabIndex = 49;
            this .groupBox3 .TabStop = false;
            this .groupBox3 .Text = "حالت";
            // 
            // pb2
            // 
            this .pb2 .Cursor = System .Windows .Forms .Cursors .Hand;
            this .pb2 .Location = new System .Drawing .Point ( 8 , 14 );
            this .pb2 .Name = "pb2";
            this .pb2 .Size = new System .Drawing .Size ( 44 , 45 );
            this .pb2 .SizeMode = System .Windows .Forms .PictureBoxSizeMode .AutoSize;
            this .pb2 .TabIndex = 48;
            this .pb2 .TabStop = false;
            this .pb2 .Tag = "1";
            // 
            // label3
            // 
            this .label3 .AutoSize = true;
            this .label3 .Location = new System .Drawing .Point ( 120 , 117 );
            this .label3 .Name = "label3";
            this .label3 .Size = new System .Drawing .Size ( 119 , 13 );
            this .label3 .TabIndex = 3;
            this .label3 .Text = "بیشترین حالت در تصویر: ";
            // 
            // txtcount
            // 
            this .txtcount .BackColor = System .Drawing .Color .White;
            this .txtcount .BorderStyle = System .Windows .Forms .BorderStyle .None;
            this .HelpProviderHG .SetHelpKeyword ( this .txtcount , "ShowMixtureInf.htm#txtcount" );
            this .HelpProviderHG .SetHelpNavigator ( this .txtcount , System .Windows .Forms .HelpNavigator .Topic );
            this .txtcount .Location = new System .Drawing .Point ( 72 , 27 );
            this .txtcount .Name = "txtcount";
            this .txtcount .ReadOnly = true;
            this .HelpProviderHG .SetShowHelp ( this .txtcount , true );
            this .txtcount .Size = new System .Drawing .Size ( 48 , 14 );
            this .txtcount .TabIndex = 2;
            // 
            // label2
            // 
            this .label2 .AutoSize = true;
            this .label2 .Location = new System .Drawing .Point ( 120 , 27 );
            this .label2 .Name = "label2";
            this .label2 .Size = new System .Drawing .Size ( 121 , 13 );
            this .label2 .TabIndex = 1;
            this .label2 .Text = "تعداد حالت های موجود : ";
            // 
            // groupBox2
            // 
            this .groupBox2 .Controls .Add ( this .state );
            this .groupBox2 .Location = new System .Drawing .Point ( 8 , 8 );
            this .groupBox2 .Name = "groupBox2";
            this .groupBox2 .Size = new System .Drawing .Size ( 60 , 68 );
            this .groupBox2 .TabIndex = 0;
            this .groupBox2 .TabStop = false;
            this .groupBox2 .Text = "حالت";
            // 
            // state
            // 
            this .state .Cursor = System .Windows .Forms .Cursors .Hand;
            this .state .Location = new System .Drawing .Point ( 8 , 14 );
            this .state .Name = "state";
            this .state .Size = new System .Drawing .Size ( 44 , 45 );
            this .state .SizeMode = System .Windows .Forms .PictureBoxSizeMode .AutoSize;
            this .state .TabIndex = 48;
            this .state .TabStop = false;
            this .state .Tag = "1";
            // 
            // label4
            // 
            this .label4 .AutoSize = true;
            this .label4 .Location = new System .Drawing .Point ( 8 , 70 );
            this .label4 .Name = "label4";
            this .label4 .Size = new System .Drawing .Size ( 229 , 13 );
            this .label4 .TabIndex = 50;
            this .label4 .Text = "_____________________________________";
            // 
            // lblstate
            // 
            this .lblstate .AutoSize = true;
            this .lblstate .Font = new System .Drawing .Font ( "Tahoma" , 8.25F , System .Drawing .FontStyle .Bold , System .Drawing .GraphicsUnit .Point , ( ( byte ) ( 178 ) ) );
            this .lblstate .ForeColor = System .Drawing .Color .White;
            this .lblstate .Image = global::Mixture .Properties .Resources .panel;
            this .lblstate .Location = new System .Drawing .Point ( 48 , 22 );
            this .lblstate .Name = "lblstate";
            this .lblstate .Size = new System .Drawing .Size ( 0 , 13 );
            this .lblstate .TabIndex = 2;
            // 
            // label1
            // 
            this .label1 .AutoSize = true;
            this .label1 .Font = new System .Drawing .Font ( "Tahoma" , 8.25F , System .Drawing .FontStyle .Bold , System .Drawing .GraphicsUnit .Point , ( ( byte ) ( 178 ) ) );
            this .label1 .ForeColor = System .Drawing .Color .White;
            this .label1 .Image = global::Mixture .Properties .Resources .panel;
            this .label1 .Location = new System .Drawing .Point ( 88 , 22 );
            this .label1 .Name = "label1";
            this .label1 .Size = new System .Drawing .Size ( 137 , 13 );
            this .label1 .TabIndex = 0;
            this .label1 .Text = "اطلاعات مربوط به حالت : ";
            // 
            // pictureBox1
            // 
            this .pictureBox1 .Image = global::Mixture .Properties .Resources .panel;
            this .pictureBox1 .Location = new System .Drawing .Point ( -24 , 8 );
            this .pictureBox1 .Name = "pictureBox1";
            this .pictureBox1 .Size = new System .Drawing .Size ( 304 , 45 );
            this .pictureBox1 .SizeMode = System .Windows .Forms .PictureBoxSizeMode .StretchImage;
            this .pictureBox1 .TabIndex = 0;
            this .pictureBox1 .TabStop = false;
            // 
            // HelpProviderHG
            // 
            this .HelpProviderHG .HelpNamespace = "Mixture.chm";
            // 
            // ShowMixtureInf
            // 
            this .AutoScaleDimensions = new System .Drawing .SizeF ( 6F , 13F );
            this .AutoScaleMode = System .Windows .Forms .AutoScaleMode .Font;
            this .BackColor = System .Drawing .Color .White;
            this .ClientSize = new System .Drawing .Size ( 263 , 220 );
            this .Controls .Add ( this .lblstate );
            this .Controls .Add ( this .label1 );
            this .Controls .Add ( this .groupBox1 );
            this .Controls .Add ( this .pictureBox1 );
            this .Font = new System .Drawing .Font ( "Tahoma" , 8.25F , System .Drawing .FontStyle .Regular , System .Drawing .GraphicsUnit .Point , ( ( byte ) ( 178 ) ) );
            this .FormBorderStyle = System .Windows .Forms .FormBorderStyle .FixedToolWindow;
            this .HelpProviderHG .SetHelpKeyword ( this , "ShowMixtureInf.htm" );
            this .HelpProviderHG .SetHelpNavigator ( this , System .Windows .Forms .HelpNavigator .Topic );
            this .MinimumSize = new System .Drawing .Size ( 269 , 235 );
            this .Name = "ShowMixtureInf";
            this .RightToLeft = System .Windows .Forms .RightToLeft .Yes;
            this .HelpProviderHG .SetShowHelp ( this , true );
            this .ShowIcon = false;
            this .ShowInTaskbar = false;
            this .StartPosition = System .Windows .Forms .FormStartPosition .CenterScreen;
            this .Text = "    *********اطلاعات مربوط به حالت ها*********";
            this .groupBox1 .ResumeLayout ( false );
            this .groupBox1 .PerformLayout ( );
            this .groupBox3 .ResumeLayout ( false );
            this .groupBox3 .PerformLayout ( );
            ( ( System .ComponentModel .ISupportInitialize ) ( this .pb2 ) ) .EndInit ( );
            this .groupBox2 .ResumeLayout ( false );
            this .groupBox2 .PerformLayout ( );
            ( ( System .ComponentModel .ISupportInitialize ) ( this .state ) ) .EndInit ( );
            ( ( System .ComponentModel .ISupportInitialize ) ( this .pictureBox1 ) ) .EndInit ( );
            this .ResumeLayout ( false );
            this .PerformLayout ( );

            }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblstate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox state;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pb2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtcoutnmax;
        private System.Windows.Forms.HelpProvider HelpProviderHG;
        }
    }