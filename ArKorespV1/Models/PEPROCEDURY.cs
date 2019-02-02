using Arango.Client;
using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    [CollectionName("PEPROCEDURY")]
    [CollectionType(ACollectionType.Edge)]
    public class PEPROCEDURY:EdgeCollectionMember, IDataRecord, IDictionaryAssignable
    {
        [Display(Name = "nazwa procedury")]
        public string DNAZWA { get; set; }
        [Display(Name = "opis procedury")]
        public string DOPIS { get; set; }
        public string ID { get ; set ; }
        public DateTime SDATA { get; set; }
        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            _id = dictionarry.ContainsKey("_id") ? dictionarry["_id"] : "";
            ID = _id.Replace("/", "_");
            DNAZWA = dictionarry.ContainsKey("DNAZWA") ? dictionarry["DNAZWA"] : "";
            SDATA = dictionarry.ContainsKey("SDATA") ? DateTime.Parse(dictionarry["SDATA"]) : DateTime.Now;
            _from = dictionarry.ContainsKey("_from") ? dictionarry["_from"] : "";
            _to = dictionarry.ContainsKey("_to") ? dictionarry["_to"] : "";
            return true;
        }
    }
}