using Arango.Client;
using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    /// <summary>
    /// Defines edge collection element for relation between PEKORESP and PEZALACZNIKI
    /// </summary>
    [CollectionName("PEKORESPZAL")]
    [CollectionType(ACollectionType.Edge)]
    public class PEKORESPZAL : EdgeCollectionMember, IDataRecord, IDictionaryAssignable
    {               
        /// <summary>
        /// non default assignement method
        /// </summary>
        /// <param name="dictionarry"></param>
        /// <returns></returns>
        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            _id = dictionarry.ContainsKey("_id") ? dictionarry["_id"] : "";
            ID = _id.Replace("/", "_");            
            SDATA = dictionarry.ContainsKey("SDATA") ? DateTime.Parse(dictionarry["SDATA"]) : DateTime.Now;
            _from = dictionarry.ContainsKey("_from") ? dictionarry["_from"] : "";
            _to = dictionarry.ContainsKey("_to") ? dictionarry["_to"] : "";
            return true;
        }
    }
}