namespace Mixture
    {
    partial class Color_Ascendant
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
            System.ComponentModel.ComponentResourceManager resources = new System .ComponentModel .ComponentResourceManager ( typeof ( Color_Ascendant ) );
            this .showColor1 = new Mixture .ShowColor ( );
            this .SuspendLayout ( );
            // 
            // showColor1
            // 
            this .showColor1 .BackColor = System .Drawing .Color .White;
            this .showColor1 .Location = new System .Drawing .Point ( 8 , 8 );
            this .showColor1 .Name = "showColor1";
            this .showColor1 .Size = new System .Drawing .Size ( 276 , 283 );
            this .showColor1 .TabIndex = 0;
            // 
            // Color_Ascendant
            // 
            this .AutoScaleDimensions = new System .Drawing .SizeF ( 6F , 13F );
            this .AutoScaleMode = System .Windows .Forms .AutoScaleMode .Font;
            this .BackColor = System .Drawing .Color .White;
            this .ClientSize = new System .Drawing .Size ( 290 , 295 );
            this .Controls .Add ( this .showColor1 );
            this .FormBorderStyle = System .Windows .Forms .FormBorderStyle .FixedSingle;
            this .Icon = ( ( System .Drawing .Icon ) ( resources .GetObject ( "$this.Icon" ) ) );
            this .MaximizeBox = false;
            this .Name = "Color_Ascendant";
            this .ShowIcon = false;
            this .ShowInTaskbar = false;
            this .StartPosition = System .Windows .Forms .FormStartPosition .CenterScreen;
            this .Text = "طیف رنگ تصویر";
            this .ResumeLayout ( false );

            }

        #endregion

        private ShowColor showColor1;
        }
    }