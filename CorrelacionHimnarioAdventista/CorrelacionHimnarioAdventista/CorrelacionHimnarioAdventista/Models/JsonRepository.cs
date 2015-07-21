using CorrelacionHimnarioAdventista.Models.Abstract;
using CorrelacionHimnarioAdventista.Models.Concrete;
using HelperClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;

namespace CorrelacionHimnarioAdventista.Models
{
    public class JsonRepository : IReadOnlyRepository
    {
        #region Fields
        #endregion

        #region Constructors
        public JsonRepository()
        {
            //Loading data to Himnario Collection
            this.MapperJson();
        }
        #endregion

        #region IReadOnlyRepository Interface Implementation
        public Maybe<HimnoModel> getHimnoByNumber(int number, string edition)
        {
            Maybe<HimnoModel> result;

            if (number != 0 && !String.IsNullOrWhiteSpace(edition))
            {

                if (edition.Equals("Old"))
                {
                    result = new Maybe<HimnoModel>(HimnarioData
                        .Where((h) => h.Numbers.Old == number).First()
                        );
                }
                else
                {
                    result = new Maybe<HimnoModel>(HimnarioData
                         .Where((h) => h.Numbers.New == number).First()
                         );
                }
                
            }
            else
            {
                //returning and empty collection of Maybe
                result = new Maybe<HimnoModel>();
            }

            return result;
        }

        public Maybe<HimnoModel> getHimnoByName(string name)
        {
            Maybe<HimnoModel> result;

            if (!String.IsNullOrWhiteSpace(name))
            {
                //just return the first result
                result = new Maybe<HimnoModel>(
                    HimnarioData
                    .Where((h) => h.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    .First());
            }
            else
            {
                //returning and empty collection of Maybe
                result = new Maybe<HimnoModel>();
            }

            return result;
        }
        #endregion

        #region Methods
        protected virtual void MapperJson()
        {
            string jsonString = "";

            var assembly = typeof(JsonRepository).GetTypeInfo().Assembly;
            Stream stream = assembly
                .GetManifestResourceStream("CorrelacionHimnarioAdventista.himnario.json");

            using (var reader =  new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }

            if (!String.IsNullOrEmpty(jsonString))
            {
                //begin json deserialization from jsondata
                HimnarioData = JsonConvert.DeserializeObject<IEnumerable<HimnoModel>>(jsonString);
            }
        }
        #endregion

        #region Properties
        public IEnumerable<HimnoModel> HimnarioData { get; private set; }
        #endregion
    }
}
