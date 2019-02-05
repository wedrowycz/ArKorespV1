using Arango.Client;
using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    [CollectionType(ACollectionType.Edge)]
    [CollectionName("PEREJKORESPPRAC")]
    public class PEREJKORESPPRAC : EdgeCollectionMember, IDataRecord, IDictionaryAssignable
    {        
        public string ID { get ; set ; }
        public DateTime SDATA { get; set; }

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