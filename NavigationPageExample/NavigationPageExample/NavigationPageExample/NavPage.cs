using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NavigationPageExample
{
    public class NavPage : NavigationPage
    {
        public NavPage()
        {
            var rootLabel = new Label { Text = "Root Page" };
            var anotherLabel = new Label { Text = "Another Label" };
            var button = new Button
            {
                Text = "Next Page"
            };
            var stackLayout = new StackLayout
            {
                Children = { rootLabel, button }
            };
            var newPage = new ContentPage
            {
                Content = anotherLabel
            };

            var navPage = new NavigationPage(new ContentPage
            {
                Title = "Root Nav Page",
                Content = stackLayout
            });
            button.Clicked += (sender, args) => navPage.PushAsync(newPage);
        }
    }
}
