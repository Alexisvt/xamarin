using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace XamlSamples
{
    public class HslViewModel : INotifyPropertyChanged
    {
        double hue, saturation, luminosity;
        Color color;

        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties
        public double Hue 
        {
            get
            {
                return hue;
            }
            set 
            {
                if (hue != value)
                {
                    hue = value;
                    OnPropertyChanged("Hue");
                    SetNewColor();
                }
            }
        }

        public double Saturation 
        {
            get 
            {
                return saturation;
            }
            set
            {
                if (saturation != value)
                {
                    saturation = value;
                    OnPropertyChanged("Saturation");
                    SetNewColor();
                }
            }
        }

        public double Luminosity 
        {
            get 
            {
                return luminosity;
            }
            set
            {
                if (luminosity != value)
                {
                    luminosity = value;
                    OnPropertyChanged("Luminosity");
                    SetNewColor();
                }
            }
        }

        public Color Color {
            get 
            {
                return color;
            }
            set
            {
                if (color != value)
                {
                    color = value;
                    OnPropertyChanged("Color");

                    this.Hue = value.Hue;
                    this.Saturation = value.Saturation;
                    this.Luminosity = value.Luminosity;
                }
            }
        }
        #endregion

        #region Methods
        private void SetNewColor()
        {
            this.Color = Color.FromHsla(this.Hue, this.Saturation, this.Luminosity);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        
    }
}
