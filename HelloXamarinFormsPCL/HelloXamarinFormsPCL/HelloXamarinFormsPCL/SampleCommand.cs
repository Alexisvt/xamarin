using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HelloXamarinFormsPCL
{
    public class SampleCommand : ICommand
    {
        private Action _toExecute;

        #region Constructor
        public SampleCommand(Action toExecute)
        {
            _toExecute = toExecute;
        }
        #endregion

        #region EventsHandler
        public event EventHandler CanExecuteChanged;
        #endregion

        #region Methods
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _toExecute();
        }
        #endregion
    }
}
