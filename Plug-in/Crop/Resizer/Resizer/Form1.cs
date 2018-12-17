using System;
using System .Collections .Generic;
using System .ComponentModel;
using System .Data;
using System .Drawing;
using System .Linq;
using System .Text;
using System .Windows .Forms;
using Microsoft.Win32;
using System .Drawing .Drawing2D;
using System.IO;

namespace Resizer
    {
    public partial class Form1 : Form
        {
        public Form1 ( )
            {
            InitializeComponent ( );
            }
        string strpath;

        private void btn1_Click ( object sender , EventArgs e )
            {
            ofd1 .ShowDialog ( );
            if ( ofd1 .FileName != "" )
                {
                pic1 .Image = Image .FromFile ( ofd1 .FileName );
                Bitmap bm1;
                bm1 = new Bitmap ( ofd1 .FileName );
                pic2 .Image = Image .FromFile ( ofd1 .FileName );
                strpath = ofd1 .FileName;
                t1 .Text = bm1 .Width .ToString ( );
                t2 .Text = bm1 .Height .ToString ( );
                }
            }

        private void tt1_KeyPress ( object sender , KeyPressEventArgs e )
            {
            if ( !char .IsDigit ( e .KeyChar ) && e .KeyChar != '' )
                e .Handled = true;
            }

        private void btn2_Click ( object sender , EventArgs e )
            {

            if ( tt1 .Text != "" && tt2 .Text != "" )
                {

                sfd1 .ShowDialog ( );
                if ( sfd1 .FileName != "" )
                    {
                    Image im1=Image .FromFile ( strpath );
                    ResizeImage ( strpath , sfd1 .FileName , Convert .ToInt16 ( tt1 .Text ) , Convert .ToInt16 ( tt2 .Text ) , true );
                    MessageBox .Show ( "تصوير مورد نظر تغيير اندازه و ذخيره شد","ذخيره",MessageBoxButtons.OK,MessageBoxIcon.Information );
                    }
                }
            }
        public string GetRegister ( string strkey )
            {
            RegistryKey reg1 = Registry .CurrentUser .OpenSubKey ( "Student_Software" );

            try
                {
                string s1 = reg1 .GetValue ( strkey ) .ToString ( );
                return s1;
                }
            catch ( Exception )
                {
                return "Error";
                }

            }
        public static void SaveSetting ( string strValueName , string strVal )
            {
            try
                {
                Microsoft .Win32 .Registry .SetValue ( "HKEY_CURRENT_USER\\Student_Software" , strValueName , strVal );
                }
            catch ( Exception ex )
                {
                Microsoft .Win32 .Registry .CurrentUser .CreateSubKey ( "Student_Software" );
                }
            }
        private void Form1_Load ( object sender , EventArgs e )
            {

            string str1=GetRegister ( "PicturePath" );
            if ( str1 != "" )
                {
                pic1 .Image = Image .FromFile ( str1 );
                pic2 .Image = Image .FromFile ( str1 );
                Bitmap bm1;
                bm1 = new Bitmap ( str1 );
                strpath = ofd1 .FileName;
                t1 .Text = bm1 .Width .ToString ( );
                t2 .Text = bm1 .Height .ToString ( );
                strpath = str1;
                }
            FileInfo fi1=new FileInfo(Application.ExecutablePath);
            SaveSetting ( fi1 .Name , "تغيير اندازه تصوير" );
            MessageBox .Show ( "کاربر عزيز اندازه تصوير متناسب با گزينه شما تغيير داده ميشود","پيام",MessageBoxButtons.OK,MessageBoxIcon.Information );
            }

        private void Form1_FormClosing ( object sender , FormClosingEventArgs e )
            {
            Application .ExitThread ( );
            }

        public void ResizeImage ( string OriginalFile , string NewFile , int NewWidth , int MaxHeight , bool OnlyResizeIfWider )
            {
            System.Drawing.Image FullsizeImage = System .Drawing .Image .FromFile ( OriginalFile );

            // Prevent using images internal thumbnail
            FullsizeImage .RotateFlip ( System .Drawing .RotateFlipType .Rotate180FlipNone );
            FullsizeImage .RotateFlip ( System .Drawing .RotateFlipType .Rotate180FlipNone );

            if ( OnlyResizeIfWider )
                {
                if ( FullsizeImage .Width <= NewWidth )
                    {
                    NewWidth = FullsizeImage .Width;
                    }
                }

            int NewHeight = FullsizeImage .Height * NewWidth / FullsizeImage .Width;
            if ( NewHeight > MaxHeight )
                {
                // Resize with height instead
                NewWidth = FullsizeImage .Width * MaxHeight / FullsizeImage .Height;
                NewHeight = MaxHeight;
                }

            System.Drawing.Image NewImage = FullsizeImage .GetThumbnailImage ( NewWidth , NewHeight , null , IntPtr .Zero );

            // Clear handle to original file so that we can overwrite it if necessary
            FullsizeImage .Dispose ( );

            // Save resized picture
            NewImage .Save ( NewFile );
            }

        }
    }
     
