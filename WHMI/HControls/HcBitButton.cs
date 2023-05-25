using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml.Linq;

namespace WHMI.HControls
{
    public class HcBitButton:Button
    {

        static HcBitButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HcBitButton), new FrameworkPropertyMetadata(typeof(HcBitButton)));
        }
        public HcBitButton()
        {

            this.PreviewMouseDown += HcBitButton_PreviewMouseDown;
            this.PreviewMouseUp += HcBitButton_PreviewMouseUp;
     
          

        }

   
       
        
        
        public static readonly DependencyProperty BitButtonStateProperty = DependencyProperty.Register(
        "BitButtonState", typeof(bool),
        typeof(HcBitButton));


        public bool BitButtonState
        {
            get
            {


                return (bool)GetValue(BitButtonStateProperty);

            }
            set
            {

                SetValue(BitButtonStateProperty, value);

            }
        }

        public static readonly DependencyProperty ButtonModeProperty = DependencyProperty.Register(
        "ButtonMode", typeof(ButtonModes),
        typeof(HcBitButton));


        public ButtonModes ButtonMode
        {
            get
            {


                return (ButtonModes)GetValue(ButtonModeProperty);

            }
            set
            {

                SetValue(ButtonModeProperty, value);
                SetModeOnButton();




            }
        }

        private void SetModeOnButton()
        {
            switch (ButtonMode)
            {
                case ButtonModes.NO:
                    {
                        this.BitButtonState = false;
                        break;
                    }
                case ButtonModes.NC:
                    {
                        this.BitButtonState = true;
                        break;
                    }
            }
        }

        private void HcBitButton_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            UnPress();
         
            this.BTxt = "MouseUp";
            MessageBox.Show("up");
        }

        private void HcBitButton_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
         
            Press();
            this.BTxt = "MouseDown";
            MessageBox.Show("down");
        }

        public void Press()
        {
                
           switch (ButtonMode)
                {
                    case ButtonModes.NO:
                        this.BitButtonState = true;
                        break;
                    case ButtonModes.NC:
                        this.BitButtonState = false;
                        break;
                    case ButtonModes.Switch:
                        this.BitButtonState = !this.BitButtonState;
                        break;
                }
         
        }


     

        public void UnPress()
        {
            switch (ButtonMode)
            {
                case ButtonModes.NO:
                    this.BitButtonState = false;
                    break;
                case ButtonModes.NC:
                    this.BitButtonState = true;
                    break;
      
            }
        }



        public static readonly DependencyProperty BTxtProperty = DependencyProperty.Register(
        "BTxt", typeof(string),
        typeof(HcBitButton));
        public string BTxt
        {
            get
            {


                return (string)GetValue(BTxtProperty);

            }
            set
            {

                SetValue(BTxtProperty, value);

            }
        }
    }

    public enum ButtonModes
    {
        NO,
        NC,
        Switch
    }
    
}
