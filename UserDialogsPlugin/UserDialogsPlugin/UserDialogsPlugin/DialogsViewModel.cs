using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;
using System.Windows.Input;


namespace UserDialogsPlugin
{
    public class DialogsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand PromptCommand { get; set; }

        public DialogsViewModel()
        {
            PromptCommand = new Command(DisplayPromptAction);
        }

        private async void DisplayPromptAction()
        {
            PromptResult respuesta;

            do
            {
                respuesta = await UserDialogs.Instance.PromptAsync("Escriba su nombre", "Alert! Service URL not setted", inputType: InputType.Default);
            } while (string.IsNullOrWhiteSpace(respuesta.Text));

            MessagingCenter.Send<DialogsViewModel, string>(this, "Message", respuesta.Text);
        }
    }
}
