using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamlSamples
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            //MainPage = new SliderBindingsPage();
            //MainPage = new SliderTransformsPage();
            //MainPage = new OneShotDateTimePage();
            //MainPage = new ClockPage();
            //MainPage = new HslColorScrollPage();
            MainPage = new KeypadPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
