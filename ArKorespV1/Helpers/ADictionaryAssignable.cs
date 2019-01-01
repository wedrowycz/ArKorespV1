using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArKorespV1.Helpers
{
    public interface IDictionaryAssignable
    {
        bool AssignFromDictionary(Dictionary<string, string> dictionarry);
    }
}
