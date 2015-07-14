using CorrelacionHimnarioAdventista.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrelacionHimnarioAdventista.Models.Abstract
{
    public interface IReadOnlyRepository
    {
        HimnoModel getHimnoByNumber(int number, string edition);

        HimnoModel getHimnoByName(string name);
    }
}
