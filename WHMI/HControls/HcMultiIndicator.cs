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
using System.Resources;
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
    public class HcMultiIndicator :System.Windows.Controls.Image
    {
       
        static HcMultiIndicator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HcMultiIndicator), new FrameworkPropertyMetadata(typeof(HcMultiIndicator)));
       
            //    FrameworkPropertyMetadata newSourceMetadata = new(
            //    defaultValue: new BitmapImage(new Uri(@"D:\WORK\SCADA\WHMI\WHMI\HMI_pic\valve_01h\valve_01h_flt_cls.bmp")));
            //    SourceProperty.OverrideMetadata(forType: typeof(System.Windows.Controls.Image), typeMetadata: newSourceMetadata);
          
        }
        public HcMultiIndicator()
        {


            
           //// StatImages.Add(new BitmapImage());
           
            //    StatImages.Add(new BitmapImage(new Uri(@"D:\WORK\SCADA\WHMI\WHMI\HMI_pic\valve_01h\valve_01h_flt_cls.bmp")));

          //  ShowState();
          

        }

 

       public static readonly DependencyProperty IndicatorStatProperty = DependencyProperty.Register(
       "IndicatorStat", typeof(int),
       typeof(HcMultiIndicator),new FrameworkPropertyMetadata(0, new PropertyChangedCallback(OnIndicatorStatChange)));
      

        public int  IndicatorStat 
        {
            get 
            {

                return (int)GetValue(IndicatorStatProperty); 
            
            }
            set
            {
                SetValue(IndicatorStatProperty, value);
                ShowState();

            }
        }

        private static void OnIndicatorStatChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           
            var ind = (HcMultiIndicator)d;          
            ind.ShowState();
        }
        private void ShowState()
        {
           
            if (this.StatImages.Count>IndicatorStat)
            {
                
                this.Source= this.StatImages[IndicatorStat];
                
                          
            }
            else
            {

                this.Source = this.StatImages[0];
                MessageBox.Show(this.StatImages.Count.ToString());        
            }
          
        }


       

        


       
        /// <summary>
        /// ///////MULTI
        /// </summary>
        
        
        public static readonly DependencyProperty StatImagesProperty =
        DependencyProperty.Register("StatImages",
        typeof(List<ImageSource>), typeof(HcMultiIndicator),
        new FrameworkPropertyMetadata(new List<ImageSource>(), new PropertyChangedCallback(OnStatImagesChanged)));

       
        public  List<ImageSource> StatImages
        {
            get => (List<ImageSource>)GetValue(StatImagesProperty);
            set
            {
                SetValue(StatImagesProperty, value);


            }
        }

        private static void OnStatImagesChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        
          //  ((HcMultiIndicator)sender).StatImages = (List<ImageSource>)e.NewValue;
            
            ((HcMultiIndicator)sender).ShowState();

        }

    }
}
