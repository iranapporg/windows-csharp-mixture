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
    public partial class Show_Color_Table : Form
        {
        public Show_Color_Table ( )
            {
            InitializeComponent ( );
            }
        public void CreateTable(Hashtable ht1)
            {
            showColor .PixelColor = ht1;
            showColor .CreateColor ( );
            }
        }
    }
