using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TwoButtons
{
    public class TwoButtonsPage : ContentPage
    {
        Button addButton, removeButton;
        StackLayout loggerLayout = new StackLayout();

        public TwoButtonsPage()
        {
            // Create the Button views and attach Children handlers.
            addButton = new Button
            {
                Text = "Add",
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            addButton.Clicked += OnButtonClicked;

            removeButton = new Button
            {
                Text = "Remove",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                IsEnabled = false
            };
            removeButton.Clicked += OnButtonClicked;

            this.Padding = new Thickness(5, Device.OnPlatform(20, 0, 0), 5, 0);

            //Assemble the page

            this.Content = new StackLayout
            {

                Children = {
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        Children = {
                            addButton,
                            removeButton
                        }
                    },
                    new ScrollView {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Content = loggerLayout
                    }
                }
            };
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button == addButton)
            {
                // Add label to scrollable StackLayout.
                loggerLayout.Children.Add( new Label {
                    Text = "Button clicked at " + DateTime.Now.ToString("T")
                });
            }
            else
            {
                // Remove topmost label frmo stackLayout
                loggerLayout.Children.RemoveAt(0);
            }

            // Enable "Remove" button only if children are present.
            removeButton.IsEnabled = loggerLayout.Children.Count > 0;
        }
    }
}
