using CorrelacionHimnarioAdventista.Models;
using CorrelacionHimnarioAdventista.Models.Concrete;
using HelperClasses;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace CorrelacionHimnarioAdventista.ViewModels
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _oldEditionNumber;
        private string _newEditionNumber;
        private bool _isBussy;
        private string _himnoName;
        private JsonRepository _jsonRepository;
        private bool _isSearchable;

        #endregion

        #region Properties

        public bool IsSearchable
        {
            get { return _isSearchable; }
            private set 
            {
                if (_isSearchable == value)
                {
                    return;
                }

                _isSearchable = value;
                OnPropertyChanged("IsSearchable");
            }
        }

        private JsonRepository Repository
        {
            get { return _jsonRepository; }
            set { _jsonRepository = value; }
        }

        public string OldEditionNumber 
        { 
            get { return _oldEditionNumber; }
            set
            {
                if (!string.IsNullOrEmpty(_oldEditionNumber) && _oldEditionNumber.Equals(value))
                {
                    return;
                }

                _oldEditionNumber = value;
                OnPropertyChanged("OldEditionNumber");

                //Check if are valid data to search
                CanSearch();
            }
        }

        public string NewEditionNumber
        {
            get { return _newEditionNumber; }
            set 
            {
                if (!string.IsNullOrEmpty(_newEditionNumber) && _newEditionNumber.Equals(value))
                {
                    return;
                }

                _newEditionNumber = value;
                OnPropertyChanged("NewEditionNumber");

                //Check if are valid data to search
                this.CanSearch();
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

                //Check if are valid data to search
                this.CanSearch();
            }
        }
        #endregion

        #region Constructor
        public SearchViewModel()
        {
            this.Repository = new JsonRepository();
            SearchHimnoCommand = new Command(SearchHimnoByNumberAction);
            SearchHimnoByNameCommand = new Command(SearchHimnoByNameAction);
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
        public ICommand SearchHimnoCommand { get; set; }
        public ICommand SearchHimnoByNameCommand { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Check if are valid data to enable searching
        /// </summary>
        protected virtual void CanSearch()
        {
            int oldEditionNumber = 
                string.IsNullOrEmpty(OldEditionNumber) ? 0 : Convert.ToInt32(OldEditionNumber);
            int newEditionNumber = 
                string.IsNullOrEmpty(NewEditionNumber) ? 0 : Convert.ToInt32(NewEditionNumber);

            if (string.IsNullOrEmpty(HimnoName) &&
                (oldEditionNumber < 0 || oldEditionNumber == 0) &&
                (newEditionNumber < 0 || newEditionNumber == 0))
            {
                IsSearchable = false;
            }
            else
            {
                IsSearchable = true;
            }
        }

        protected virtual void SearchHimnoByNameAction()
        {
            Maybe<HimnoModel> Himno;

            if (!String.IsNullOrEmpty(HimnoName))
            {
                Himno = this.Repository.getHimnoByName(this.HimnoName);

                if (Himno.Count() > 0)
                {
                    this.NewEditionNumber = Himno.First().Numbers.New.ToString();
                    this.OldEditionNumber = Himno.First().Numbers.Old.ToString();
                }
            }
        }

        protected virtual void SearchHimnoByNumberAction()
        {
            Maybe<HimnoModel> Himno;
            int oldEditionNumber = 
                string.IsNullOrEmpty(OldEditionNumber) ? 0 : Convert.ToInt32(OldEditionNumber);
            int newEditionNumber = 
                string.IsNullOrEmpty(NewEditionNumber) ? 0 : Convert.ToInt32(NewEditionNumber);

            IsBussy = true;

            if (oldEditionNumber != 0)
            {
                Himno = Repository.getHimnoByNumber(oldEditionNumber, "Old");

                if (Himno.Count() > 0)
                {
                    this.NewEditionNumber = Himno.First().Numbers.New.ToString();
                    this.HimnoName = Himno.First().Name;
                }
            }
            else if (newEditionNumber != 0)
            {
                Himno = Repository.getHimnoByNumber(newEditionNumber, "New");
                if (Himno.Count() > 0)
                {
                    OldEditionNumber = Himno.First().Numbers.Old.ToString();
                    HimnoName = Himno.First().Name;
                }
            }

            IsBussy = false;
        }
        #endregion
    }
}
