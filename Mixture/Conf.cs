using System;
using System .Collections .Generic;
using System .ComponentModel;
using System .Data;
using System.Globalization;
using System .Drawing;
using System .Drawing .Imaging;
using System .Linq;
using System .Text;
using System .Windows .Forms;
using System.Collections;
using System.IO;
using System .Runtime .InteropServices;
using Microsoft .Win32;
using System .Security .Cryptography;

namespace Mixture
    {
    class Conf
        {

        #region State Variable Count
        /// <summary>
        /// Save State Mixture Count in Picture Color
        /// </summary>
        public static Hashtable htStateStore =new Hashtable ( );
        #endregion
        /// <summary>
             /// The Mixture Pixel Information Saved in This Structure
             /// </summary>
             /// <param name="x">Position X Pixel</param>
             /// <param name="y">Position Y Pixel</param>
             /// <param name="cl1">X Y Color</param>
             /// <param name="Number">Number Of State</param>
             /// <param name="mt2"State Name></param>
             /// <param name="ColorName">Color Name that is Mixture in Pixel</param>
        public struct MixtureInformation
            {
            public Color strColorName;
            public Image img1;

            public void AddInf (Color ColorName , Image img2)
                {
                strColorName = ColorName;
                img1 = img2;
                }
            }

        public static int iCountStatePosition = 0;
        public static int iRowNumber = 0;
        public static List<Color> myColors = new List<Color> ( );


        public struct RowInformation
            {
            public string sState1,sState2,sState3,sState4,sState5,sState6,sState7,sState8,sState9,sState10,sState11;
            }

        public struct MixturePostion
            {
            public int intx;
            public int inty;
            public int intNumberState;

            public void AddInf ( int X,int Y , int State )
                {
                intx = X;
                inty = Y;
                intNumberState = State;
                }

            }


        /// <summary>
        /// Return Mixture Color Type ( is 11 State )
        /// </summary>
        public enum MixtureType
             {

             Mx00_x11 = 1 ,

             Mx01_x10 = 2 ,

             Mx00_x10 = 3 ,

             Mx01_x11 = 4 ,

             Mx00_x01 = 5 ,

             Mx10_x11 = 6 ,

             Mx00_x01_x10 = 7 ,

             Mx00_x10_x11 = 8 ,

             Mx01_x10_x11 = 9 ,

             Mx00_x01_x11 = 10 ,

             Mx00_x01_x10_j11 = 11 ,

             MNone = 12

             }

        public static  MixturePostion[] mp1;
         
        public static MixtureInformation[] mi1;

        //Save Each Row Information ( Contain State,ColorName,Position )
        public static RowInformation[] ri1;

        public static  ArrayList arrPixelPostion=new ArrayList();

        public static int[] MixtureCount;

        public struct RGB
            {
            public int intR;
            public int intG;
            public int intB;

            public void Add ( int iR,int iG,int iB )
                {
                intR = iR;
                intG = iG;
                intB = iB;
                }
            }

        public static RGB[] RGB1,RGB2;
        public static int intk=0;  //For Save State Count (11 State)
        //This Save Color Duplicate Count and Color Name ( Color Information )
        public static Hashtable Colorinf  =  new Hashtable ( );  
       
        //Save All Pixel in Array n * n
        public static Color [ , ] dblpixel  ; 

        //Save Picture Path
        public static string strPath = "" ;

        //All Color Name Exist in Picture
        public static ArrayList arr1  =  new ArrayList(); 

        //Get Color Count Exists in Picture
        public static string strCountColor;

        
        /// <summary>
        /// Load All Pixel From Picture And Save It to Array n * n
        /// </summary>
        /// <param name="strpath">Picture Path That Loaded</param>
        /// <param name="frmname"> Form Name That Pixel Load it For Enable and Disable Form</param>
        /// <param name="intWidth ">Width Of Picture</param>
        /// <param name="intHeight">Height Of Picture</param>
        /// <param name="PB1"         > Picture That Show Process Of Load Pixel</param>
        public static void LoadPixel ( string strpath , Form frmname , int intWidth , int intHeight  , PictureBox PB1)
            {

            try
                {

                Bitmap bm1=new Bitmap ( strpath );
                Color color1;
                frmname .Enabled = false; //Disable Form until Subroutine Load Pixel
                frmname .Cursor = Cursors .WaitCursor; // Change Cursor to Waiting
                Conf .dblpixel = new Color [ intWidth , intHeight ]; //Determine Dimension Of dblpixel Array According to Picture Scale
                

                for ( int i = 0 ; i < intWidth ; i++ )
                    {
                    for ( int j = 0 ; j < intHeight ; j++ )
                        {
                        Conf .dblpixel [ i , j ] = bm1 .GetPixel ( i , j ); // Get Color of Pixel With X , Y
                        color1 = Conf .dblpixel [ i , j ]; //Save Color in color1 Var

                        //Show Process Of Load Pixel Like Progress Bar
                        SolidBrush sb1=new SolidBrush ( Color .MidnightBlue ); //Color Of Progress State
                        Graphics g1=PB1 .CreateGraphics ( );
                        g1 .FillRectangle ( sb1 , new Rectangle ( 0 , PB1 .Height - i , 20 , 20 ) ); // EachTime Draw Rectangle mean Progress bar is Loading

                        //--------------------------------------------------------------------------//--------------------------------------------------------------------------

                        string strname=color1 .Name .Substring ( 2 ); //the ff Character is Extra in Color,So Split ff From Color
                        Conf .arr1 .Add ( strname ); // Add Color Name into arr1 Var (Type : ArrayList)
                        }
                    }

                frmname .Enabled = true; // Until Load Pixel Finish,Form Enable
                frmname .Cursor = Cursors .Default; // Cursor Change to Default
                bm1 .Dispose ( );

                }

            catch ( Exception ex )
                {
                System .IO .File .AppendAllText ( Application .StartupPath + "\\Error.txt" , ex .Message .ToString ( ) );
                }
            }


        /// <summary>
        /// Get Color Name and Duplicate and Save it Into Hashtable from ArrayList (ArrayList Contain Color Name)
        /// </summary>
        /// <param name="araylist1">Contain Color Name From Picture</param>
        /// <returns>Count Colors That Repeated</returns>
        public static  Hashtable GetDuplicateValue ( ArrayList araylist1 )
            {
            Hashtable ht1=new Hashtable ( );
            int intp=1;

            Conf .Colorinf .Clear ( );

            try
                {
                /*Get All Duplicate Value in Array From Linq*/
                var query = 
                      from c in araylist1 .ToArray ( )
                      group c by c into g
                      where g .Count() >= 1
                      select new
                      {
                          Item = g .Key ,
                          ItemCount = g .Count ( )
                      };

                //Fetch All Colors that Repeated into Hash table
                foreach ( var item in query )
                    {
                    ht1 .Add ( item .Item , item .ItemCount );
                    Conf .Colorinf .Add ( item .Item , item .ItemCount );
                    myColors.Add(HexToColor(item.Item.ToString()));
                    ++intp;
                    }

                //Get All Color Exist in Picture
                --intp;
                strCountColor = intp .ToString ( );
                
                myColors .Sort ( delegate ( System .Drawing .Color left , System .Drawing .Color right )
                {
                    return left .GetBrightness ( ) .CompareTo ( right .GetBrightness ( ) );
                } );

                return ht1;
                }
            catch ( Exception ex )
                {
                System .IO .File .AppendAllText ( Application .StartupPath + "\\Error.txt" , ex .Message .ToString ( ) );
                return null;
                }

            }

        public static void GetDuplicateMixture ( ArrayList araylist1 )
            {

            int intp=0;
            MixtureCount = new int [ araylist1 .Count ];

            try
                {
                /*Get All Duplicate Value in Array From Linq*/
                var query = 
                      from c in araylist1 .ToArray ( )
                      group c by c into g
                      where g .Count ( ) >= 1
                      select new
                      {
                          Item = g .Key ,
                          ItemCount = g .Count ( )
                      };
                

                //Fetch All Colors that Repeated into Hash table
                foreach ( var item in query )
                    {
                    MixtureCount [ intp ] = item .ItemCount;
                    ++intp;
                    }
                }
            catch ( Exception ex )
                {
                System .IO .File .AppendAllText ( Application .StartupPath + "\\Error.txt" , ex .Message .ToString ( ) );
                }

            }

        public static void CheckMixture (int intWidth , int intHeight )
            {
            string[,] strcol=new string [ 2,2 ];
            mp1 = new MixturePostion [ intWidth * intHeight ];
            mi1 = new MixtureInformation [ intHeight * intWidth ];
 

            htStateStore .Clear ( );

            for ( int k = 1 ; k < 11 ; k++ )
                {
                htStateStore .Add ( k .ToString ( ) , "0" );      
                }

            ri1 = new RowInformation [ intHeight / 2 ];

            for ( int i = 0 ; i < intHeight  ; i +=2 )
                {
                for ( int j = 0 ; j < intWidth  ; j += 2 )
                    {
                    if ( j   !=   intWidth   &&   j % 2  ==  0 )
                        {
                        strcol [ 0 , 0 ] = Conf .dblpixel [ j , i ] .Name .Substring(2);
                        strcol [ 0 , 1 ] = Conf .dblpixel [ j + 1 , i ] .Name .Substring ( 2 );
                        strcol [ 1 , 0 ] = Conf .dblpixel [ j , i + 1 ] .Name  .Substring(2);
                        strcol [ 1 , 1 ] = Conf .dblpixel [ j + 1 , i + 1 ] .Name  .Substring(2);
                        ++iCountStatePosition;
                        IsMixture ( strcol , i , j );
                        }
                    else
                        {
                        strcol [ 0 , 0 ] = Conf .dblpixel [ j , i ] .Name .Substring ( 2 );
                        strcol [ 1 , 0 ] = Conf .dblpixel [ j , i + 1 ] .Name .Substring ( 2 );
                        strcol [ 1 , 1 ] = "0";
                        strcol [ 0 , 1 ] = "1";
                        ++iCountStatePosition;
                        IsMixture ( strcol , i , j );
                        }
                    }
                iCountStatePosition = 0;
                ++iRowNumber;
                }
            intk = 0;
            GetDuplicateMixture ( arrPixelPostion );
   
            }

        public static void WriteInf2File(RowInformation[] r1 , string sPath )
            {
            if ( File .Exists ( sPath ) )
                File .Delete ( sPath );
              for ( int i = 0 ; i <= r1.Length-1 ; i++)
                  {
                  
                         File .AppendAllText ( sPath , "Row " + i .ToString ( )  + "\r\n");
                      if ( r1 [ i ] .sState1 != null )
                         File .AppendAllText ( sPath , "State 1 is : " + r1 [ i ] .sState1 + "\r\n" );
                      if ( r1 [ i ] .sState2 != null )
                         File .AppendAllText ( sPath , "State 2 is : " + r1 [ i ] .sState2 + "\r\n" );
                      if ( r1 [ i ] .sState3 != null )
                         File .AppendAllText ( sPath , "State 3 is : " + r1 [ i ] .sState3 + "\r\n" );
                      if ( r1 [ i ] .sState4 != null )
                         File .AppendAllText ( sPath , "State 4 is : " + r1 [ i ] .sState4 + "\r\n" );
                      if ( r1 [ i ] .sState5 != null )
                         File .AppendAllText ( sPath , "State 5 is : " + r1 [ i ] .sState5 + "\r\n" );
                      if ( r1 [ i ] .sState6 != null )
                         File .AppendAllText ( sPath , "State 6 is : " + r1 [ i ] .sState6 + "\r\n" );
                      if ( r1 [ i ] .sState7 != null )
                         File .AppendAllText ( sPath , "State 7 is : " + r1 [ i ] .sState7 + "\r\n" );
                      if ( r1 [ i ] .sState8 != null )
                         File .AppendAllText ( sPath , "State 8 is : " + r1 [ i ] .sState8 + "\r\n" );
                      if ( r1 [ i ] .sState9 != null )
                         File .AppendAllText ( sPath , "State 9 is : " + r1 [ i ] .sState9 + "\r\n" );
                      if ( r1 [ i ] .sState10 != null )
                         File .AppendAllText ( sPath , "State 10 is : " + r1 [ i ] .sState10 + "\r\n" );
                      if ( r1 [ i ] .sState11 != null )
                         File .AppendAllText ( sPath , "State 11 is : " + r1 [ i ] .sState11 + "\r\n" );
                  }
            }
       
 
        public static void IsMixture(string[,] strPixel , int intX,int intY)
            {

            //Save Mixture Type
            MixtureType MixtureType1=MixtureType .MNone;
            Color ColorName=Color .Transparent;
            string[,] strMixture=new string [ 2 , 2 ];
            bool blnState4=false,blnState3=false;

            try
                {

                //For 4 Cell
                if ( (strPixel [ 0 , 0 ] == strPixel [ 0 , 1 ] && strPixel [ 0 , 0 ] == strPixel [ 1 , 0 ] && strPixel [ 0 , 0 ] == strPixel [ 1 , 1 ]) ||  ( strPixel [ 0 , 0 ] != strPixel [ 0 , 1 ] && strPixel [ 0 , 0 ] != strPixel [ 1 , 0 ] && strPixel [ 0 , 0 ] != strPixel [ 1 , 1 ]))

                    {
                    
                    MixtureType1 = MixtureType .Mx00_x01_x10_j11; //State 11
                    ColorName = HexToColor ( strPixel [ 0 , 0 ] .ToString ( ) );
                    Image img=Conf .GetPicture4Mixture (  HexToColor ( strPixel [ 0 , 0 ] .ToString ( ))  ,  HexToColor ( strPixel [ 0 , 1 ] .ToString ( )) ,  HexToColor ( strPixel [ 1 , 0 ] .ToString ( ) ) ,  HexToColor ( strPixel [ 1 , 1 ] .ToString ( ) ) );
                    mi1 [ intk ] .AddInf (ColorName , img );
                    mp1[intk++].AddInf(intX,intY, ( int ) MixtureType1);
                    arrPixelPostion .Add ( strPixel [ 0 , 0 ] + "," + strPixel [ 0 , 1 ] + "," + strPixel [ 1 , 0 ] + "," + strPixel [ 1 , 1 ] );
                    blnState4 = true;
                    int intp=Convert .ToInt16 ( htStateStore [ "11" ] );
                    htStateStore [ "11" ] = intp + 1;
                    
                    ri1 [ iRowNumber ] .sState11 += String .Format ( "{0} , " , iCountStatePosition  );
                    return;
                    }
                

                //For 3 Cell
                if ( blnState4 == false )
                    {

                    if ( strPixel [ 0 , 0 ] == strPixel [ 0 , 1 ] && strPixel [ 0 , 0 ] == strPixel [ 1 , 0 ] )
                        {

                        MixtureType1 = MixtureType .Mx00_x01_x10; //State 7
                        ColorName = HexToColor ( strPixel [ 0 , 0 ] .ToString ( ) );
                        Image img=Conf .GetPicture4Mixture ( HexToColor ( strPixel [ 0 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 0 , 1 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 1 ] .ToString ( ) ) );
                        mi1 [ intk ] .AddInf ( ColorName , img );
                        mp1 [ intk++ ] .AddInf ( intX , intY , ( int ) MixtureType1 );
                        arrPixelPostion .Add ( strPixel [ 0 , 0 ] + "," + strPixel [ 0 , 1 ] + "," + strPixel [ 1 , 0 ] + "," + strPixel [ 1 , 1 ] );
                        blnState3 = true;
                        int intp=Convert .ToInt16 ( htStateStore [ "7" ] );
                        htStateStore [ "7" ] = intp + 1;
                        ri1 [ iRowNumber ] .sState7 += String .Format ( "{0} , " , iCountStatePosition );
                        return;
                        }

                    if ( strPixel [ 0 , 0 ] == strPixel [ 1 , 0 ] && strPixel [ 0 , 0 ] == strPixel [ 1 , 1 ] )
                        {

                        MixtureType1 = MixtureType .Mx00_x10_x11; //State 8
                        ColorName = HexToColor ( strPixel [ 0 , 0 ] .ToString ( ) );
                        Image img=Conf .GetPicture4Mixture ( HexToColor ( strPixel [ 0 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 0 , 1 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 1 ] .ToString ( ) ) );
                        mi1 [ intk ] .AddInf ( ColorName , img );
                        mp1 [ intk++ ] .AddInf ( intX , intY , ( int ) MixtureType1 );
                        arrPixelPostion .Add ( strPixel [ 0 , 0 ] + "," + strPixel [ 0 , 1 ] + "," + strPixel [ 1 , 0 ] + "," + strPixel [ 1 , 1 ] );
                        blnState3 = true;
                        int intp=Convert .ToInt16 ( htStateStore [ "8" ] );
                        htStateStore [ "8" ] = intp + 1;
                        ri1 [ iRowNumber ] .sState8 += String .Format ( "{0} , " , iCountStatePosition );
                        return;
                        }

                    if ( strPixel [ 0 , 1 ] == strPixel [ 1 , 0 ] && strPixel [ 0 , 1 ] == strPixel [ 1 , 1 ] )
                        {

                        MixtureType1 = MixtureType .Mx01_x10_x11; //State 9
                        ColorName = HexToColor ( strPixel [ 0 , 1 ] .ToString ( ) );
                        Image img=Conf .GetPicture4Mixture ( HexToColor ( strPixel [ 0 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 0 , 1 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 1 ] .ToString ( ) ) );
                        mi1 [ intk ] .AddInf ( ColorName , img );
                        mp1 [ intk++ ] .AddInf ( intX , intY , ( int ) MixtureType1 );
                        arrPixelPostion .Add ( strPixel [ 0 , 0 ] + "," + strPixel [ 0 , 1 ] + "," + strPixel [ 1 , 0 ] + "," + strPixel [ 1 , 1 ] );
                        blnState3 = true;
                        int intp=Convert .ToInt16 ( htStateStore [ "9" ] );
                        htStateStore [ "9" ] = intp + 1;
                        ri1 [ iRowNumber ] .sState9 += String .Format ( "{0} : {1} ; " , "{0} , " , iCountStatePosition );
                        return;
                        }

                    if ( strPixel [ 0 , 0 ] == strPixel [ 0 , 1 ] && strPixel [ 0 , 0 ] == strPixel [ 1 , 1 ] )
                        {

                        MixtureType1 = MixtureType .Mx00_x01_x11; //State 10
                        ColorName = HexToColor ( strPixel [ 0 , 0 ] .ToString ( ) );
                        Image img=Conf .GetPicture4Mixture ( HexToColor ( strPixel [ 0 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 0 , 1 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 1 ] .ToString ( ) ) );
                        mi1 [ intk ] .AddInf ( ColorName , img );
                        mp1 [ intk++ ] .AddInf ( intX , intY , ( int ) MixtureType1 );
                        arrPixelPostion .Add ( strPixel [ 0 , 0 ] + "," + strPixel [ 0 , 1 ] + "," + strPixel [ 1 , 0 ] + "," + strPixel [ 1 , 1 ] );
                        blnState3 = true;
                        int intp=Convert .ToInt16 ( htStateStore [ "10" ] );
                        htStateStore [ "10" ] = intp + 1;
                        ri1 [ iRowNumber ] .sState10 += String .Format ( "{0} , " , iCountStatePosition );
                        return;
                        }
                    
                    }
                else
                    blnState3 = true;

                //For 2 Cell
                if ( blnState3 == false )
                    {
                   
                    if ( strPixel [ 0 , 0 ] == strPixel [ 1 , 1 ] )
                      
                        {

                        //For Prevent From Several State
                        //Example: maybe in State 9,State 6 and 4 Selected

                        MixtureType1 = MixtureType .Mx00_x11; // State 1
                        ColorName = HexToColor ( strPixel [ 0 , 0 ] .ToString ( ) );
                        Image img=Conf .GetPicture4Mixture ( HexToColor ( strPixel [ 0 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 0 , 1 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 1 ] .ToString ( ) ) );
                        mi1 [ intk ] .AddInf ( ColorName , img );
                        mp1 [ intk++ ] .AddInf ( intX , intY , ( int ) MixtureType1 );
                        arrPixelPostion .Add ( strPixel [ 0 , 0 ] + "," + strPixel [ 0 , 1 ] + "," + strPixel [ 1 , 0 ] + "," + strPixel [ 1 , 1 ] );
                        int intp=Convert .ToInt16 ( htStateStore [ "1" ] );
                        htStateStore [ "1" ] = intp + 1;
                        ri1 [ iRowNumber ] .sState1 += String .Format ( "{0} , " , iCountStatePosition );
                        return;
                        }

                    if ( strPixel [ 0 , 1 ] == strPixel [ 1 , 0 ] )
                       
                        {

                        MixtureType1 = MixtureType .Mx01_x10;    //State 2
                        ColorName = HexToColor ( strPixel [ 0 , 1 ] .ToString ( ) );
                        Image img=Conf .GetPicture4Mixture ( HexToColor ( strPixel [ 0 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 0 , 1 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 1 ] .ToString ( ) ) );
                        mi1 [ intk ] .AddInf ( ColorName , img );
                        mp1 [ intk++ ] .AddInf ( intX , intY , ( int ) MixtureType1 );
                        arrPixelPostion .Add ( strPixel [ 0 , 0 ] + "," + strPixel [ 0 , 1 ] + "," + strPixel [ 1 , 0 ] + "," + strPixel [ 1 , 1 ] );
                        int intp=Convert .ToInt16 ( htStateStore [ "2" ] );
                        htStateStore [ "2" ] = intp + 1;
                        ri1 [ iRowNumber ] .sState2 += String .Format ( "{0} , " , iCountStatePosition );
                        return;
                        }

                    if ( strPixel [ 0 , 0 ] == strPixel [ 1 , 0 ] )
                      
                        {

                        MixtureType1 = MixtureType .Mx00_x10; //State 3
                        ColorName = HexToColor ( strPixel [ 0 , 0 ] .ToString ( ) );
                        Image img=Conf .GetPicture4Mixture ( HexToColor ( strPixel [ 0 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 0 , 1 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 1 ] .ToString ( ) ) );
                        mi1 [ intk ] .AddInf ( ColorName , img );
                        mp1 [ intk++ ] .AddInf ( intX , intY , ( int ) MixtureType1 );
                        arrPixelPostion .Add ( strPixel [ 0 , 0 ] + "," + strPixel [ 0 , 1 ] + "," + strPixel [ 1 , 0 ] + "," + strPixel [ 1 , 1 ] );
                        int intp=Convert .ToInt16 ( htStateStore [ "3" ] );
                        htStateStore [ "3" ] = intp + 1;
                        ri1 [ iRowNumber ] .sState3 += String .Format ( "{0} , " , iCountStatePosition );
                        return;
                        }

                    if ( strPixel [ 0 , 1 ] == strPixel [ 1 , 1 ] )
                     
                        {

                        MixtureType1 = MixtureType .Mx01_x11; //State 4
                        ColorName = HexToColor ( strPixel [ 0 , 1 ] .ToString ( ) );
                        Image img=Conf .GetPicture4Mixture ( HexToColor ( strPixel [ 0 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 0 , 1 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 1 ] .ToString ( ) ) );
                        mi1 [ intk ] .AddInf ( ColorName , img );
                        mp1 [ intk++ ] .AddInf ( intX , intY , ( int ) MixtureType1 );
                        arrPixelPostion .Add ( strPixel [ 0 , 0 ] + "," + strPixel [ 0 , 1 ] + "," + strPixel [ 1 , 0 ] + "," + strPixel [ 1 , 1 ] );
                        int intp=Convert .ToInt16 ( htStateStore [ "4" ] );
                        htStateStore [ "4" ] = intp + 1;
                        ri1 [ iRowNumber ] .sState4 += String .Format ( "{0} , " , iCountStatePosition );
                        return;
                        }

                    if ( strPixel [ 0 , 0 ] == strPixel [ 0 , 1 ] )
                      
                        {

                        MixtureType1 = MixtureType .Mx00_x01; //State 5
                        ColorName = HexToColor ( strPixel [ 0 , 0 ] .ToString ( ) );
                        Image img=Conf .GetPicture4Mixture ( HexToColor ( strPixel [ 0 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 0 , 1 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 1 ] .ToString ( ) ) );
                        mi1 [ intk ] .AddInf ( ColorName , img );
                        mp1 [ intk++ ] .AddInf ( intX , intY , ( int ) MixtureType1 );
                        arrPixelPostion .Add ( strPixel [ 0 , 0 ] + "," + strPixel [ 0 , 1 ] + "," + strPixel [ 1 , 0 ] + "," + strPixel [ 1 , 1 ] );
                        int intp=Convert .ToInt16 ( htStateStore [ "5" ] );
                        htStateStore [ "5" ] = intp + 1;
                        ri1 [ iRowNumber ] .sState5 += String .Format ( "{0} , " , iCountStatePosition );
                        return;
                        }

                    if ( strPixel [ 1 , 0 ] == strPixel [ 1 , 1 ] )
                     
                        {

                        MixtureType1 = MixtureType .Mx10_x11; //State 6
                        ColorName = HexToColor ( strPixel [ 1 , 0 ] .ToString ( ) );
                        Image img=Conf .GetPicture4Mixture ( HexToColor ( strPixel [ 0 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 0 , 1 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 0 ] .ToString ( ) ) , HexToColor ( strPixel [ 1 , 1 ] .ToString ( ) ) );
                        mi1 [ intk ] .AddInf ( ColorName , img );
                        mp1 [ intk++ ] .AddInf ( intX , intY , ( int ) MixtureType1 );
                        arrPixelPostion .Add ( strPixel [ 0 , 0 ] + "," + strPixel [ 0 , 1 ] + "," + strPixel [ 1 , 0 ] + "," + strPixel [ 1 , 1 ] );
                        int intp=Convert .ToInt16 ( htStateStore [ "6" ] );
                        htStateStore [ "6" ] = intp + 1;
                        ri1 [ iRowNumber ] .sState6 += String .Format ( "{0} , " , iCountStatePosition );
                        return;
                        }


                    }
                //-----------------------------------------------------------------------------------------------------------------------------------

              

                //-----------------------------------------------------------------------------------------------------------------------------------
                

                }
            catch ( Exception ex )
                {
                System .IO .File .AppendAllText ( Application .StartupPath + "\\Error.txt" , ex .Message .ToString ( ) );
                }

            }


 
           public static Image GetPicture4Mixture(Color p00,Color p01,Color p10,Color p11)
               {
               Bitmap b1=new Bitmap ( 40 , 40 );
               Graphics g1=Graphics .FromImage ( (Image) b1 );
               g1 .FillRectangle ( new SolidBrush ( Color .Black ) , new Rectangle ( 0 , 0 , 40 , 40 ) );
               g1 .FillRectangle ( new SolidBrush ( p00 ) , 1 , 1 , 20 , 20 );
               g1 .FillRectangle ( new SolidBrush ( p01 ) , 20 , 1 , 20 , 40 );
               g1 .FillRectangle ( new SolidBrush ( p10 ) , 1 , 20 , 20 , 40 );
               g1 .FillRectangle ( new SolidBrush ( p11 ) , 20 , 20 , 40 , 40 );
               g1 .Save ( );
               g1 .Dispose ( );
               
               return (Image) b1;

               }


 

           #region Register
           public static string GetRegister ( string strkey )
               {
               RegistryKey reg1 = Registry .CurrentUser .OpenSubKey ( "Student_Software" );

               try
                   {
                   string s1 = reg1 .GetValue ( strkey ) .ToString ( );
                   return s1;
                   }
               catch ( Exception )
                   {
                   return "0";
                   }

               }

           public static void SaveSetting ( string strValueName , string strVal )
               {
               try
                   {
                   Microsoft .Win32 .Registry .SetValue ( "HKEY_CURRENT_USER\\Student_Software" , strValueName , strVal );
                   }
               catch ( Exception )
                   {
                   Microsoft .Win32 .Registry .CurrentUser .CreateSubKey ( "Student_Software" );
                   }
               }

           #endregion

           #region Convertor
           public static Color HexToColor ( string hexColor )
               {

               if ( hexColor .IndexOf ( '#' ) != -1 )
                   hexColor = hexColor .Replace ( "#" , "" );
               int red = 0;
               int green = 0;
               int blue = 0;
               if ( hexColor .Length == 6 )
                   {         //#RRGGBB14.             
                   red = int .Parse ( hexColor .Substring ( 0 , 2 ) , NumberStyles .AllowHexSpecifier );
                   green = int .Parse ( hexColor .Substring ( 2 , 2 ) , NumberStyles .AllowHexSpecifier );
                   blue = int .Parse ( hexColor .Substring ( 4 , 2 ) , NumberStyles .AllowHexSpecifier );
                   }
               else if ( hexColor .Length == 3 )
                   {            //#RGB21.     
                   red = int .Parse ( hexColor [ 0 ] .ToString ( ) + hexColor [ 0 ] .ToString ( ) , NumberStyles .AllowHexSpecifier );
                   green = int .Parse ( hexColor [ 1 ] .ToString ( ) + hexColor [ 1 ] .ToString ( ) , NumberStyles .AllowHexSpecifier );
                   blue = int .Parse ( hexColor [ 2 ] .ToString ( ) + hexColor [ 2 ] .ToString ( ) , NumberStyles .AllowHexSpecifier );
                   }
               return Color .FromArgb ( red , green , blue );
               }
           public static DataTable ConvertHastTableToDataTable ( System .Collections .Hashtable hashtable )
               {

               var dt1 = new DataTable ( hashtable .GetType ( ) .Name );
               int inti=1;
               dt1 .Columns .Add ( "رديف" );
               dt1 .Columns .Add ( "شماره رنگ" );
               dt1 .Columns .Add ( "تعداد تکرار" );
               dt1 .Columns .Add ( "رنگ" );

               IDictionaryEnumerator enumerator = hashtable .GetEnumerator ( );
               while ( enumerator .MoveNext ( ) )
                   {
                   dt1 .Rows .Add ( inti , enumerator .Key , enumerator .Value , "" );
                   ++inti;
                   }
               return dt1;
               }
           #endregion
        }
}
