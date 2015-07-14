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

[assembly: Dependency(typeof(LoadFile_Android))]

namespace CorrelacionHimnarioAdventista.Droid.DependecyService
{
    public class LoadFile_Android : ILoadFile
    {
        public string LoadJson(string fileName)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, fileName);
            //return System.IO.File.ReadAllText(filePath);
            return filePath;
        }
    }
}