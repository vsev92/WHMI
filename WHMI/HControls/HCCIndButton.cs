using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Xml.Linq;

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
    ///     <MyNamespace:HcButtonInd/>
    ///
    /// </summary>
    public class HCCIndButton : HcBitButton
    {
        static HCCIndButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HCCIndButton), new FrameworkPropertyMetadata(typeof(HCCIndButton)));
            
        }
        public HCCIndButton()
        {
            DataContext = this;
           
            this.HcInd = new HcBitIndicator();
           

        }

 

     
        public HcBitIndicator HcInd { get; set; }

  


        
        public static readonly DependencyProperty ImageOnPathProperty =
        DependencyProperty.Register("ImageOnPath",
        typeof(Uri), typeof(HCCIndButton),
        new FrameworkPropertyMetadata(new PropertyChangedCallback(OnImageOnPathChanged)));

        public Uri ImageOnPath
        {
            get => (Uri)GetValue(ImageOnPathProperty);
            set => SetValue(ImageOnPathProperty, value);
        }

        public static readonly DependencyProperty ImageOffPathProperty =
        DependencyProperty.Register("ImageOffPath",
        typeof(Uri), typeof(HCCIndButton),
        new FrameworkPropertyMetadata(new PropertyChangedCallback(OnImageOffPathChanged)));

        public Uri ImageOffPath
        {
            get => (Uri)GetValue(ImageOffPathProperty);
            set => SetValue(ImageOffPathProperty, value);
        }


        public static readonly DependencyProperty StatusBitProperty =
        DependencyProperty.Register("StatusBit",
        typeof(bool), typeof(HCCIndButton),
        new FrameworkPropertyMetadata(new PropertyChangedCallback(OnStatusBitChanged)));

        public bool StatusBit
        {
            get => (bool)GetValue(StatusBitProperty);
            set => SetValue(StatusBitProperty, value);
        }

        

        public static readonly DependencyProperty HCCIndButtonModeProperty =
        DependencyProperty.Register("HCCIndButtonMode",
        typeof(ButtonModes), typeof(HCCIndButton),
        new FrameworkPropertyMetadata(new PropertyChangedCallback(OnHCCIndButtonModeChanged)));
        public ButtonModes HCCIndButtonMode
        {
            get => (ButtonModes)GetValue(HCCIndButtonModeProperty);
            set => SetValue(HCCIndButtonModeProperty, value);
        }


        private static void OnImageOnPathChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

            HCCIndButton ctrl = (HCCIndButton)sender;

            ctrl.HcInd.ImageOn = new BitmapImage((Uri)e.NewValue);
        }
        private static void OnImageOffPathChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

            HCCIndButton ctrl = (HCCIndButton)sender;

            ctrl.HcInd.ImageOff = new BitmapImage((Uri)e.NewValue);
        }

        private static void OnStatusBitChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

            HCCIndButton ctrl = (HCCIndButton)sender;

            ctrl.HcInd.BitIndicatorState = (bool)e.NewValue;
        }
        private static void OnCommandBitChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

            HCCIndButton ctrl = (HCCIndButton)sender;

           // ctrl.HcBut.BitButtonState = (bool)e.NewValue;
        }

        private static void OnHCCIndButtonModeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

            HCCIndButton ctrl = (HCCIndButton)sender;

          //  ctrl.HcBut.ButtonMode = (ButtonModes)e.NewValue;
        }

    }
}
