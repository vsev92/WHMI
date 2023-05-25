using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Xml.Linq;

namespace WHMI
{
    public class Dcont:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private bool _bITagVal1;
        public bool BITagVal1
        {
            get { return _bITagVal1; }
            set
            {
                _bITagVal1 = value;
                
                OnPropertyChanged();
                BITagVal = BITagVal1;
            }
        }
        private bool _bITagVal;
        public bool BITagVal
        {
            get { return _bITagVal; }
            set
            {
                _bITagVal = value;

                OnPropertyChanged();

            }
        }
    }
}
