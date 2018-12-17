namespace Resizer
    {
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System .ComponentModel .ComponentResourceManager ( typeof ( Form1 ) );
            this .pictureBox2 = new System .Windows .Forms .PictureBox ( );
            this .pictureBox1 = new System .Windows .Forms .PictureBox ( );
            this .label1 = new System .Windows .Forms .Label ( );
            this .groupBox1 = new System .Windows .Forms .GroupBox ( );
            this .groupBox3 = new System .Windows .Forms .GroupBox ( );
            this .tt2 = new System .Windows .Forms .TextBox ( );
            this .tt1 = new System .Windows .Forms .TextBox ( );
            this .label6 = new System .Windows .Forms .Label ( );
            this .btn2 = new System .Windows .Forms .Button ( );
            this .label7 = new System .Windows .Forms .Label ( );
            this .pic2 = new System .Windows .Forms .PictureBox ( );
            this .label8 = new System .Windows .Forms .Label ( );
            this .label5 = new System .Windows .Forms .Label ( );
            this .groupBox2 = new System .Windows .Forms .GroupBox ( );
            this .t2 = new System .Windows .Forms .TextBox ( );
            this .t1 = new System .Windows .Forms .TextBox ( );
            this .label4 = new System .Windows .Forms .Label ( );
            this .btn1 = new System .Windows .Forms .Button ( );
            this .label3 = new System .Windows .Forms .Label ( );
            this .label2 = new System .Windows .Forms .Label ( );
            this .ofd1 = new System .Windows .Forms .OpenFileDialog ( );
            this .sfd1 = new System .Windows .Forms .SaveFileDialog ( );
            this .pic1 = new System .Windows .Forms .PictureBox ( );
            ( ( System .ComponentModel .ISupportInitialize ) ( this .pictureBox2 ) ) .BeginInit ( );
            ( ( System .ComponentModel .ISupportInitialize ) ( this .pictureBox1 ) ) .BeginInit ( );
            this .groupBox1 .SuspendLayout ( );
            this .groupBox3 .SuspendLayout ( );
            ( ( System .ComponentModel .ISupportInitialize ) ( this .pic2 ) ) .BeginInit ( );
            this .groupBox2 .SuspendLayout ( );
            ( ( System .ComponentModel .ISupportInitialize ) ( this .pic1 ) ) .BeginInit ( );
            this .SuspendLayout ( );
            // 
            // pictureBox2
            // 
            this .pictureBox2 .Image = global::Resizer .Properties .Resources .bg_bar;
            this .pictureBox2 .Location = new System .Drawing .Point ( 0 , 80 );
            this .pictureBox2 .Name = "pictureBox2";
            this .pictureBox2 .Size = new System .Drawing .Size ( 472 , 46 );
            this .pictureBox2 .SizeMode = System .Windows .Forms .PictureBoxSizeMode .StretchImage;
            this .pictureBox2 .TabIndex = 1;
            this .pictureBox2 .TabStop = false;
            // 
            // pictureBox1
            // 
            this .pictureBox1 .Image = global::Resizer .Properties .Resources .Untitled_1_copy;
            this .pictureBox1 .Location = new System .Drawing .Point ( -32 , -8 );
            this .pictureBox1 .Name = "pictureBox1";
            this .pictureBox1 .Size = new System .Drawing .Size ( 544 , 96 );
            this .pictureBox1 .SizeMode = System .Windows .Forms .PictureBoxSizeMode .StretchImage;
            this .pictureBox1 .TabIndex = 0;
            this .pictureBox1 .TabStop = false;
            // 
            // label1
            // 
            this .label1 .AutoSize = true;
            this .label1 .BackColor = System .Drawing .Color .White;
            this .label1 .Font = new System .Drawing .Font ( "Tahoma" , 9F , System .Drawing .FontStyle .Regular , System .Drawing .GraphicsUnit .Point , ( ( byte ) ( 0 ) ) );
            this .label1 .Location = new System .Drawing .Point ( 320 , 96 );
            this .label1 .Name = "label1";
            this .label1 .Size = new System .Drawing .Size ( 123 , 14 );
            this .label1 .TabIndex = 2;
            this .label1 .Text = "پلاگین تغییر اندازه تصویر";
            // 
            // groupBox1
            // 
            this .groupBox1 .Controls .Add ( this .groupBox3 );
            this .groupBox1 .Controls .Add ( this .label5 );
            this .groupBox1 .Controls .Add ( this .groupBox2 );
            this .groupBox1 .Location = new System .Drawing .Point ( 8 , 136 );
            this .groupBox1 .Name = "groupBox1";
            this .groupBox1 .RightToLeft = System .Windows .Forms .RightToLeft .Yes;
            this .groupBox1 .Size = new System .Drawing .Size ( 456 , 320 );
            this .groupBox1 .TabIndex = 3;
            this .groupBox1 .TabStop = false;
            // 
            // groupBox3
            // 
            this .groupBox3 .Controls .Add ( this .tt2 );
            this .groupBox3 .Controls .Add ( this .tt1 );
            this .groupBox3 .Controls .Add ( this .label6 );
            this .groupBox3 .Controls .Add ( this .btn2 );
            this .groupBox3 .Controls .Add ( this .label7 );
            this .groupBox3 .Controls .Add ( this .pic2 );
            this .groupBox3 .Controls .Add ( this .label8 );
            this .groupBox3 .Location = new System .Drawing .Point ( 8 , 16 );
            this .groupBox3 .Name = "groupBox3";
            this .groupBox3 .Size = new System .Drawing .Size ( 176 , 295 );
            this .groupBox3 .TabIndex = 7;
            this .groupBox3 .TabStop = false;
            this .groupBox3 .Text = "تصویر نهایی";
            // 
            // tt2
            // 
            this .tt2 .Location = new System .Drawing .Point ( 12 , 227 );
            this .tt2 .MaxLength = 4;
            this .tt2 .Name = "tt2";
            this .tt2 .Size = new System .Drawing .Size ( 96 , 21 );
            this .tt2 .TabIndex = 6;
            this .tt2 .KeyPress += new System .Windows .Forms .KeyPressEventHandler ( this .tt1_KeyPress );
            // 
            // tt1
            // 
            this .tt1 .Location = new System .Drawing .Point ( 12 , 200 );
            this .tt1 .MaxLength = 4;
            this .tt1 .Name = "tt1";
            this .tt1 .Size = new System .Drawing .Size ( 96 , 21 );
            this .tt1 .TabIndex = 5;
            this .tt1 .KeyPress += new System .Windows .Forms .KeyPressEventHandler ( this .tt1_KeyPress );
            // 
            // label6
            // 
            this .label6 .AutoSize = true;
            this .label6 .Location = new System .Drawing .Point ( 136 , 231 );
            this .label6 .Name = "label6";
            this .label6 .Size = new System .Drawing .Size ( 30 , 13 );
            this .label6 .TabIndex = 4;
            this .label6 .Text = "طول:";
            // 
            // btn2
            // 
            this .btn2 .Location = new System .Drawing .Point ( 12 , 256 );
            this .btn2 .Name = "btn2";
            this .btn2 .Size = new System .Drawing .Size ( 96 , 23 );
            this .btn2 .TabIndex = 0;
            this .btn2 .Text = "ذخیره تصویر";
            this .btn2 .UseVisualStyleBackColor = true;
            this .btn2 .Click += new System .EventHandler ( this .btn2_Click );
            // 
            // label7
            // 
            this .label7 .AutoSize = true;
            this .label7 .Location = new System .Drawing .Point ( 128 , 203 );
            this .label7 .Name = "label7";
            this .label7 .Size = new System .Drawing .Size ( 39 , 13 );
            this .label7 .TabIndex = 3;
            this .label7 .Text = "عرض: ";
            // 
            // pic2
            // 
            this .pic2 .BorderStyle = System .Windows .Forms .BorderStyle .FixedSingle;
            this .pic2 .Location = new System .Drawing .Point ( 8 , 24 );
            this .pic2 .Name = "pic2";
            this .pic2 .Size = new System .Drawing .Size ( 160 , 144 );
            this .pic2 .SizeMode = System .Windows .Forms .PictureBoxSizeMode .StretchImage;
            this .pic2 .TabIndex = 0;
            this .pic2 .TabStop = false;
            // 
            // label8
            // 
            this .label8 .AutoSize = true;
            this .label8 .Location = new System .Drawing .Point ( 8 , 168 );
            this .label8 .Name = "label8";
            this .label8 .Size = new System .Drawing .Size ( 163 , 13 );
            this .label8 .TabIndex = 2;
            this .label8 .Text = "__________________________";
            // 
            // label5
            // 
            this .label5 .AutoSize = true;
            this .label5 .Font = new System .Drawing .Font ( "Tahoma" , 8.25F , System .Drawing .FontStyle .Bold , System .Drawing .GraphicsUnit .Point , ( ( byte ) ( 0 ) ) );
            this .label5 .Location = new System .Drawing .Point ( 192 , 144 );
            this .label5 .Name = "label5";
            this .label5 .Size = new System .Drawing .Size ( 77 , 13 );
            this .label5 .TabIndex = 7;
            this .label5 .Text = "تغییر اندازه به";
            // 
            // groupBox2
            // 
            this .groupBox2 .Controls .Add ( this .t2 );
            this .groupBox2 .Controls .Add ( this .t1 );
            this .groupBox2 .Controls .Add ( this .label4 );
            this .groupBox2 .Controls .Add ( this .btn1 );
            this .groupBox2 .Controls .Add ( this .label3 );
            this .groupBox2 .Controls .Add ( this .pic1 );
            this .groupBox2 .Controls .Add ( this .label2 );
            this .groupBox2 .Location = new System .Drawing .Point ( 272 , 16 );
            this .groupBox2 .Name = "groupBox2";
            this .groupBox2 .Size = new System .Drawing .Size ( 176 , 295 );
            this .groupBox2 .TabIndex = 1;
            this .groupBox2 .TabStop = false;
            this .groupBox2 .Text = "تصویر شما";
            // 
            // t2
            // 
            this .t2 .Location = new System .Drawing .Point ( 12 , 227 );
            this .t2 .Name = "t2";
            this .t2 .ReadOnly = true;
            this .t2 .Size = new System .Drawing .Size ( 96 , 21 );
            this .t2 .TabIndex = 6;
            // 
            // t1
            // 
            this .t1 .Location = new System .Drawing .Point ( 12 , 200 );
            this .t1 .Name = "t1";
            this .t1 .ReadOnly = true;
            this .t1 .Size = new System .Drawing .Size ( 96 , 21 );
            this .t1 .TabIndex = 5;
            // 
            // label4
            // 
            this .label4 .AutoSize = true;
            this .label4 .Location = new System .Drawing .Point ( 136 , 231 );
            this .label4 .Name = "label4";
            this .label4 .Size = new System .Drawing .Size ( 30 , 13 );
            this .label4 .TabIndex = 4;
            this .label4 .Text = "طول:";
            // 
            // btn1
            // 
            this .btn1 .Location = new System .Drawing .Point ( 12 , 256 );
            this .btn1 .Name = "btn1";
            this .btn1 .Size = new System .Drawing .Size ( 96 , 23 );
            this .btn1 .TabIndex = 0;
            this .btn1 .Text = "انتخاب تصویر";
            this .btn1 .UseVisualStyleBackColor = true;
            this .btn1 .Click += new System .EventHandler ( this .btn1_Click );
            // 
            // label3
            // 
            this .label3 .AutoSize = true;
            this .label3 .Location = new System .Drawing .Point ( 128 , 203 );
            this .label3 .Name = "label3";
            this .label3 .Size = new System .Drawing .Size ( 39 , 13 );
            this .label3 .TabIndex = 3;
            this .label3 .Text = "عرض: ";
            // 
            // label2
            // 
            this .label2 .AutoSize = true;
            this .label2 .Location = new System .Drawing .Point ( 8 , 168 );
            this .label2 .Name = "label2";
            this .label2 .Size = new System .Drawing .Size ( 163 , 13 );
            this .label2 .TabIndex = 2;
            this .label2 .Text = "__________________________";
            // 
            // ofd1
            // 
            this .ofd1 .AddExtension = false;
            this .ofd1 .Filter = "*.bmp|*.bmp";
            this .ofd1 .Title = "انتخاب تصویر";
            // 
            // sfd1
            // 
            this .sfd1 .AddExtension = false;
            this .sfd1 .Filter = "*.bmp|*.bmp";
            this .sfd1 .Title = "ذخیره تصویر";
            // 
            // pic1
            // 
            this .pic1 .BorderStyle = System .Windows .Forms .BorderStyle .FixedSingle;
            this .pic1 .Location = new System .Drawing .Point ( 8 , 24 );
            this .pic1 .Name = "pic1";
            this .pic1 .Size = new System .Drawing .Size ( 160 , 144 );
            this .pic1 .SizeMode = System .Windows .Forms .PictureBoxSizeMode .StretchImage;
            this .pic1 .TabIndex = 0;
            this .pic1 .TabStop = false;
            // 
            // Form1
            // 
            this .AutoScaleDimensions = new System .Drawing .SizeF ( 6F , 13F );
            this .AutoScaleMode = System .Windows .Forms .AutoScaleMode .Font;
            this .ClientSize = new System .Drawing .Size ( 473 , 460 );
            this .Controls .Add ( this .groupBox1 );
            this .Controls .Add ( this .label1 );
            this .Controls .Add ( this .pictureBox2 );
            this .Controls .Add ( this .pictureBox1 );
            this .Font = new System .Drawing .Font ( "Tahoma" , 8.25F , System .Drawing .FontStyle .Regular , System .Drawing .GraphicsUnit .Point , ( ( byte ) ( 0 ) ) );
            this .FormBorderStyle = System .Windows .Forms .FormBorderStyle .FixedSingle;
            this .Icon = ( ( System .Drawing .Icon ) ( resources .GetObject ( "$this.Icon" ) ) );
            this .Name = "Form1";
            this .StartPosition = System .Windows .Forms .FormStartPosition .CenterScreen;
            this .Text = "تغییر اندازه تصویر";
            this .Load += new System .EventHandler ( this .Form1_Load );
            this .FormClosing += new System .Windows .Forms .FormClosingEventHandler ( this .Form1_FormClosing );
            ( ( System .ComponentModel .ISupportInitialize ) ( this .pictureBox2 ) ) .EndInit ( );
            ( ( System .ComponentModel .ISupportInitialize ) ( this .pictureBox1 ) ) .EndInit ( );
            this .groupBox1 .ResumeLayout ( false );
            this .groupBox1 .PerformLayout ( );
            this .groupBox3 .ResumeLayout ( false );
            this .groupBox3 .PerformLayout ( );
            ( ( System .ComponentModel .ISupportInitialize ) ( this .pic2 ) ) .EndInit ( );
            this .groupBox2 .ResumeLayout ( false );
            this .groupBox2 .PerformLayout ( );
            ( ( System .ComponentModel .ISupportInitialize ) ( this .pic1 ) ) .EndInit ( );
            this .ResumeLayout ( false );
            this .PerformLayout ( );

            }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox t2;
        private System.Windows.Forms.TextBox t1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tt2;
        private System.Windows.Forms.TextBox tt1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.SaveFileDialog sfd1;
        private System.Windows.Forms.PictureBox pic1;
        }
    }

