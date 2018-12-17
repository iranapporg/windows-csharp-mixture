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
    public partial class ShowInf : Form
        {

        public ShowInf ( )
            {
            InitializeComponent ( );
            }
        public string Bright
            {
            set
                {
                txtbright .Text = value;
                }
            }

        public string Hue
            {
            set
                {
                txthue .Text = value;
                }
            }
        public string Sat
            {
            set
                {
                txtsat.Text = value;
                }
            }
        public string ReapetCount
            {
            set
                {
                txtreapet .Text = value;
                }
            }
        public string ColorId
            {
            set
                {
                txtid.Text= value.ToString();
                }
            }
        public string ColorNumber
            {
            set
                {
                 txtnumber.Text= value.ToString();
                }
            }
        public Color ColorName
            {
            set
                {
                pic1.BackColor = value;
                }
            }
        public string R
            {
            set
                {
                txtr.Text = value.ToString();
                }
            }

        public string G
            {
            set
                {
                txtg.Text = value.ToString();
                }
            }
        public string B
            {
            set
                {
                txtb.Text = value.ToString();
                }
            }
        }
    }
