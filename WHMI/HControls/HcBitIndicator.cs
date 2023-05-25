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
    /// <summary>
    /// Выполните шаги 1a или 1b, а затем 2, чтобы использовать этот пользовательский элемент управления в файле XAML.
    ///
    /// Шаг 1a. Использование пользовательского элемента управления в файле XAML, существующем в текущем проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WHMI.HControls"
    ///
    ///
    /// Шаг 1б. Использование пользовательского элемента управления в файле XAML, существующем в другом проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WHMI.HControls;assembly=WHMI.HControls"
    ///
    /// Потребуется также добавить ссылку из проекта, в котором находится файл XAML,
    /// на данный проект и пересобрать во избежание ошибок компиляции:
    ///
    ///     Щелкните правой кнопкой мыши нужный проект в обозревателе решений и выберите
    ///     "Добавить ссылку"->"Проекты"->[Поиск и выбор проекта]
    ///
    ///
    /// Шаг 2)
    /// Теперь можно использовать элемент управления в файле XAML.
    ///
    ///     <MyNamespace:HcBitIndicator/>
    ///
    /// </summary>
    public class HcBitIndicator :System.Windows.Controls.Image
    {
       
        static HcBitIndicator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HcBitIndicator), new FrameworkPropertyMetadata(typeof(HcBitIndicator)));

            //    FrameworkPropertyMetadata newSourceMetadata = new(
            //    defaultValue: new BitmapImage(new Uri(@"D:\WORK\SCADA\WHMI\WHMI\HMI_pic\valve_01h\valve_01h_flt_cls.bmp")));
            //    SourceProperty.OverrideMetadata(forType: typeof(System.Windows.Controls.Image), typeMetadata: newSourceMetadata);
            
        }
        public HcBitIndicator()
        {

          
            ImageOn = new BitmapImage(ImageOnPath);
            ImageOff = new BitmapImage(ImageOffPath);
           

        }

        ImageSource imageOff;
        ImageSource imageOn;
        public ImageSource ImageOff
        {
            get { return imageOff; }
            set 
            {
                imageOff = value;
                this.ShowState();
            }
        }
        public ImageSource ImageOn
        {
            get { return imageOn; }
            set 
            { 
                imageOn = value;
                this.ShowState();
            }
        }


       public static readonly DependencyProperty BitIndicatorStateProperty = DependencyProperty.Register(
       "BitIndicatorState", typeof(bool),
       typeof(HcBitIndicator),new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnBitIndicatorStateChange)));
      

        public bool  BitIndicatorState 
        {
            get 
            {

                return (bool)GetValue(BitIndicatorStateProperty); 
            
            }
            set
            {
                SetValue(BitIndicatorStateProperty, value);
           

            }
        }

        private static void OnBitIndicatorStateChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           
            var ind = (HcBitIndicator)d;          
            ind.ShowState();
        }
        private void ShowState()
        {
           
            if (BitIndicatorState)
            {
                
                this.Source= ImageOn;
                
                          
            }
            else
            {

                this.Source = ImageOff;
                            
            }
          
        }


        public static readonly DependencyProperty ImageOnPathProperty =
        DependencyProperty.Register("ImageOnPath",
        typeof(Uri), typeof(HcBitIndicator),
        new FrameworkPropertyMetadata(new Uri(@"D:\WORK\SCADA\WHMI\WHMI\HMI_pic\valve_01h\valve_01h_flt_opn.bmp"),new PropertyChangedCallback(OnImageOnPathChanged)));

        public static readonly DependencyProperty ImageOffPathProperty =
        DependencyProperty.Register("ImageOffPath",
        typeof(Uri), typeof(HcBitIndicator),
        new FrameworkPropertyMetadata(new Uri(@"D:\WORK\SCADA\WHMI\WHMI\HMI_pic\valve_01h\valve_01h_flt_cls.bmp"),new PropertyChangedCallback(OnImageOffPathChanged)));

        

        public Uri ImageOnPath
        {
            get => (Uri)GetValue(ImageOnPathProperty);
            set 
            {
                SetValue(ImageOnPathProperty, value);

              
            } 
        }

        public Uri ImageOffPath
        {
            get => (Uri)GetValue(ImageOffPathProperty);
            set
            {
                SetValue(ImageOffPathProperty, value);
              
            } 
        }




        private static void OnImageOnPathChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

         //    HcBitIndicator ctrl = (HcBitIndicator)sender;
         //    ctrl.ImageOn = new BitmapImage((Uri)e.NewValue);
            ((HcBitIndicator)sender).ImageOn = new BitmapImage((Uri)e.NewValue);
       

        }
        private static void OnImageOffPathChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

          //    HcBitIndicator ctrl = (HcBitIndicator)sender;
          //    ctrl.ImageOff = new BitmapImage((Uri)e.NewValue);
            ((HcBitIndicator)sender).ImageOff = new BitmapImage((Uri)e.NewValue);
        
        }



    }
}
