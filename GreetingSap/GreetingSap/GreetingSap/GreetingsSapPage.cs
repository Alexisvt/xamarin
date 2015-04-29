using System;

using Xamarin.Forms;

namespace GreetingSap
{
	public class GreetingsSapPage : ContentPage
	{
		public GreetingsSapPage ()
		{
            this.Content = new Label
            {
                Text = "Greetings, Xamarin.Forms SAP",
                //HorizontalOptions= LayoutOptions.Center,
                //VerticalOptions= LayoutOptions.Center

                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };

            //#if __IOS__
            //    this.Padding = new Thickness
            //    {
            //        Top= 20
            //    };
            //#endif

            //#if WINDOWS_PHONE
            //    this.Padding = new Thickness
            //    {
            //        Top= 150
            //    };
            //#endif

            //this.Padding = Device.OnPlatform<Thickness>(new Thickness(0, 20, 0, 0), new Thickness(0), new Thickness(0,300,0,0));

            //Device.OnPlatform(
            //    iOS: () => { Padding = new Thickness(0, 40, 20, 0); }, 
            //    Android: () => { Padding= new Thickness(0,0); },
            //    WinPhone: () => { Padding = new Thickness(0, 100, 0, 0); }
            //    );

            //Device.OnPlatform(
            //    iOS: () => { Ver});

		}
	}
}
