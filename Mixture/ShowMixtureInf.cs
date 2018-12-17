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
    public partial class ShowMixtureInf : Form
        {
        public ShowMixtureInf ( )
            {
            InitializeComponent ( );
            }
        Image i1=null;
        string intcount;
        string intnumber;
        Image i2=null;

        public void Add()
            {
            txtcount .Text = intcount;
            state .Image = i1;
            pb2 .Image = i2;
            lblstate .Text = intnumber;
            }
        public Image StatePicture
            {
            set
                {
                 i1= value;
                }

            }

        public string StateMaxCount
            {
            set
                {
                txtcoutnmax .Text = value;
                }
            }
        public string StateCount
            {
            set
                {
                intcount = value;
                }
            }

        public string StateNumber
            {

            set
                {
                intnumber = value;
                }
            }

        public Image MaxState
            {
            set
                {
                i2 = value;
                }
            }
        }
    }
