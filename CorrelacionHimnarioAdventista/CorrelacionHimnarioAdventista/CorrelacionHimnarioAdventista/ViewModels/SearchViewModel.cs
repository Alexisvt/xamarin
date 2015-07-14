using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CorrelacionHimnarioAdventista.ViewModels
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        //Insert the properties for access to the View
        #region Properties
        public int OldEditionNumber { get; set; }
        public int NewEditionNumber { get; set; }
        public string HimnoName { get; set; }
        #endregion

        #region Constructor
        public SearchViewModel()
        {

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
        public ICommand SearchHimnoByName { get; set; }
        public ICommand SearchHimno { get; set; }
        #endregion
    }
}
