
using HelperClasses;
namespace CorrelacionHimnarioAdventista.Models.Abstract
{
    public interface ILoadFile
    {
        Maybe<string> LoadJson(string fileName);
    }
}
