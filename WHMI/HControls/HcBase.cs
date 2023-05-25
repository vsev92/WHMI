using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WHMI.HControls
{
    public class HcBase:UserControl, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static readonly DependencyProperty BITagVal1Property = DependencyProperty.Register(
           "BITagVal1", typeof(bool),
           typeof(HcBase)
           );
          

        private bool _bITagVal1;
        public bool BITagVal1
        {
            get { return _bITagVal1; }
            set
            {
                _bITagVal1 = value;

                OnPropertyChanged();
             
            }
        }

        private string _txt;
        public string Txt
        {
            get { return _txt; }
            set
            {
                _txt = value;

                OnPropertyChanged();

            }
        }


    }
}
