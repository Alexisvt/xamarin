using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace UserDialogsPlugin
{
    public partial class DialogsView : ContentPage
    {
        public DialogsView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<DialogsViewModel, string>(this, "Message",
              async (sender, message) =>
              {
                  await DisplayAlert("Message result", message, "Ok");
              });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<DialogsViewModel, string>(this, "Message");
        }
    }
}
