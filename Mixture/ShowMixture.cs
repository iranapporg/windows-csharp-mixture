using System;
using System .Collections .Generic;
using System .ComponentModel;
using System .Data;
using System .Drawing;
using System .Linq;
using System .Text;
using System .Windows .Forms;
using System .Collections;
using System.IO;
using System .Media;
using System.Threading;

namespace Mixture
    {
    public partial class ShowMixture : Form
        {
        public ShowMixture ( )
            {
            InitializeComponent ( );
            }
        int intcurrentrow=0;
        bool blna=false,blngroup=false;

        public bool Blngroup
            {
            get
                {
                return blngroup;
                }
            set
                {
                blngroup = value;
                }
            }

        int intCountRow=3;

        public int IntCountRow
            {
            get
                {
                return intCountRow;
                }
            set
                {
                intCountRow = value;
                }
            }


        public void ShowReport(bool stateshow,int intOffset,int intEnd)
            {
            int intRadif;
            int intStatecode;
            Image imgp;
            string strMCount;
            string strColorName;
            string strPos;
            string strColorNumber;
            DataTable dt1=new DataTable ( "Mixture" );
            int intp=1;
            string strStateCode="";
            int Offset=0,End=0;
            dt1 .Columns .Add ( "رديف" );
            dt1 .Columns .Add ( "کد حالت" );
            dt1.Columns.Add("پيکسل",typeof(Image));
            dt1 .Columns .Add ( "تعداد تکرار" );
            dt1 .Columns .Add ( "کد رنگ" );
            dt1 .Columns .Add ( "رنگ");
            dt1 .Columns .Add ( "مختصات" );
            dt1 .Columns .Add ( "شماره رنگ" );
            
            SoundPlayer sp1 = new SoundPlayer ( );
            sp1 .SoundLocation = Application .StartupPath + "\\tick.wav";
            sp1 .Play ( );

            intcurrentrow = intOffset;
            Offset = intOffset;

            if ( intEnd != 0 )
                End = intEnd;
            else
                End = Conf .mi1 .Length - 1;
              
 
            for ( int i = Offset ; i < End; i++ )
                {

                strStateCode = ( ( int ) Conf .mp1 [ i ] .intNumberState ) .ToString ( );

                if ( Convert.ToInt16(strStateCode) != 0 )
                    {

                    //Data that must insert into Datatable
                    intRadif = i + 1;
                    imgp = Conf .mi1 [ i ] .img1;
                    strMCount = Conf .MixtureCount [ i ] .ToString ( );
                    strColorName =Conf .mi1 [ i ] .strColorName .Name .Substring ( 2 ) .ToString();
                    strPos = String .Format ( "( {0} , {1} )" , Conf .mp1 [ i ] .inty .ToString ( ) , Conf .mp1 [ i ] .intx .ToString ( ) );
                    strColorNumber = ( ( ( int ) ShowColor .ht2 [ Conf .mi1 [ i ] .strColorName .Name .Substring ( 2 ) ] ) + 1 ) .ToString ( );
                    //////////////////////////////////////////////////////////////////////////
                    if ( stateshow == false )
                        {
                        if ( txt1 .Text == "" )
                            dt1 .Rows .Add ( ( intRadif ) .ToString ( ) , strStateCode , imgp , strMCount , strColorName , "" , strPos , strColorNumber );
                        else
                            {
                            if ( strColorName == txt1 .Text )
                                dt1 .Rows .Add ( ( intRadif ) .ToString ( ) , strStateCode , imgp , strMCount , strColorName , "" , strPos , strColorNumber );
                            }
                        }
                    else
                        if ( int .Parse ( strMCount ) > 1 )
                            dt1 .Rows .Add ( ( intRadif ) .ToString ( ) , strStateCode , imgp , strMCount , strColorName , "" , strPos , strColorNumber );

                    Application .DoEvents ( );
                    }

                }
            sp1 .Stop ( );  
            dataGridView1 .DataSource = dt1;
            DataGridSetting ( );
            if ( intCountRow == 0 )
                txtcount .Text = ( Conf .mi1 .Length / 2 ) .ToString ( );
            else
                txtcount .Text = ( Conf .mi1 .Length / intCountRow ) .ToString ( );
            //////////////////////////////////////////////////////////////////////////

            }


        private void DataGridSetting ( )
            {

                    dataGridView1.Columns [ "رديف" ] .Width = 40;
                    dataGridView1 .Columns [ "رنگ" ] .Width = 40;
                    dataGridView1 .Columns [ "کد حالت" ] .Width = 50;
                    dataGridView1 .Columns [ "کد رنگ" ] .Width = 70;
                    dataGridView1 .Columns [ "تعداد تکرار" ] .Width = 70;
                    dataGridView1 .Columns [ "مختصات" ] .Width = 60;
                    dataGridView1 .Columns [ "پيکسل" ] .Width = 55;
                    dataGridView1 .ColumnHeadersDefaultCellStyle .Alignment = DataGridViewContentAlignment .MiddleCenter;

                    for ( int i = 0 ; i < 8 ; i ++)
                        {
                        dataGridView1 .Columns [ i ] .DefaultCellStyle .Alignment = DataGridViewContentAlignment .MiddleCenter;       
                        }
 
            }


        private void ShowMixture_Resize ( object sender , EventArgs e )
            {
 
            }

        private void btn1_Click ( object sender , EventArgs e )
            {
            if (txt1.Text != "")
                 ShowReport ( false,0,0);

            }

        private void dataGridView1_RowsAdded ( object sender , DataGridViewRowsAddedEventArgs e )
            {
            for ( int j = 0 ; j < dataGridView1 .Rows .Count ; j++ )
                {
                Color cl1=Conf .HexToColor ( dataGridView1 .Rows [ j ] .Cells [ 4 ] .Value .ToString ( ) );
                dataGridView1 .Rows [ j ] .Cells [ 5 ] .Style .BackColor = cl1;
                dataGridView1 .Invalidate ( );
                this .Invalidate ( );
                }
            }

        private void txt3_KeyPress ( object sender , KeyPressEventArgs e )
            {
            if ( !char .IsDigit ( e .KeyChar ) && !char .IsControl ( ( char ) Keys .Back ) )
                e .Handled = true;
            }

        private void rb3_CheckedChanged ( object sender , EventArgs e )
            {
            txt3 .Enabled = rb3 .Checked;
            picgo .Enabled = rb3 .Checked;
            }

        private void rb1_CheckedChanged ( object sender , EventArgs e )
            {
            picnext .Enabled = rb1 .Checked;
            }

        private void rb2_CheckedChanged ( object sender , EventArgs e )
            {
            picback .Enabled = rb2 .Checked;
            }

        private void picnext_Click ( object sender , EventArgs e )
            {
            if ( intcurrentrow > Conf .mi1 .Length || intcurrentrow + intCountRow > Conf .mi1 .Length )
                {
                intcurrentrow = 0;
                return;
                }
                int intp= intcurrentrow + intCountRow;
                ShowReport ( false , intcurrentrow , intp );
                intcurrentrow += intCountRow;
                txt4 .Text = intcurrentrow .ToString ( );
                rb1 .Checked = true;
          
            }

        private void picback_Click ( object sender , EventArgs e )
            {
            if (intcurrentrow < 0 || intcurrentrow - intCountRow < 0 )
                {
                intcurrentrow=0;
                return;
                }
            int intp= intcurrentrow - intCountRow;
            ShowReport ( false , intp, intcurrentrow );
            txt4 .Text = intcurrentrow .ToString ( );
            rb2 .Checked = true;
            }

        private void picgo_Click ( object sender , EventArgs e )
            {

            }

        private void picgo_Click_1 ( object sender , EventArgs e )
            {
            if (txt3.Text != "")
                {
                ShowReport ( false , int .Parse ( txt3 .Text ) , intCountRow + int .Parse ( txt3 .Text ) );
                }
            rb3 .Checked = true;
            }


 
        }
    }
