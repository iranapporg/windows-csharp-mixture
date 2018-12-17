using System;
using System .Collections .Generic;
using System .ComponentModel;
using System .Data;
using System.Globalization;
using System .Drawing;
using System .Linq;
using System .Text;
using System .Windows .Forms;
using System.Collections;
using System.IO;
using System .Runtime .InteropServices;
using System.Threading;
using System.Media;
using System.Diagnostics;
namespace Mixture
    {
    public partial class Form1 : Form
        {

        #region Api Function
        [DllImport ( "User32.dll" , CharSet = CharSet .Ansi , BestFitMapping = false , ThrowOnUnmappableChar = true )]
        private static extern IntPtr LoadCursorFromFile ( String str );
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute ( "user32.dll" )]
        public static extern int SendMessage ( IntPtr hWnd ,int Msg , int wParam , int lParam );

        [DllImportAttribute ( "user32.dll" )]
        public static extern bool ReleaseCapture ( );

        #endregion

        public Form1 ( )
            {
            InitializeComponent ( );
            }

        PictureBox picdefault; // Save All Setting Default Picture For Reset Setting
        bool blnEdit=false;     //If User Selected Tools in Toolsbar,Assign True For Prevent of Get Color in Mouse Move
        Color clrSelected;       //If User Mouse is On Picture and Click on Color,it's Color Save this Var
        int intprogress=0;     //For Save Process
        Hashtable alColorTeif=new Hashtable(); //For Save ascendant  Color
        string strStatename="";
        string strcountmaxstate="";
        bool blnIsCheckMixture=false;
        string picpath="";
        Hashtable ht2=new Hashtable();
 
        #region The Properties Of Program
        public int Width
                  {
                  get
                       {
                       try
                           {
                           Bitmap bm1=new Bitmap ( Conf .strPath );
                           int iW=bm1 .Size .Width;
                           bm1 .Dispose ( );
                           return iW;
                           }
                       catch ( Exception )
                           {
                           return 0;
                           }
                       }
                  }

              public int Height
                  {
                  get
                      {
                      try
                           {
                           Bitmap bm1=new Bitmap ( Conf .strPath );
                           int iH=bm1 .Size .Height;
                           bm1 .Dispose ( );
                           return iH;
                           }
                      catch(Exception)
                          {
                          return 0;
                          }
                      }
                  }

        #endregion

 

 
         #region For Graphical Object
        private void label3_MouseLeave ( object sender , EventArgs e )
            {
            Label lbl1=new Label ( );
            lbl1 = sender as Label;
            lbl1 .ForeColor = Color .Black;
            lbl1 .Font = new Font ( "tahoma" , 9 , FontStyle .Regular );
            }

        private void label3_MouseMove ( object sender , MouseEventArgs e )
            {
            Label lbl1=new Label ( );
            lbl1 = sender as Label;
            lbl1 .ForeColor = Color .Blue;
            lbl1 .Font = new Font ( "tahoma" ,9, FontStyle .Underline );
            }
#endregion

        #region User Option Selected

        private void label9_Click ( object sender , EventArgs e )
            {
            pnlaction .Enabled = false;
            tabControl2 .SelectedIndex = 1;
            }

        private void label11_Click ( object sender , EventArgs e )
            {
            pnlaction .Enabled = false;
            this .Enabled = false;
            tabControl2 .SelectedIndex = 2;
            this .Cursor = Cursors .WaitCursor;
            dg2 .DataSource = Conf .ConvertHastTableToDataTable ( Conf .Colorinf );
            this .Cursor = Cursors .Default;
            this .Enabled = true;
            }

        private void label12_Click ( object sender , EventArgs e )
            {

            tabControl2 .SelectedIndex = 0;
            ofd1 .ShowDialog ( );
            pnlaction .Enabled = false;
            pb1 .Image = null;

            try
                {
                if ( ofd1 .FileName != "" )
                    {
                    Conf .strPath = ofd1 .FileName;

                    if ( Width > 700 || Height > 800 )
                        {
                        MessageBox .Show ( "کاربر عزيز اندازه تصوير بزرگ است\nلطفا تصوير را کوچکتر کنيد و ان را لود کنيد" , "اخطار"
                            , MessageBoxButtons .OK , MessageBoxIcon .Exclamation );
                        return;
                        }

                   if (new FileInfo(ofd1.FileName).Extension.ToString() != ".bmp")
                        {
                        MessageBox .Show ( "تصوير انتخاب شده مشکل دارد.لطفا دوباره سعي کنيد" , "اخطار"
                            , MessageBoxButtons .OK , MessageBoxIcon .Exclamation );
                        return;
                        }

                    SoundPlayer sp1 = new SoundPlayer ( );
                    sp1 .SoundLocation = Application .StartupPath + "\\tick.wav";
                    sp1 .PlayLooping ( );

                    this .Enabled = false;
                    t2 .Text = Width .ToString ( );
                    t1 .Text = Height .ToString ( );
                    Conf .LoadPixel ( ofd1 .FileName , this , Width , Height , pgb1 );
                    pgb1 .BackColor = Color .White;
                    NewPicturePixel ( );
                    mnulaghv_Click ( null , null );
                    UnlockOption ( );

                    if ( Width % 2 != 0 || Height % 2 != 0 )
                        {
                        lblshowmixture .Enabled = false;
                        groupBox2 .Enabled = false;
                        }
                    else
                        {
                        lblshowmixture .Enabled = true;
                        }
                    sp1 .Stop ( );
                    this .Enabled = true;
                    pb1 .Image = Image .FromFile ( ofd1 .FileName );
                    //Show Table Color
                    Hashtable ht1= Conf .GetDuplicateValue ( Conf .arr1 );
                    ht2 = ht1;
                    txtcount .Text = Conf .strCountColor;
                    blnIsCheckMixture = false;
                    Conf .SaveSetting ( "PicturePath" , ofd1 .FileName );
                    this .Text = "Mixture Color Checker : " + ofd1 .FileName;
                    ofd1 .FileName = "";

                    SortColorlist ( ht1 );

                    if (chk3.Checked == true)
                        {
                        Show_Color_Table sct1=new Show_Color_Table ( );
                        sct1.CreateTable(ht1);
                        sct1.Show();
                        }
                    else
                        {
                          ShowColor sc1=new ShowColor();
                          sc1 .Location = new Point ( 72 , 40 );
                          pnlshowtable .Controls .Add ( sc1 );
                          sc1 .PixelColor = ht1;
                          sc1 .CreateColor ( );
                        }
                    

                    
                   
                    }
                pb1.Image=Image.FromFile(picpath);

                }

            catch(Exception ex)
                {
                    System .IO .File .AppendAllText ( Application .StartupPath + "\\Error.txt" , ex .Message .ToString ( ) );
                }
            }

        private void SortColorlist ( Hashtable ht1 )
            {
            alColorTeif = new Hashtable ( );
            string[] strColor=new string [ ht1 .Count ];
            int intcounter=0;
            IDictionaryEnumerator enumerator = ht1 .GetEnumerator ( );
            while ( enumerator .MoveNext ( ) )
                {
                strColor [ intcounter++ ] = enumerator .Key .ToString ( );
                }
            Array .Sort ( strColor );

            foreach(string str1 in strColor)
                {
                alColorTeif .Add ( str1 , "" );
                }

            }

  
        private void UnlockOption ( )
            {
            lblshowtable .Enabled = true;
            lblshowduplicate .Enabled = true;
            lblsearch .Enabled = true;
            pnlsearch .Enabled = true;
            pnlshowduplicate .Enabled = true;
            pnlshowtable .Enabled = true;
            lblshowmixture .Enabled = true;
            lblshowseri .Enabled = true;
            pnlaction .Enabled = true;
            }

        private void lbl1_Click ( object sender , EventArgs e )
            {
            if ( MessageBox .Show ( "آيا قصد بستن برنامه را داريد؟" , "خروج" , MessageBoxButtons .YesNo , MessageBoxIcon .Question ) == DialogResult .Yes )
                {
                Application .ExitThread ( );
                }
            }

        #endregion

        private void dg2_RowsAdded ( object sender , DataGridViewRowsAddedEventArgs e )
            {
            Color c1;
            DataGridView data1=sender as DataGridView;

            try
                {
                for ( int i = 0 ; i < data1 .Rows .Count ; i++ )
                    {
                    string str1=data1 .Rows [ i ] .Cells [ 1 ] .Value .ToString ( );
                    c1 = Conf .HexToColor ( str1 );
                    data1 .Rows [ i ] .Cells [ 3 ] .Style .BackColor = c1;

                    }
                }
            catch ( Exception ex )
                {
                System .IO .File .AppendAllText ( Application .StartupPath + "\\Error.txt" , ex .Message .ToString ( ) );
                }
            }



 
        private void OnlyNumber_KeyPress ( object sender , KeyPressEventArgs e )
            {
            if ( !char .IsDigit ( e .KeyChar ) && e .KeyChar != '' )
                e .Handled = true;

            }

        private void btn1_Click ( object sender , EventArgs e )
            {
            DataRow dr1;
            DataTable dt1=new DataTable ( "Duplicate" );

            try
                {
                bool blnstate=false;

                if ( r1 .Checked == true && txtwithid .Text != "" )
                    {
                    this .Cursor = Cursors .WaitCursor;
                    foreach ( DictionaryEntry de in Conf .Colorinf )
                        {
                        if ( de .Key .ToString ( ) == txtwithid .Text )
                            {
                            Color c1=Conf .HexToColor ( txtwithid .Text );
                            lblpic .BackColor = c1;
                            lblr .Text = c1 .R .ToString ( );
                            lblg .Text = c1 .G .ToString ( );
                            lblb .Text = c1 .B .ToString ( );
                            lblcount .Text = de .Value .ToString ( );
                            lblid .Text = de .Key .ToString ( );
                            lblnumber .Text = ShowColor .ht2 [ de .Key ] .ToString ( );
                            blnstate = true;
                            }
                        this .Cursor = Cursors .Default;
                        }
                    if ( blnstate == false )
                        {
                        MessageBox .Show ( "گزينه مورد نظر يافت نشد" , "Error Find" , MessageBoxButtons .OK , MessageBoxIcon .Information );
                        NewSearch ( );
                        }
                    }
                else if ( r2 .Checked = true && txtcountcolor .Text != "" )
                    {
                    this .Cursor = Cursors .WaitCursor;
                    dt1 .Columns .Add ( "شماره" );
                    dt1 .Columns .Add ( "تعداد" );
                    dt1 .Columns .Add ( "رنگ" );

                    foreach ( DictionaryEntry de in Conf .Colorinf )
                        {
                        if ( de .Value .ToString ( ) == txtcountcolor .Text )
                            {
                            dr1 = dt1 .NewRow ( );
                            dr1 [ "شماره" ] = de .Key .ToString ( );
                            dr1 [ "تعداد" ] = de .Value .ToString ( );
                            dt1 .Rows .Add ( dr1 );
                            dgr1 .DataSource = dt1;
                            blnstate = true;
                            }
                        }
                    this .Cursor = Cursors .Default;
                    if ( blnstate == false )
                        {
                        MessageBox .Show ( "گزينه مورد نظر يافت نشد" , "Error Find" , MessageBoxButtons .OK , MessageBoxIcon .Information );
                        NewSearch ( );
                        }
                    }
                else if ( r3 .Checked == true && txtR .Text != "" && txtG .Text != "" && txtB .Text != "" )
                    {
                    this .Cursor = Cursors .WaitCursor;
                    foreach ( DictionaryEntry de in Conf .Colorinf )
                        {
                        Color c1=Conf .HexToColor ( de .Key .ToString ( ) );
                        if ( c1 .R .ToString ( ) == txtR .Text && c1 .G .ToString ( ) == txtG .Text && c1 .B .ToString ( ) == txtB .Text )
                            {
                            lblpic .BackColor = c1;
                            lblr .Text = c1 .R .ToString ( );
                            lblg .Text = c1 .G .ToString ( );
                            lblb .Text = c1 .B .ToString ( );
                            lblcount .Text = de .Value .ToString ( );
                            lblid .Text = de .Key .ToString ( );
                            lblnumber .Text = ShowColor .ht2 [ de .Key ] .ToString ( );
                            blnstate = true;
                            }
                        }
                    this .Cursor = Cursors .Default;

                    if ( blnstate == false )
                        {
                        MessageBox .Show ( "گزينه مورد نظر يافت نشد" , "Error Find" , MessageBoxButtons .OK , MessageBoxIcon .Information );
                        NewSearch ( );
                        }
                    }

                else if ( r4 .Checked == true && tcolornumber .Text != "" )
                    {
                    this .Cursor = Cursors .WaitCursor;
                    foreach ( DictionaryEntry de in ShowColor .ht2 )
                        {

                        if ( de .Value .ToString ( ) == tcolornumber .Text )
                            {
                            Color c1=Conf .HexToColor ( de .Key .ToString ( ) );
                            lblpic .BackColor = c1;
                            lblr .Text = c1 .R .ToString ( );
                            lblg .Text = c1 .G .ToString ( );
                            lblb .Text = c1 .B .ToString ( );
                            lblcount .Text = de .Value .ToString ( );
                            lblid .Text = de .Key .ToString ( );
                            lblnumber .Text = ShowColor .ht2 [ de .Key ] .ToString ( );
                            blnstate = true;
                            }
                        }
                    this .Cursor = Cursors .Default;
                    if ( blnstate == false )
                        {
                        MessageBox .Show ( "گزينه مورد نظر يافت نشد" , "Error Find" , MessageBoxButtons .OK , MessageBoxIcon .Information );
                        NewSearch ( );
                        }
                    }
                }
            catch ( Exception ex )
                {
                System .IO .File .AppendAllText ( Application .StartupPath + "\\Error.txt" , ex .Message .ToString ( ) );
                }
            }




        #region New Object

        private void NewSearch ( )
            {
            r1 .Checked = true;
            txtG .Text = "";
            txtR .Text = "";
            txtB .Text = "";
            dgr1 .DataSource = null;
            lblr .Text = "";
            lblg .Text = "";
            lblb .Text = "";
            tcolornumber .Text = "";
            txtcountcolor .Text = "";
            txtwithid .Text = "";
            lblnumber .Text = "";
            lblcount .Text = "";
            lblid .Text = "";
            lblpic .BackColor = Color .Transparent;
            }

        private void NewPicturePixel ( )
            {
            dg2 .DataSource = null;
            pb1 .SizeMode = picdefault .SizeMode;
            pb1 .Size = picdefault .Size;
            pb1 .Location = picdefault .Location;
            }

        private void tabPage6_Enter ( object sender , EventArgs e )
            {
            pnlaction .Enabled = false;
            NewSearch ( );
            }

        #endregion

        #region Search Option

        private void r4_CheckedChanged ( object sender , EventArgs e )
            {
            p2 .Enabled = false;
            p3 .Enabled = false;
            p1 .Enabled = false;
            g1 .Visible = false;
            g2 .Visible = true;
            tcolornumber .Enabled = true;

            }

        private void radioButton1_CheckedChanged ( object sender , EventArgs e )
            {
            p2 .Enabled = false;
            p3 .Enabled = false;
            p1 .Enabled = true;
            g1 .Visible = false;
            g2 .Visible = true;
            tcolornumber .Enabled = false;
            }

        private void radioButton2_CheckedChanged ( object sender , EventArgs e )
            {
            p1 .Enabled = false;
            p3 .Enabled = false;
            p2 .Enabled = true;
            g1 .Visible = true;
            g2 .Visible = false;
            tcolornumber .Enabled = false;
            }

        private void radioButton3_CheckedChanged ( object sender , EventArgs e )
            {
            p2 .Enabled = false;
            p1 .Enabled = false;
            p3 .Enabled = true;
            g1 .Visible = false;
            g2 .Visible = true;
            tcolornumber .Enabled = false;
            }

        private void radioButton4_CheckedChanged ( object sender , EventArgs e )
            {
            p2 .Enabled = false;
            p3 .Enabled = false;
            p1 .Enabled = false;
            }

        #endregion

        #region Menu and Tools Bar Event Handler

        private void mnuzi_Click ( object sender , EventArgs e )
            {
            try
                {
                mnuzi .Checked = true;
                mnumove .Checked = false;
                mnuzo .Checked = false;
                pb1 .Cursor = new Cursor ( LoadCursorFromFile ( Application .StartupPath + "\\zoom_in.cur" ) );
                panel2 .Cursor = new Cursor ( LoadCursorFromFile ( Application .StartupPath + "\\zoom_in.cur" ) );
                blnEdit = true;
                }
            catch ( Exception ex )
                {
                System .IO .File .WriteAllText ( Application .StartupPath + "\\Error.txt" , ex .Message .ToString ( ) );
                }
            }

        private void mnuzo_Click ( object sender , EventArgs e )
            {
            try
                {
                mnuzi .Checked = false;
                mnumove .Checked = false;
                mnuzo .Checked = true;
                mnuchangepixel .Checked = false;
                pb1 .Cursor = new Cursor ( LoadCursorFromFile ( Application .StartupPath + "\\zoom_out.cur" ) );
                panel2 .Cursor = new Cursor ( LoadCursorFromFile ( Application .StartupPath + "\\zoom_out.cur" ) );
                blnEdit = true;
                }
            catch ( Exception ex )
                {
                System .IO .File .AppendAllText ( Application .StartupPath + "\\Error.txt" , ex .Message .ToString ( ) );
                }
            }

        private void mnumove_Click ( object sender , EventArgs e )
            {
            mnuzi .Checked = false;
            mnumove .Checked = true;
            mnuzo .Checked = false;
            mnuchangepixel .Checked = false;
            pb1 .Cursor = Cursors .SizeAll;
            panel2 .Cursor = Cursors .SizeAll;
            blnEdit = true;
            }

        private void mnuchangepixel_Click ( object sender , EventArgs e )
            {
            try
                {
                mnuzi .Checked = false;
                mnumove .Checked = false;
                mnuzo .Checked = false;
                mnuchangepixel .Checked = true;
                pb1 .Cursor = new Cursor ( LoadCursorFromFile ( Application .StartupPath + "\\edit.cur" ) );
                panel2 .Cursor = new Cursor ( LoadCursorFromFile ( Application .StartupPath + "\\edit.cur" ) );
                blnEdit = true;
                }
            catch ( Exception ex )
                {
                System .IO .File .WriteAllText ( Application .StartupPath + "\\Error.txt" , ex .Message .ToString ( ) );
                }
            }

        private void mnulaghv_Click ( object sender , EventArgs e )
            {
            mnuzi .Checked = false;
            mnumove .Checked = false;
            mnuzo .Checked = false;
            mnuchangepixel .Checked = false;
            pb1 .Cursor = Cursors .Default;
            panel2 .Cursor = Cursors .Default;
            pb1 .SizeMode = PictureBoxSizeMode .AutoSize;
            blnEdit = false;
            pb1 .Location = new Point ( 0 , 0 );
            }

        private void piczi_Click ( object sender , EventArgs e )
            {
            mnuzi_Click ( null , null );
            }

        private void piczo_Click ( object sender , EventArgs e )
            {
            mnuzo_Click ( null , null );
            }

        private void picmove_Click ( object sender , EventArgs e )
            {
            mnumove_Click ( null , null );
            }

        private void pice_Click ( object sender , EventArgs e )
            {
            pb1 .Image = Image .FromFile ( Conf .strPath );
            }
        #endregion

        private void pb1_MouseDown ( object sender , MouseEventArgs e )
            {
            try
                {
                if ( Conf .strPath != "" )
                    {
                    if ( blnEdit == false )
                        {
                        Bitmap bm1=new Bitmap ( pb1 .Image );
                        clrSelected = bm1 .GetPixel ( e .X , e .Y );
                        picseledted .BackColor = clrSelected;
                        }
                    }

                if ( mnuzi .Checked == true )
                    {
                    int intWidth=pb1 .Width;
                    int intHeight=pb1 .Height;

                    if ( pb1 .SizeMode != PictureBoxSizeMode .StretchImage )
                        {
                        pb1 .SizeMode = PictureBoxSizeMode .StretchImage;
                        pb1 .Width = intWidth;
                        pb1 .Height = intHeight;
                        }

                    if ( pb1 .Width < 1 || pb1 .Height < 1 )
                        return;

                    pb1 .Height += 10;
                    pb1 .Width += 10;
                    }

                if ( mnuzo .Checked == true )
                    {

                    int intWidth=pb1 .Width;
                    int intHeight=pb1 .Height;

                    if ( pb1 .SizeMode != PictureBoxSizeMode .StretchImage )
                        {
                        pb1 .SizeMode = PictureBoxSizeMode .StretchImage;
                        pb1 .Width = intWidth;
                        pb1 .Height = intHeight;
                        }

                    pb1 .Height -= 10;
                    pb1 .Width -= 10;
                    }
                }
            catch ( Exception ex )
                {
                System .IO .File .AppendAllText ( Application .StartupPath + "\\Error.txt" , ex .Message .ToString ( ) );
                }
            }

        private void pb1_MouseMove ( object sender , MouseEventArgs e )
            {
            if ( blnEdit == false )
                {
                try
                    {
                    Bitmap bm1=new Bitmap ( pb1 .Image );
                    lblX .Text = e .X .ToString ( );
                    lblY .Text = e .Y .ToString ( );
                    Color color1;
                    color1 = bm1 .GetPixel ( e .X , e .Y );
                    string strcnt=Conf .Colorinf [ color1 .Name .Substring ( 2 ) .ToString ( ) ] .ToString ( );
                    pic1 .BackColor = color1;
                    lblcount1 .Text = strcnt;
                    lblnumber2 .Text = ShowColor .ht2 [ color1 .Name .Substring ( 2 ) .ToString ( ) ] .ToString ( );
                    }
                catch(Exception) {}
                }
            else if (mnumove.Checked == true)
                {
                if ( e .Button == MouseButtons .Left )
                    {
                    if ( mnumove .Checked == true )
                        {

                        ReleaseCapture ( );
                        SendMessage ( pb1.Handle , WM_NCLBUTTONDOWN , HT_CAPTION , 0 );

                        }
                    }
                }
            }


        #region Change Style and Setting

        private void picmove_MouseMove ( object sender , MouseEventArgs e )
            {
            PictureBox p1=sender as PictureBox;
            p1 .BorderStyle = BorderStyle .FixedSingle;
            }

        private void picmove_MouseLeave ( object sender , EventArgs e )
            {
            PictureBox p1=sender as PictureBox;
            p1 .BorderStyle = BorderStyle .None;
            }

        private void pb1_MouseLeave ( object sender , EventArgs e )
            {
            lblX .Text = "";
            lblY .Text = "";
            pic1 .BackColor = Color .Transparent;
            lblcount1 .Text = "";
            lblnumber2 .Text = "";
            }

        private void Form1_Load ( object sender , EventArgs e )
            {

            picdefault = pb1;
            int inttop=16;
            string[] strfiles=Directory .GetFiles ( Application .StartupPath + "\\Plug-in" );

            foreach ( string strf1 in strfiles )
                {
                Label lblp1=new Label ( );
                lblp1 .Left = 10;
                lblp1 .Top = inttop;
                FileInfo fi1=new FileInfo ( strf1 );
                lblp1 .Text = "      " + Conf .GetRegister ( fi1 .Name );
                lblp1 .Tag = strf1;
                lblp1 .Image = Image .FromFile ( Application .StartupPath + "\\star icon.png" );
                lblp1 .ImageAlign = ContentAlignment .TopLeft;
                inttop += 32;
                lblp1 .AutoSize = true;
                lblp1 .Font = new Font ( "tahoma" , 9 , FontStyle .Regular );
                lblp1 .MouseMove += label3_MouseMove;
                lblp1 .MouseLeave += label3_MouseLeave;
                lblp1 .Click += new EventHandler ( lblp1_Click );
                lblp1 .Cursor = Cursors .Hand;
                gb1 .Controls .Add ( lblp1 );
                }

            Conf .SaveSetting ( "AppPath" , Application .StartupPath );
            Environment .SetEnvironmentVariable ( "MixturePath" , Application .StartupPath,EnvironmentVariableTarget.User );
            }

        private void lblp1_Click(object sender,EventArgs e)
            {
            try
                {

                Label lblsender=sender as Label;
                Process pro1=new Process ( );
                pro1 .StartInfo .FileName = lblsender .Tag .ToString ( );
                pro1 .Start ( );
                
                }
            catch ( Exception ex )
                {
                System .IO .File .AppendAllText ( Application .StartupPath + "\\Error.txt" , ex .Message .ToString ( ) );
                }
            }

        #endregion

        private void label7_Click ( object sender , EventArgs e )
            {
            tabControl2 .SelectedIndex = 3;
            pnlaction .Enabled = false;
            }

        private void tabPage4_Click ( object sender , EventArgs e )
            {

            }

        private void txtX_TextChanged ( object sender , EventArgs e )
            {
            try
                {
                if ( txtX .Text != "" && txtY .Text != "" )
                    {
                    if ( Convert .ToInt16 ( txtX .Text ) > Width || Convert .ToInt16 ( txtY .Text ) > Height )
                        {
                        MessageBox .Show ( "پيکسلي با اين مشخصات پيدا نشد" , "خطا" , MessageBoxButtons .OK , MessageBoxIcon .Warning );
                        txtY .Text = "";
                        txtX .Text = "";
                        pixXY .BackColor = Color .Transparent;
                        }
                    else
                        {
                        Bitmap b1=new Bitmap ( pb1 .Image );
                        Color clr1=b1 .GetPixel ( Convert .ToInt16 ( txtX .Text ) , Convert .ToInt16 ( txtY .Text ) );
                        pixXY .BackColor = Conf .HexToColor ( clr1 .Name .Substring ( 2 ) .ToString ( ) );
                        b1 .Dispose ( );
                        }

                    }
                }
            catch ( Exception ex )
                {
                System .IO .File .AppendAllText ( Application .StartupPath + "\\Error.txt" , ex .Message .ToString ( ) );
                }
            }

        private void txtX1_TextChanged ( object sender , EventArgs e )
            {
            try
                {
                if ( txtX1 .Text != "" && txtY1 .Text != "" )
                    {
                    if ( Convert .ToInt16 ( txtX1 .Text ) > Width || Convert .ToInt16 ( txtY1 .Text ) > Height )
                        {
                        MessageBox .Show ( "پيکسلي با اين مشخصات پيدا نشد" , "خطا" , MessageBoxButtons .OK , MessageBoxIcon .Warning );
                        btnchangepixel .Enabled = false;
                        txtY1 .Text = "";
                        txtX1 .Text = "";
                        picXY1 .BackColor = Color .Transparent;
                        }
                    else
                        {
                        Bitmap b1=new Bitmap ( pb1 .Image );
                        Color clr1=b1 .GetPixel ( Convert .ToInt16 ( txtX1 .Text ) , Convert .ToInt16 ( txtY1 .Text ) );
                        picXY1 .BackColor = Conf .HexToColor ( clr1 .Name .Substring ( 2 ) .ToString ( ) );
                        btnchangepixel .Enabled = true;
                        b1 .Dispose ( );
                        }

                    }
                else
                    btnchangepixel .Enabled = false;
                }
            catch ( Exception ex )
                {
                System .IO .File .AppendAllText ( Application .StartupPath + "\\Error.txt" , ex .Message .ToString ( ) );
                }
            }

        private void picXY3_Click ( object sender , EventArgs e )
            {
            colorDialog1 .ShowDialog ( );
            if (colorDialog1.Color.Name != "")
                {
                picXY3 .BackColor = colorDialog1 .Color;
                }
            }

        private void btnchangepixel_Click ( object sender , EventArgs e )
            {
            try
                {

                Bitmap b1=new Bitmap ( pb1 .Image );
                Color clr1=picXY3 .BackColor;
                b1 .SetPixel ( Convert .ToInt16 ( txtX1 .Text ) , Convert .ToInt16 ( txtY1 .Text ) , clr1 );
                saveFileDialog1 .Filter = "*.bmp|*.bmp";
                saveFileDialog1 .ShowDialog ( );
                if ( saveFileDialog1 .FileName != "" )
                    {
                    b1 .Save ( saveFileDialog1 .FileName );
                    }

                b1 .Dispose ( );
                NewPixelAction ( );
                MessageBox .Show ( "تصوير تغيير پيکسل داده شد" , "پيکسل" , MessageBoxButtons .OK , MessageBoxIcon .Information );
                }
            catch ( Exception ex )
                {
                System .IO .File .AppendAllText ( Application .StartupPath + "\\Error.txt" , ex .Message .ToString ( ) );
                }
            }

          private void NewPixelAction()
            {
            txtX .Text = "";
            txtY .Text = "";
            txtX1 .Text = "";
            txtY1 .Text = "";
            picXY1 .BackColor = Color .Transparent;
            picXY3 .BackColor = Color .Transparent;
            pixXY .BackColor = Color .Transparent;
            btnchangepixel .Enabled = false;
            }

          private void tabControl1_Enter ( object sender , EventArgs e )
              {
              NewPixelAction ( );
              }

          private void button1_Click ( object sender , EventArgs e )
              {
              

              }

          private void dg2_CellClick ( object sender , DataGridViewCellEventArgs e )
              {
              Color clr1=Conf .HexToColor ( dg2 .CurrentRow .Cells [ 1 ] .Value .ToString ( ) );
              try
                  {

                  ShowInf si=new ShowInf ( );
                  si .ColorName = clr1;
                  si .ColorId = clr1.Name.Substring(2).ToString();
                  si .ColorNumber = dg2 .CurrentRow .Cells [ 0 ] .Value .ToString ( );
                  si .ReapetCount = dg2 .CurrentRow .Cells [ 2 ] .Value .ToString ( );
                  si .R = ( ( int ) clr1 .R ) .ToString ( );
                  si .G = ( ( int ) clr1 .G ) .ToString ( );
                  si .B = ( ( int ) clr1 .B ) .ToString ( );
                  HSLColor hl1=HSLColor .FromRGB ( clr1 );
                  si .Hue = Math .Ceiling ( clr1 .GetHue ( ) ) .ToString ( );
                  si .Sat = Math .Ceiling ( hl1 .Saturation ) .ToString ( );

                  si .Bright = ( ( clr1 .R + clr1 .G + clr1 .B ) / 3 ) .ToString ( );
                  si .ShowDialog ( );
                  }

              catch ( Exception ex )
                  {
                  System .IO .File .AppendAllText ( Application .StartupPath + "\\Error.txt" , ex .Message .ToString ( ) );
                  }
              }

          private void lblshowmixture_Click ( object sender , EventArgs e )
              {

              groupBox2 .Enabled = true;
              pnlaction .Enabled = false;
              this .Enabled = false;
              this .Cursor = Cursors .WaitCursor;
              if ( blnIsCheckMixture == false )
                  {
                  Conf .CheckMixture ( Width , Height );
                  blnIsCheckMixture = true;
                  }

              tabControl2 .SelectedIndex = 4;

              int intmax=0;

              foreach ( DictionaryEntry de1 in Conf.htStateStore)
                  {

                    if (Convert.ToInt16(de1.Value) > intmax)
                        {
                        intmax = Convert .ToInt16 ( de1 .Value );
                        strStatename = de1 .Key .ToString ( );
                        strcountmaxstate = de1 .Value .ToString ( );
                        }

                  }
              saveFileDialog1 .Title = "مسير فايل براي ذخيره اطلاعات تصوير";
              saveFileDialog1 .ShowDialog ( );
              if ( saveFileDialog1 .FileName != null )
                  {
                  Conf .WriteInf2File ( Conf .ri1 , saveFileDialog1 .FileName );
                  MessageBox .Show ( "اطلاعات تصوير شما در فايل ذخيره شد","فايل اطلاعات",MessageBoxButtons.OK,MessageBoxIcon.Information );
                  }
                  
              this .Enabled = true;
              this .Cursor = Cursors .Default;
              }

          private void lblshowseri_Click ( object sender , EventArgs e )
              {
              pnlaction .Enabled = false;
              Color_Ascendant ca1=new Color_Ascendant ( );
              ca1 .CreateTable ( alColorTeif );
              ca1.ShowDialog();
              }

          private void label5_Click ( object sender , EventArgs e )
              {
              pnlaction .Enabled = false;
              tabControl2 .SelectedIndex = 6;
              }

          private void tabPage3_Enter ( object sender , EventArgs e )
              {
              pnlaction .Enabled = true;
              }

          private void tabshowtable_Enter ( object sender , EventArgs e )
              {
              pnlaction .Enabled = false;
              }

          private void tabshowduplicate_Enter ( object sender , EventArgs e )
              {
              pnlaction .Enabled = false;
              }

          private void tabPage2_Enter ( object sender , EventArgs e )
              {
              pnlaction .Enabled = false;
              }

          private void lblshow_MouseMove ( object sender , MouseEventArgs e )
              {
              Label l1=sender as Label;
              l1 .Font = new Font ( "tahoma" , 9 , FontStyle .Bold );
              l1 .ForeColor = Color .YellowGreen;
              l1 .Left = 136;
              }

          private void lblshow_MouseLeave ( object sender , EventArgs e )
              {
              Label l1=sender as Label;
              l1 .Font = new Font ( "tahoma" , 9 , FontStyle .Regular );
              l1 .ForeColor = Color .White;
              l1 .Left = 152;
              }

          private void label57_Click ( object sender , EventArgs e )
              {

              }

          private void state5_MouseMove ( object sender , MouseEventArgs e )
              {
              PictureBox pc1=sender as PictureBox;
              pc1 .BorderStyle = BorderStyle .FixedSingle;
              }

          private void state5_MouseLeave ( object sender , EventArgs e )
              {
              PictureBox pc1=sender as PictureBox;
              pc1 .BorderStyle = BorderStyle .None;
              }

          private void state5_MouseDown ( object sender , MouseEventArgs e )
              {
              PictureBox pic1=sender as PictureBox;
              string strtag=pic1 .Tag .ToString ( );
              ShowMixtureInf smi1=new ShowMixtureInf ( );

              smi1 .StateCount = Conf .htStateStore [ strtag ].ToString();
              smi1 .StatePicture = pic1 .Image;
              smi1 .StateNumber = strtag;

              foreach (Control c1 in groupBox2.Controls)
              {
              if ( c1 is PictureBox && c1 .Tag.ToString() == strStatename )
                  {
                  PictureBox p1=c1 as PictureBox;
                  smi1 .MaxState = p1.Image;
                  smi1 .StateMaxCount = strcountmaxstate;
                  break;
                  }

              }
              smi1 .Add ( );
              smi1 .ShowDialog ( );
              }

          private void lblshow_Click ( object sender , EventArgs e )
              {

              this .Enabled = false;
              this .Cursor = Cursors .WaitCursor;
              ShowMixture frmsm1=new ShowMixture ( );
          
              if ( chk2 .Checked == true )
                  if ( txt1 .Text == "0" )
                      txt1 .Text = "50";

              frmsm1 .IntCountRow = int .Parse ( txt1 .Text );
              frmsm1 .Blngroup = chk2 .Checked;
              frmsm1 .ShowReport ( chk1 .Checked , 0 , frmsm1 .IntCountRow );
              frmsm1 .ShowDialog ( );
              this .Enabled = true;
              this .Cursor = Cursors .Arrow;

              }

          private void label63_Click ( object sender , EventArgs e )
              {
              ShowColorNumber scn1=new ShowColorNumber ( );
              scn1 .AddData ( );
              scn1 .Show ( );
              }

          private void mnushowpic_Click ( object sender , EventArgs e )
              {
              pb1 .Image = Image .FromFile ( Conf.strPath );
              }

          private void Form1_FormClosed ( object sender , FormClosedEventArgs e )
              {
              
              }

          private void Form1_FormClosing ( object sender , FormClosingEventArgs e )
              {
              e .Cancel = true;
              }

          private void chk2_CheckedChanged ( object sender , EventArgs e )
              {
              txt1 .Enabled = chk2 .Checked;
              btnsave .Enabled = true;
              }

          private void txt1_KeyPress ( object sender , KeyPressEventArgs e )
              {
              if ( !char .IsDigit ( e .KeyChar ) && !char .IsControl ( ( char ) Keys .Back ) )
                  e .Handled = true;
              }

          private void txt1_TextChanged ( object sender , EventArgs e )
              {
              if ( txt1 .Text == "" )
                  txt1 .Text = "0";
              }

          private void btnsave_Click ( object sender , EventArgs e )
              {
              Conf .SaveSetting ( "Only_Show_Repeat" , chk1 .Checked .ToString ( ) );
              Conf .SaveSetting ( "Show_Page_In_Page" , chk2 .Checked .ToString ( ) );
              Conf .SaveSetting ( "Count_Page" , txt1 .Text );
              Conf .SaveSetting ( "Show_Color_Table" , chk3.Checked.ToString() );
              MessageBox .Show ( "تنظيمات ذخيره شد" , "موفقيت" , MessageBoxButtons .OK , MessageBoxIcon .Information );
              btnsave .Enabled = false;
              }

          private void chk1_CheckedChanged ( object sender , EventArgs e )
              {
              btnsave .Enabled = true;
              }

          private void chk3_CheckedChanged ( object sender , EventArgs e )
              {
              btnsave .Enabled = true;
              }

          private void label72_Click ( object sender , EventArgs e )
              {
              Show_Color_Table sct1=new Show_Color_Table ( );
              sct1 .CreateTable ( ht2 );
              sct1 .Show ( );
              }
 

 
       

   

 






 
 

  

 
 

 
          

 
        }
    }
