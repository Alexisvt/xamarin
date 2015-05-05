using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace UIDemo
{
    public class UICodeDemo : ContentPage
    {
        public UICodeDemo()
        {
            var layout = new StackLayout
            {
            Orientation = StackOrientation.Vertical,
            Padding = new Thickness(10, 20, 10, 10),
            };
            layout.Children.Add(new Label
            {
            Text = "My Label",
            XAlign = TextAlignment.Center,
            });
            layout.Children.Add(new Button
            {
                Text = "My Button",
            });
            layout.Children.Add(new Image
            {
                Source = "xamagon.png",
            });
            layout.Children.Add(new Switch
            {
                IsToggled = true,
            });
            layout.Children.Add(new Stepper
            {
                Value = 10,
            });
            Content = layout;
        }
    }
}
