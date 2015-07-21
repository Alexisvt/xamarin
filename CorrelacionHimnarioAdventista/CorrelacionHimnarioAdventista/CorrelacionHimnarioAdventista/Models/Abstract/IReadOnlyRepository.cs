using CorrelacionHimnarioAdventista.Models.Concrete;
using HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrelacionHimnarioAdventista.Models.Abstract
{
    public interface IReadOnlyRepository
    {
        Maybe<HimnoModel> getHimnoByNumber(int number, string edition);

        Maybe<HimnoModel> getHimnoByName(string name);
    }
}
