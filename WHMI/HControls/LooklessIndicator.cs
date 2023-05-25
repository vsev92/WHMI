using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WHMI.HControls
{
    public class LooklessIndicator
    {

 
        public BitmapImage ImageOn { get; set; }

        public BitmapImage ImageOff { get; set; }
        
        public bool StatusBitTag;



        public BitmapImage ImageCurrent
        {
            get { return Indicate(); }

        }

        public LooklessIndicator(Uri imageOnSource, Uri imageOffSource)
        {
            ImageOn = GetImageFromPath(imageOnSource);
            ImageOff = GetImageFromPath(imageOffSource);

        }

        public BitmapImage GetImageFromPath(Uri path)
        {
          
            try
            {
                return new BitmapImage(path);
            }
            

            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return new BitmapImage();
            
        }

        private BitmapImage Indicate()
        {
            if (StatusBitTag)
            {

                return ImageOn;


            }
            else
            {

                return ImageOff;


            }
        }
    }
}
