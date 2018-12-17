namespace Mixture
    {
    partial class Show_Color_Table
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
            System.ComponentModel.ComponentResourceManager resources = new System .ComponentModel .ComponentResourceManager ( typeof ( Show_Color_Table ) );
            this .showColor = new Mixture .ShowColor ( );
            this .SuspendLayout ( );
            // 
            // showColor
            // 
            this .showColor .BackColor = System .Drawing .Color .White;
            this .showColor .Location = new System .Drawing .Point ( 8 , 3 );
            this .showColor .Name = "showColor";
            this .showColor .Size = new System .Drawing .Size ( 276 , 283 );
            this .showColor .TabIndex = 0;
            // 
            // Show_Color_Table
            // 
            this .AutoScaleDimensions = new System .Drawing .SizeF ( 6F , 13F );
            this .AutoScaleMode = System .Windows .Forms .AutoScaleMode .Font;
            this .BackColor = System .Drawing .Color .White;
            this .ClientSize = new System .Drawing .Size ( 287 , 287 );
            this .Controls .Add ( this .showColor );
            this .FormBorderStyle = System .Windows .Forms .FormBorderStyle .FixedSingle;
            this .Icon = ( ( System .Drawing .Icon ) ( resources .GetObject ( "$this.Icon" ) ) );
            this .MaximizeBox = false;
            this .MaximumSize = new System .Drawing .Size ( 293 , 312 );
            this .MinimumSize = new System .Drawing .Size ( 293 , 312 );
            this .Name = "Show_Color_Table";
            this .ShowIcon = false;
            this .ShowInTaskbar = false;
            this .StartPosition = System .Windows .Forms .FormStartPosition .CenterScreen;
            this .Text = "جدول رنگ تصویر";
            this .TopMost = true;
            this .ResumeLayout ( false );

            }

        #endregion

        private ShowColor showColor;
        }
    }