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
    public partial class Color_Ascendant : Form
        {
        public Color_Ascendant ( )
            {
            InitializeComponent ( );
            }
        public void CreateTable ( Hashtable ht1 )
            {
            showColor1 .PixelColor = ht1;
            showColor1 .CreateColor ( );
            }
        }
    }
