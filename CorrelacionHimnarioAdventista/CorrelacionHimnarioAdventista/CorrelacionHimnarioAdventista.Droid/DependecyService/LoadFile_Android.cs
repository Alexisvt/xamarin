using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using CorrelacionHimnarioAdventista.Models.Abstract;
using CorrelacionHimnarioAdventista.Droid.DependecyService;
using HelperClasses;

[assembly: Dependency(typeof(LoadFile_Android))]

namespace CorrelacionHimnarioAdventista.Droid.DependecyService
{
    public class LoadFile_Android : ILoadFile
    {
        public Maybe<String> LoadJson(string fileName)
        {
            string jsonData;
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, fileName);

            if (!File.Exists(filePath))
            {
                return new Maybe<string>();
            }

            jsonData = File.ReadAllText(filePath);
            return new Maybe<string>(jsonData);
        }
    }
}