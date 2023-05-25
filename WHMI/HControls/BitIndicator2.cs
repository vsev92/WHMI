using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace WHMI.HControls
{
    public class BitIndicator2 : System.Windows.Controls.Image
    {
        static BitIndicator2()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BitIndicator2), new FrameworkPropertyMetadata(typeof(BitIndicator2)));

        }
        public BitIndicator2()
        {
          /*  try
            {*/
                Switcher = new LooklessIndicator(ImageOnPath, ImageOffPath);
                this.Source = Switcher.ImageCurrent;
           // }
          /*  catch(Exception e)
            {
                MessageBox.Show(e.Message);
                ImageOnPath = new Uri(@"D:\WORK\SCADA\WHMI\WHMI\WHMI\green_open.bmp");
                ImageOffPath = new Uri(@"D:\WORK\SCADA\WHMI\WHMI\WHMI\green_close.png");
                Switcher = new LooklessIndicator(ImageOnPath, ImageOffPath);
            }*/
            
            
        }

        public LooklessIndicator Switcher;


        public static readonly DependencyProperty StatusBitProperty = DependencyProperty.Register(
        "StatusBit", typeof(bool),
        typeof(BitIndicator2), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnStatusBitChange)));


        public bool StatusBit
        {
            get
            {

                return (bool)GetValue(StatusBitProperty);

            }
            set
            {
                SetValue(StatusBitProperty, value);


            }
        }

        private static void OnStatusBitChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ind = (BitIndicator2)d;
            ind.Switcher.StatusBitTag=ind.StatusBit;
            ind.Source = ind.Switcher.ImageCurrent;
            
        }
     


        public static readonly DependencyProperty ImageOnPathProperty =
        DependencyProperty.Register("ImageOnPath",
        typeof(Uri), typeof(BitIndicator2),
        new FrameworkPropertyMetadata(new PropertyChangedCallback(OnImageOnPathChanged)));

        public static readonly DependencyProperty ImageOffPathProperty =
        DependencyProperty.Register("ImageOffPath",
        typeof(Uri), typeof(BitIndicator2),
        new FrameworkPropertyMetadata(new PropertyChangedCallback(OnImageOffPathChanged)));



        public Uri ImageOnPath
        {
            get => (Uri)GetValue(ImageOnPathProperty);
            set => SetValue(ImageOnPathProperty, value);
        }

        public Uri ImageOffPath
        {
            get => (Uri)GetValue(ImageOffPathProperty);
            set => SetValue(ImageOffPathProperty, value);
        }

        private static void OnImageOnPathChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

            BitIndicator2 ctrl = (BitIndicator2)sender;
            
           
            ctrl.Switcher.ImageOn = new BitmapImage(ctrl.ImageOnPath);

            ctrl.Source = ctrl.Switcher.ImageCurrent;
        }
        private static void OnImageOffPathChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

            BitIndicator2 ctrl = (BitIndicator2)sender;


            ctrl.Switcher.ImageOff= new BitmapImage(ctrl.ImageOffPath);

            ctrl.Source = ctrl.Switcher.ImageCurrent;
        }


    }
}
