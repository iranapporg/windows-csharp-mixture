using System;
using System .Collections .Generic;
using System .Linq;
using System.Drawing;
using System .Text;

namespace Mixture
    {
    public class HSLColor
        {
        public Double Hue;
        public Double Saturation;
        public Double Luminosity;

        public HSLColor ( Double H , Double S , Double L )
            {
            Hue = H;
            Saturation = S;
            Luminosity = L;
            }

        public static HSLColor FromRGB ( Color Clr )
            {
            return FromRGB ( Clr .R , Clr .G , Clr .B );
            }

        public static HSLColor FromRGB ( Byte R , Byte G , Byte B )
            {
            Double _R = ( R / 255d );
            Double _G = ( G / 255d );
            Double _B = ( B / 255d );

            Double _Min = Math .Min ( Math .Min ( _R , _G ) , _B );
            Double _Max = Math .Max ( Math .Max ( _R , _G ) , _B );
            Double _Delta = _Max - _Min;

            Double H = 0;
            Double S = 0;
            Double L = ( float ) ( ( _Max + _Min ) / 2.0f );

            if ( _Delta != 0 )
                {
                if ( L < 0.5d )
                    {
                    S = ( float ) ( _Delta / ( _Max + _Min ) );
                    }
                else
                    {
                    S = ( float ) ( _Delta / ( 2.0f - _Max - _Min ) );
                    }


                if ( _R == _Max )
                    {
                    H = ( _G - _B ) / _Delta;
                    }
                else if ( _G == _Max )
                    {
                    H = 2f + ( _B - _R ) / _Delta;
                    }
                else if ( _B == _Max )
                    {
                    H = 4f + ( _R - _G ) / _Delta;
                    }
                }

            //Convert to degrees 
            H = H * 60d;
            if ( H < 0 )
                H += 360;
            //Convert to percent 
            S *= 100d;
            L *= 100d;

            return new HSLColor ( H , S , L );
            }

        }
    }