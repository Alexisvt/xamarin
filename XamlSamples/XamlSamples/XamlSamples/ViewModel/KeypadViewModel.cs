using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamlSamples
{
    class KeypadViewModel : INotifyPropertyChanged
    {
        #region Attributes
        string inputString = "";
        string displayText = "";
        char[] specialChars = { '*', '#' };

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        
        #region Constructor
        public KeypadViewModel()
        {
            this.AddCharCommand = new Command<string>((key) =>
            {
                // Add the key to the input string.
                this.InputString += key;
            });

            this.DeleteCharCommand = new Command(() =>
            {
                // Strip a character from the input string.
                this.InputString = this.InputString.Substring(0, this.InputString.Length - 1);
            }, () => {
                // Return true if there is something to delete.
                return this.InputString.Length > 0;
            });
        }
        #endregion

        #region Properties
        public string InputString 
        { 
            get { return inputString; } 
            set 
            {
                if (inputString != value)
                {
                    inputString = value;

                    OnPropertyChanged("InputString");
                    this.DisplayText = FormatText(inputString);

                    // Perhaps the delete button must be enabled/disable
                    ((Command)this.DeleteCharCommand).ChangeCanExecute();
                }
            } 
        }

        public string DisplayText 
        {
            get 
            {
                return displayText;
            }
            set
            {
                if (displayText != value)
                {
                    displayText = value;

                    OnPropertyChanged("DisplayText");
                }
            }
        }
        #endregion

        #region Methods

        private string FormatText(string str)
        {
            bool hasNonNumbers = str.IndexOfAny(specialChars) != -1;
            string formatted = str;

            if (hasNonNumbers || str.Length < 4 || str.Length > 10)
            {
            }
            else if (str.Length < 8)
            {
                formatted = String.Format("{0}-{1}",
                    str.Substring(0, 3),
                    str.Substring(3, 3),
                    str.Substring(6));
            }
            return formatted;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region ICommand implementations
        public ICommand AddCharCommand { protected set; get; }
        public ICommand DeleteCharCommand { get; protected set; }
        #endregion
    }
}
