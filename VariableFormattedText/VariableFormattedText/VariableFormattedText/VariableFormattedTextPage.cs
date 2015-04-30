using System;

using Xamarin.Forms;

namespace VariableFormattedText
{
    public class VariableFormattedTextPage : ContentPage
    {
        public VariableFormattedTextPage()
        {
            //FormattedString formatedString = new FormattedString();

            //formatedString.Spans.Add(new Span { Text = "I " });

            //formatedString.Spans.Add(new Span { 
            //    FontAttributes = FontAttributes.Bold, 
            //    Text = "love", 
            //    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) 
            //});

            //formatedString.Spans.Add(new Span
            //{
            //    Text = " Xamarin.Forms!"
            //});

            //this.Content = new Label
            //{
            //    FormattedText = formatedString,
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.Center,
            //    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            //};

            this.Content = new Label
            {
                FormattedText = new FormattedString
                {
                    Spans =
                    {
                        new Span {
                            Text= "I"
                        },
                        new Span {
                            Text= " love",
                            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                            FontAttributes = FontAttributes.Bold
                        },
                        new Span {
                            Text = " Xamarin.Forms!"
                        }
                    }
                },
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
        }
    }
}
