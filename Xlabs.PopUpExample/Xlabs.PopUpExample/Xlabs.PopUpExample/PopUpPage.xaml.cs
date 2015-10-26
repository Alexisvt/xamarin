using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLabs.Forms.Controls;
using Xamarin.Forms;

namespace Xlabs.PopUpExample
{
    public partial class PopUpPage : ContentPage
    {
        public PopUpPage()
        {
            InitializeComponent();
            this.OpenButton.Clicked += OpenButtonClicked;
            this.BotonPrueba.Clicked += OpenButtonClicked;
        }

        void OpenButtonClicked(object sender, EventArgs e)
        {
            var popupLayout = this.PopLayout as PopupLayout;

            if (popupLayout.IsPopupActive)
            {
                popupLayout.DismissPopup();
            }
            else
            {
                var list = new ListView()
                {
                    BackgroundColor = Color.White,
                    ItemsSource = new[] { "1", "2", "3" },
                    HeightRequest = this.Height * .5,
                    WidthRequest = this.Width * .8
                };

                list.ItemSelected += (s, args) =>
                    popupLayout.DismissPopup();

                popupLayout.ShowPopup(list);
            }
        }
    }
}
