using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SizeBoxView
{
    public class SizeBoxViewPage : ContentPage
    {
        public SizeBoxViewPage()
        {
            BackgroundColor = Color.Pink;

            Content = new BoxView
            {
                Color = Color.Accent,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 200,
                HeightRequest = 100
            };
        }
    }
}
