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
    public class HcIndicator :System.Windows.Controls.Image
    {
       
        static HcIndicator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HcIndicator), new FrameworkPropertyMetadata(typeof(HcIndicator)));

            //    FrameworkPropertyMetadata newSourceMetadata = new(
            //    defaultValue: new BitmapImage(new Uri(@"D:\WORK\SCADA\WHMI\WHMI\HMI_pic\valve_01h\valve_01h_flt_cls.bmp")));
            //    SourceProperty.OverrideMetadata(forType: typeof(System.Windows.Controls.Image), typeMetadata: newSourceMetadata);
            
        }
        public HcIndicator()
        {

          
      //      ImageOn = new BitmapImage( new Uri (@"D:\WORK\SCADA\WHMI\WHMI\WHMI\valve_01h_flt_cls.bmp"));
      //      ImageOff = new BitmapImage( new Uri(@"D:\WORK\SCADA\WHMI\WHMI\WHMI\valve_01h_flt_opn.bmp"));
           

        }

 

       public static readonly DependencyProperty BitIndicatorStateProperty = DependencyProperty.Register(
       "BitIndicatorState", typeof(bool),
       typeof(HcIndicator),new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnBitIndicatorStateChange)));
      

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
           
            var ind = (HcIndicator)d;          
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


        public static readonly DependencyProperty ImageOnProperty =
        DependencyProperty.Register("ImageOn",
        typeof(ImageSource), typeof(HcIndicator),
        new FrameworkPropertyMetadata(new BitmapImage(new Uri(@"D:\WORK\SCADA\WHMI\WHMI\HMI_pic\valve_01h\valve_01h_flt_opn.bmp")),new PropertyChangedCallback(OnImageOnChanged)));

        public static readonly DependencyProperty ImageOffProperty =
        DependencyProperty.Register("ImageOff",
        typeof(ImageSource), typeof(HcIndicator),
        new FrameworkPropertyMetadata(new BitmapImage(new Uri(@"D:\WORK\SCADA\WHMI\WHMI\HMI_pic\valve_01h\valve_01h_flt_cls.bmp")),new PropertyChangedCallback(OnImageOffChanged)));

        

        public ImageSource ImageOn
        {
            get => (ImageSource)GetValue(ImageOnProperty);
            set 
            {
                SetValue(ImageOnProperty, value);
              
              
            } 
        }

        public ImageSource ImageOff
        {
            get => (ImageSource)GetValue(ImageOffProperty);
            set
            {
                SetValue(ImageOffProperty, value);
             
            } 
        }




        private static void OnImageOnChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

         //    HcBitIndicator ctrl = (HcBitIndicator)sender;
         //    ctrl.ImageOn = new BitmapImage((Uri)e.NewValue);
           
            ((HcIndicator)sender).ImageOn = (ImageSource)e.NewValue;
            ((HcIndicator)sender).ShowState();

        }
        private static void OnImageOffChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

            //    HcBitIndicator ctrl = (HcBitIndicator)sender;
            //    ctrl.ImageOff = new BitmapImage((Uri)e.NewValue);
            ((HcIndicator)sender).ImageOff = (ImageSource)e.NewValue;
            ((HcIndicator)sender).ShowState();
        }



    }
}
