using System;
using System .Collections .Generic;
using System .ComponentModel;
using System .Data;
using System .Drawing;
using System .Linq;
using System .Text;
using System .Windows .Forms;

namespace Mixture
    {
    public partial class Login : Form
        {
        Form1 frm1=new Form1 ( );

        public Login ( )
            {
            InitializeComponent ( );
            }

        private void Login_Load ( object sender , EventArgs e )
            {
            if ( key_Software1 .GetRegister ( ) )
                {
                
                frm1 .Show ( );
                this .Dispose ( false );
                }
            }

        private void key_Software1_Load(object sender, EventArgs e)
        {

        }
        }
    }
