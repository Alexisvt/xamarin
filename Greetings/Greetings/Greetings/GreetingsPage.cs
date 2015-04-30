using System;

using Xamarin.Forms;

namespace Greetings
{
    public class GreetingsPage : ContentPage
    {
        public GreetingsPage()
        {
            //Label label = new Label 
            //{
            //    Text = "Greetings, Xamarin.Forms!"
            //};
            //this.Content = label;

            this.Padding = new Thickness
            {
                Top = 20
            };

            this.Content = new Label
            {
                Text = "Greetings, Xamarin.Forms!",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize= Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold | FontAttributes.Italic
            };
        }
    }
}
