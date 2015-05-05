using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace StackLayoutExample
{
    public class ColorListPage : ContentPage
    {
        public ColorListPage()
        {
            this.Padding = new Thickness(5, Device.OnPlatform(20, 5, 5), 5, 5);
            double fontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));

            Content = new StackLayout
            {
                Children = {
					new Label {
                        Text = "White",
                        TextColor = Color.White,
                        FontSize = fontSize 
                    },
                    new Label
                    { 
                        Text = "Silver",
                        TextColor = Color.Silver,
                        FontSize = fontSize
                    },
                    new Label
                    {
                    Text = "Fuchsia",
                    TextColor = Color.Fuchsia,
                    FontSize = fontSize
                    },
                    new Label
                    {
                    Text = "Purple",
                    TextColor = Color.Purple,
                    FontSize = fontSize
                    }
				}
            };
        }
    }
}
