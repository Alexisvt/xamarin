using System;
using System.IO;
using Xamarin.Forms;
using CorrelacionHimnarioAdventista.Models.Abstract;
using CorrelacionHimnarioAdventista.Droid;
using HelperClasses;

[assembly: Dependency(typeof(LoadFile_Android))]

namespace CorrelacionHimnarioAdventista.Droid
{
    public class LoadFile_Android : ILoadFile
    {
        public Maybe<string> LoadJson(string fileName)
        {
            string jsonData;
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
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