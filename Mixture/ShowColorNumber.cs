using System;
using System .Collections .Generic;
using System .ComponentModel;
using System .Data;
using System .Drawing;
using System .Linq;
using System .Text;
using System .Windows .Forms;
using System .Collections;

namespace Mixture
    {
    public partial class ShowColorNumber : Form
        {
        public ShowColorNumber ( )
            {
            InitializeComponent ( );
            }
        public void AddData()
            {
            DataTable dt1=new DataTable ( );
            dt1 .Columns .Add ( "شماره رنگ" );
            dt1 .Columns .Add ( "کد رنگ" );
            dt1 .Columns .Add ( "رنگ" );
            foreach (DictionaryEntry de1 in ShowColor.ht2)
            {
            dt1 .Rows .Add ( (( (int)(de1 .Value))+1).ToString()  , de1 .Key .ToString ( ) , "" );
            }
            dataGridView1 .DataSource = dt1;
            
            }

        private void dataGridView1_RowsAdded ( object sender , DataGridViewRowsAddedEventArgs e )
            {
            Color c1;
            DataGridView data1=sender as DataGridView;

            try
                {
                for ( int i = 0 ; i < data1 .Rows .Count ; i++ )
                    {
                    string str1=data1 .Rows [ i ] .Cells [ 1 ] .Value .ToString ( );
                    c1 = Conf .HexToColor ( str1 );
                    data1 .Rows [ i ] .Cells [ 2 ] .Style .BackColor = c1;

                    }
                    
                }
            catch ( Exception ex )
                {
                System .IO .File .AppendAllText ( Application .StartupPath + "\\Error.txt" , ex .Message .ToString ( ) );
                }
            }
        }
    }
