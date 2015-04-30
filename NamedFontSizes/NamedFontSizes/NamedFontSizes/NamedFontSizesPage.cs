﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace NamedFontSizes
{
    public class NamedFontSizesPage : ContentPage
    {
        public NamedFontSizesPage()
        {
            FormattedString formattedString = new FormattedString();
            NamedSize[] namedSizes =
            {
                NamedSize.Default, NamedSize.Micro, NamedSize.Small
                , NamedSize.Medium, NamedSize.Large
            };

            foreach (NamedSize namedSize in namedSizes)
            {
                double fontSize = Device.GetNamedSize(namedSize, typeof(Label));

                formattedString.Spans.Add(new Span
                    {
                        Text = String.Format("Named Size= {0} ({1:F2})", namedSize, fontSize),
                        FontSize = fontSize
                    });

                if (namedSize != namedSizes.Last())
                {
                    formattedString.Spans.Add(new Span { Text = "\n\n" });
                }
            }

            Content = new Label
            {
                FormattedText = formattedString,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
        }
    }
}
