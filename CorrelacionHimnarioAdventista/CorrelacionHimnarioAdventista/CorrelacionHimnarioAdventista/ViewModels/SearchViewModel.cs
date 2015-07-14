using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CorrelacionHimnarioAdventista.ViewModels
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        #region Fields
        private int _oldEditionNumber;
        private int _newEditionNumber;
        private bool _isBussy;
        private string _himnoName;
        #endregion

        #region Properties
        public int OldEditionNumber 
        { 
            get { return _oldEditionNumber; }
            set
            {
                if (_oldEditionNumber == value)
                {
                    return;
                }

                _oldEditionNumber = value;
                OnPropertyChanged("OldEditionNumber");
            }
        }

        public int NewEditionNumber
        {
            get { return _newEditionNumber; }
            set 
            {
                if (_newEditionNumber == value)
                {
                    return;
                }

                _newEditionNumber = value;
                OnPropertyChanged("NewEditionNumber");
            }
        }

        public bool IsBussy
        {
            get { return _isBussy; }
            set 
            {
                if (_isBussy == value)
                {
                    return;
                }

                _isBussy = value;
                OnPropertyChanged("IsBussy");
            }
        }
        
        public string HimnoName 
        {
            get { return _himnoName; }
            set 
            {
                if (_himnoName == value)
                {
                    return;
                }

                _himnoName = value;
                OnPropertyChanged("HimnoName");
            }
        }
        #endregion

        #region Constructor
        public SearchViewModel()
        {
            SearchHimnoByNameCommand = new Command(SearchHimnoByName, CanSearchHimnoByName);
            SearchHimnoByNumberCommand = new Command(SearchHimnoByNumber, CanSearchHimnoByNumber);
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region ICommands Properties
        public ICommand SearchHimnoByNameCommand { get; set; }
        public ICommand SearchHimnoByNumberCommand { get; set; }
        #endregion

        #region Methods
        protected virtual bool CanSearchHimnoByName()
        {
            return !String.IsNullOrWhiteSpace(_himnoName);
        }

        protected virtual void SearchHimnoByName()
        {

        }

        protected virtual bool CanSearchHimnoByNumber()
        {
            return _oldEditionNumber != 0 || _newEditionNumber != 0;
        }

        protected virtual void SearchHimnoByNumber()
        {

        }
        #endregion
    }
}
