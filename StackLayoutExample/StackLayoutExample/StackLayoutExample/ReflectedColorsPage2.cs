﻿using System;
using System.Reflection;

using Xamarin.Forms;

namespace StackLayoutExample
{
    public class ReflectedColorsPage2 : ContentPage
    {
        public ReflectedColorsPage2()
        {
            StackLayout stackLayout = new StackLayout { BackgroundColor = Color.Blue, HorizontalOptions = LayoutOptions.Start };

            // Loop through the Color structure fields.
            foreach (FieldInfo info in typeof(Color).GetRuntimeFields())
            {
                if (info.GetCustomAttribute<ObsoleteAttribute>() != null)
                    continue;

                if (info.IsPublic && info.IsStatic && info.FieldType == typeof(Color))
                {
                    stackLayout.Children.Add(CreateColorLabel((Color)info.GetValue(null), info.Name));
                }
            }

            // Loop through the Color structure properties.
            foreach (PropertyInfo info in typeof(Color).GetRuntimeProperties())
            {
                MethodInfo methodInfo = info.GetMethod;

                if(methodInfo.IsPublic && methodInfo.IsStatic && methodInfo.ReturnType == typeof(Color))
                {
                    stackLayout.Children.Add(CreateColorLabel((Color)info.GetValue(null), info.Name));
                }
            }

            Padding = new Thickness(5, Device.OnPlatform(20, 5, 5), 5, 5);

            Content = new ScrollView { Content = stackLayout, BackgroundColor = Color.Red };
        }

        protected Label CreateColorLabel(Color color, string name)
        {
            Color backgroundColor = Color.Default;

            if (color != Color.Default)
            {
                // Standard luminance calculation
                double luminace = 0.30 * color.R + 0.59 * color.G + 0.11 * color.B;

                backgroundColor = luminace > 0.5 ? Color.Black : Color.White;
            }

            // Create the Label
            return new Label { 
                Text = name, TextColor = color, 
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), 
                BackgroundColor = backgroundColor
            };
        }
    }
}
