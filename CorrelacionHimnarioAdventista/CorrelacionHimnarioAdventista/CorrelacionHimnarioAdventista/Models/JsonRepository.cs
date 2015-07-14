using CorrelacionHimnarioAdventista.Models.Abstract;
using CorrelacionHimnarioAdventista.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CorrelacionHimnarioAdventista.Models
{
    public class JsonRepository : IReadOnlyRepository
    {
        #region Fields
        private string _jsonString;
        #endregion

        #region Constructors
        public JsonRepository()
        {
            ILoadFile service = DependencyService.Get<ILoadFile>();

            JsonString = service.LoadJson("himnarioDB.json");

            if (!String.IsNullOrEmpty(JsonString))
            {
                throw Nul
            }
        }
        #endregion

        #region IReadOnlyRepository Interface Implementation
        public HimnoModel getHimnoByNumber(int number, string edition)
        {
            throw new NotImplementedException();
        }

        public HimnoModel getHimnoByName(string name)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Methods
        protected virtual IEnumerable<HimnoModel> MapperJson(string jsondata)
        {
            return null;
        }
        #endregion

        #region Properties
        public IEnumerable<HimnoModel> HimnarioData { get; private set; }
        private virtual string JsonString
        {
            get { return _jsonString; }
            set { _jsonString = value; }
        }
        #endregion
    }
}
