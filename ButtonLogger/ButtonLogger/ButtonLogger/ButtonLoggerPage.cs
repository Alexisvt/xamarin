using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ButtonLogger
{
    public class ButtonLoggerPage : ContentPage
    {
        StackLayout loggerLayout = new StackLayout();

        public ButtonLoggerPage()
        {
            Button button = new Button
            {
                Text = "Log tthe Click Time"
            };
            button.Clicked += OnButtonClicked;

            this.Padding = new Thickness(5, Device.OnPlatform(20, 0, 0), 5, 0);

            //Assemblie the page
            this.Content = new StackLayout
            {
                Children = {
                    button,
                    new ScrollView {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Content = loggerLayout
                    }
                }
            };
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            //StackLayout outerLayout = (StackLayout)((Button)sender).ParentView;

            //Label newLabel = new Label
            //{
            //    Text = "Hello" + DateTime.Now.ToString()
            //};

            loggerLayout.Children.Add(new Label
            {
                Text = "Button clicked at " + DateTime.Now.ToString("T")
            });

            //outerLayout.Children.Add(newLabel);
        }
    }
}
