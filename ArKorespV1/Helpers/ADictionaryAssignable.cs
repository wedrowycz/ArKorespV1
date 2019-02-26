using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArKorespV1.Helpers
{
    /// <summary>
    /// help interface
    /// </summary>
    public interface IDictionaryAssignable
    {
        /// <summary>
        /// help method
        /// </summary>
        /// <param name="dictionarry"></param>
        /// <returns></returns>
        bool AssignFromDictionary(Dictionary<string, string> dictionarry);
    }
}
