using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WHMI.HControls;

namespace WHMI.VIewModels
{
    public class MainWindowViewModel:ViewModelBase
    {


        private bool _bITagVal1;
        public bool BITagVal1
        {
            get { return _bITagVal1; }
            set
            {
              _bITagVal1=value;
               
                this.OnPropertyChanged(nameof(BITagVal1));
                MessageBox.Show("Property changed "+value.ToString());
            }
        }
    }
}
