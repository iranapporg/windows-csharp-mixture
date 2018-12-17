using System;
using System .Collections .Generic;
using System .ComponentModel;
using System .Drawing;
using System .Data;
using System .Linq;
using System .Text;
using System .Windows .Forms;
using System.Collections;

namespace Mixture
    {
    public partial class ShowColor : UserControl
        {
 
        public static Hashtable ht1=new Hashtable ( ); //Color Information
        public static Hashtable ht2=new Hashtable ( ); //Save Color Number

        public ShowColor ( )
            {
            InitializeComponent ( );
            }
 
        
        /// <summary>
        ///Get Color Information into Hashtable 
        /// </summary>
        public Hashtable PixelColor
            {
            set
                {
                ht1 = value;  
                }
            }

        /// <summary>
        /// Create Color Rectangle For Show it
        /// </summary>
        public  void CreateColor()
            {

            //Save CR(Color Rectangle) Postion
            int intleft = 15; 
            int inttop=0; 
            int i=0;

            try
                {
                //New Object
                ht2 .Clear ( );
                pictureBox1 .Controls .Clear ( );

                this .Cursor = Cursors .WaitCursor;
                for ( int j=0 ; j <= Conf .myColors .Count - 1 ; j++ )
                    {

                    PictureBox p1=new PictureBox ( );
                    p1 .BackColor = Conf .HexToColor ( Conf.myColors[i].Name.Substring(2) );
                    p1 .BorderStyle = BorderStyle .Fixed3D;
                    p1 .Size = new Size ( 20 , 20 );
                    p1 .Cursor = Cursors .Hand;
 
                    toolTip1 .SetToolTip ( p1 , "کليک کنيد" );

                    p1 .Click += new EventHandler ( p1_Click );
                    p1 .MouseMove += new MouseEventHandler ( p1_MouseMove );
                    p1 .MouseLeave += new EventHandler ( p1_MouseLeave );
 
                    if ( i % 10 == 0 )
                        {
                        inttop = inttop + 25;
                        intleft = 15;
                        }


                    p1 .Left += intleft;
                    p1 .Top = inttop;
                    pictureBox1 .Controls .Add ( p1 );
                    intleft = p1 .Left + p1 .Width + 5;
                    ++i;
                    Application .DoEvents ( );
                    }
                this .Cursor = Cursors .Default;
                }
            catch ( Exception ex )
                {
                System .IO .File .AppendAllText ( Application .StartupPath + "\\Error.txt" , ex .Message .ToString ( ) );
                }
            }


        private void p1_MouseMove(object sender,MouseEventArgs e)
            {
            PictureBox pb1=sender as PictureBox;
            pb1 .BorderStyle = BorderStyle .FixedSingle;
            }

        private void p1_MouseLeave ( object sender , EventArgs e )
            {
            PictureBox pb1=sender as PictureBox;
            pb1 .BorderStyle = BorderStyle .Fixed3D;
            }
        private void p1_Click ( object sender , EventArgs e )
            {

            try
                {
                PictureBox pb1= sender as PictureBox;
                string strtag=pb1 .Tag .ToString ( );
                ShowInf si=new ShowInf ( );
                string[] strinf=strtag .Split ( ',' );
                Color col1=Conf .HexToColor ( strinf [ 0 ] );

                si .ColorName = Conf .HexToColor ( strinf [ 0 ] );
                si .ColorId = strinf [ 0 ];
                si .ColorNumber = strinf [ 1 ];
                si .ReapetCount = strinf [ 2 ];
                si .R = ( ( int ) col1 .R ) .ToString ( );
                si .G = ( ( int ) col1 .G ) .ToString ( );
                si .B = ( ( int ) col1 .B ) .ToString ( );
                HSLColor hl1=HSLColor .FromRGB ( col1 );
                si .Hue = Math .Ceiling ( col1 .GetHue ( ) ) .ToString ( );
                si .Sat = Math .Ceiling ( hl1 .Saturation ) .ToString ( );

                si .Bright = ( ( col1 .R + col1 .G + col1 .B ) / 3 ) .ToString ( );
                si .ShowDialog ( );
                }

            catch ( Exception ex )
                {
                System .IO .File .AppendAllText ( Application .StartupPath + "\\Error.txt" , ex .Message .ToString ( ) );
                }
            }
    }
    }
