namespace Mixture
    {
    partial class ShowColorNumber
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
            System.ComponentModel.ComponentResourceManager resources = new System .ComponentModel .ComponentResourceManager ( typeof ( ShowColorNumber ) );
            this .dataGridView1 = new System .Windows .Forms .DataGridView ( );
            this .HelpProviderHG = new System .Windows .Forms .HelpProvider ( );
            ( ( System .ComponentModel .ISupportInitialize ) ( this .dataGridView1 ) ) .BeginInit ( );
            this .SuspendLayout ( );
            // 
            // dataGridView1
            // 
            this .dataGridView1 .AllowUserToAddRows = false;
            this .dataGridView1 .AllowUserToDeleteRows = false;
            this .dataGridView1 .AllowUserToOrderColumns = true;
            this .dataGridView1 .AllowUserToResizeColumns = false;
            this .dataGridView1 .AllowUserToResizeRows = false;
            this .dataGridView1 .AutoSizeRowsMode = System .Windows .Forms .DataGridViewAutoSizeRowsMode .DisplayedCellsExceptHeaders;
            this .dataGridView1 .ColumnHeadersHeightSizeMode = System .Windows .Forms .DataGridViewColumnHeadersHeightSizeMode .AutoSize;
            this .HelpProviderHG .SetHelpKeyword ( this .dataGridView1 , "ShowColorNumber.htm#dataGridView1" );
            this .HelpProviderHG .SetHelpNavigator ( this .dataGridView1 , System .Windows .Forms .HelpNavigator .Topic );
            this .dataGridView1 .Location = new System .Drawing .Point ( 0 , 0 );
            this .dataGridView1 .Name = "dataGridView1";
            this .dataGridView1 .ReadOnly = true;
            this .HelpProviderHG .SetShowHelp ( this .dataGridView1 , true );
            this .dataGridView1 .Size = new System .Drawing .Size ( 352 , 405 );
            this .dataGridView1 .TabIndex = 1;
            this .dataGridView1 .RowsAdded += new System .Windows .Forms .DataGridViewRowsAddedEventHandler ( this .dataGridView1_RowsAdded );
            // 
            // HelpProviderHG
            // 
            this .HelpProviderHG .HelpNamespace = "Mixture.chm";
            // 
            // ShowColorNumber
            // 
            this .AutoScaleDimensions = new System .Drawing .SizeF ( 6F , 13F );
            this .AutoScaleMode = System .Windows .Forms .AutoScaleMode .Font;
            this .ClientSize = new System .Drawing .Size ( 352 , 407 );
            this .Controls .Add ( this .dataGridView1 );
            this .Font = new System .Drawing .Font ( "Tahoma" , 8.25F , System .Drawing .FontStyle .Regular , System .Drawing .GraphicsUnit .Point , ( ( byte ) ( 178 ) ) );
            this .HelpProviderHG .SetHelpKeyword ( this , "ShowColorNumber.htm" );
            this .HelpProviderHG .SetHelpNavigator ( this , System .Windows .Forms .HelpNavigator .Topic );
            this .Icon = ( ( System .Drawing .Icon ) ( resources .GetObject ( "$this.Icon" ) ) );
            this .MaximizeBox = false;
            this .MinimizeBox = false;
            this .Name = "ShowColorNumber";
            this .RightToLeft = System .Windows .Forms .RightToLeft .Yes;
            this .HelpProviderHG .SetShowHelp ( this , true );
            this .StartPosition = System .Windows .Forms .FormStartPosition .CenterScreen;
            this .Text = "نمایش شماره های تصاویر";
            ( ( System .ComponentModel .ISupportInitialize ) ( this .dataGridView1 ) ) .EndInit ( );
            this .ResumeLayout ( false );

            }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.HelpProvider HelpProviderHG;
        }
    }