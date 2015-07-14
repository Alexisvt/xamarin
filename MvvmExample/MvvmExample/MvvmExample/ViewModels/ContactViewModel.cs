using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmExample.ViewModels
{
    public class ContactViewModel: INotifyPropertyChanged
    {
        #region Attributes
        public event ProgressChangedEventHandler PropertyChanged;
        private ContactModel _contact;
        private ObservableCollection<ContactModel> _contacts;
        //public event PropertyChangedEventHandler PropertyChanged2;
        #endregion

        #region Constructor
        public ContactViewModel()
        {
            Contacts = new ObservableCollection<ContactModel>{
                new ContactModel{ Id=1, FirstName="Tifa", LastName="LockHart", PhoneNumber="09090990"},
                new ContactModel{ Id=2, FirstName="Alexis", LastName="Villegas", PhoneNumber="87665118"}
            };
            Contact = new ContactModel();

            SaveContactCommand = new Command(() =>
            {
                Contacts.Add(new ContactModel()
                {
                    Id = Contacts.Count + 1,
                    FirstName = Contact.FirstName,
                    LastName = Contact.LastName,
                    PhoneNumber = Contact.PhoneNumber
                });

                Contact = new ContactModel();
            }, () => {
                return !String.IsNullOrEmpty(Contact.FirstName);
            });
        }
        #endregion

        #region Properties
        public ICommand SaveContactCommand { get; private set; }

        public ObservableCollection<ContactModel> Contacts
        {
            get { return _contacts; }
            set
            {
                _contacts = value;
                NotifyPropertyChanged("Contacts");
            }
        }

        public ContactModel Contact
        {
            get { return _contact; }
            set
            {
                _contact = value;
                this.NotifyPropertyChanged("Contact");
            }
        }
        #endregion

        #region Methods
        private void NotifyPropertyChanged(string property)
        {
            throw new System.NotImplementedException();
        }
        #endregion
       
    }
}
