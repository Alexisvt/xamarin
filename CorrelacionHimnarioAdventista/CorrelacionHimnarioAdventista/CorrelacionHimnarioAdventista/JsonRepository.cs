using CorrelacionHimnarioAdventista.Models.Abstract;
using CorrelacionHimnarioAdventista.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CorrelacionHimnarioAdventista
{
    public class JsonRepository : IReadOnlyRepository
    {
        public JsonRepository()
        {
            ILoadFile service = DependencyService.Get<ILoadFile>();

            //fetching data from file
            ExamplePath = service.LoadJson("himnario.json");
        }

        public HimnoModel getHimnoByNumber(int number, string edition)
        {
            throw new NotImplementedException();
        }

        public HimnoModel getHimnoByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HimnoModel> HimnarioData { get; private set; }
        public string ExamplePath { get; set; }
    }
}
