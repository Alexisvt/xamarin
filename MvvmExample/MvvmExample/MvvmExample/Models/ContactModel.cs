using System.ComponentModel;

namespace MvvmExample
{
    public class ContactModel: INotifyPropertyChanged
    {
        #region Attributes
        private int _id;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public int Id { get { return _id; }
            set
            {
                _id = value;
                NotifyPropertyChanged("Id");
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        #endregion

        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
