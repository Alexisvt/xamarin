using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Xamarin.Forms;

namespace VerticalOptionsDemo
{
    public class VerticalOptionsDemoPage : ContentPage
    {
        public VerticalOptionsDemoPage()
        {
            Color[] colors = { Color.Yellow, Color.Blue };
            int flipFlopper = 0;

             //Create Labels sorted by LayoutAligment property
            //IEnumerable<Label> labels = typeof(LayoutOptions).GetRuntimeFields()
            //    .Where(p => p.IsPublic && p.IsStatic)
            //    .OrderBy(p => (LayoutOptions)p.GetValue(null))
            //    .Select(p => new Label
            //    {
            //        Text = "VerticalOptions = " + p.Name,
            //        VerticalOptions = (LayoutOptions)p.GetValue(null),
            //        XAlign = TextAlignment.Center,
            //        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            //        TextColor = colors[flipFlopper = 1 - flipFlopper],
            //        BackgroundColor = colors[flipFlopper = 1 - flipFlopper]
            //    });

            IEnumerable<Label> labels =
            from field in typeof(LayoutOptions).GetRuntimeFields()
            where field.IsPublic && field.IsStatic
            orderby ((LayoutOptions)field.GetValue(null)).Alignment
            select new Label
            {
                Text = "VerticalOptions = " + field.Name,
                VerticalOptions = (LayoutOptions)field.GetValue(null),
                XAlign = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = colors[flipFlopper],
                BackgroundColor = colors[flipFlopper = 1 - flipFlopper]
            };

            StackLayout stackLayout = new StackLayout();

            foreach (Label label in labels)
            {
                stackLayout.Children.Add(label);
            }

            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            Content = stackLayout;
        }
    }
}
