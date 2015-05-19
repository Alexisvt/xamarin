using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HelloXamarinFormsPCL
{
    public class SampleContext : INotifyPropertyChanged
    {
        #region Attributes
        private string _labelText;
        private string _entryText;
        private ICommand _buttonCommand;
        #endregion

        #region Constructor
        public SampleContext()
        {
            _buttonCommand = new SampleCommand(() => LabelText = DateTime.Now.ToString());
        }
        #endregion

        #region Properties

        public ICommand ButtonCommand
        {
            get
            {
                return _buttonCommand;
            }
        }

        public string LabelText
        {
            get
            {
                return _labelText;
            }
            set
            {
                if (_labelText == value)
                    return;

                _labelText = value;
                OnPropertyChanged("LabelText");
            }
        }

        public string EntryText
        {
            get
            {
                return _entryText;
            }
            set
            {
                if (_entryText == value)
                    return;

                _entryText = value;
                OnPropertyChanged("LabelEntry");
            }
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
