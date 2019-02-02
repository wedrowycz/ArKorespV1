using Arango.Client;
using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    [CollectionName("PEPROCOBDOK")]
    [CollectionType(ACollectionType.Document)]

    public class PEPROCOBDOK : AutoSignedCollectionMember, IDataRecord, IDictionaryAssignable
    {
        public string ID { get ; set ; }
        [Display(Name ="nazwa")]
        public string DNAZWA { get; set; }
        [Display(Name = "opis scenariusza")]
        [DataType(DataType.MultilineText)]
        public string DOPIS { get; set; }
        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            _id = dictionarry.ContainsKey("_id") ? dictionarry["_id"] : "";
            //_key = dictionarry.ContainsKey("_key") ? dictionarry["_key"] : "";
            ID = _id.Replace("/", "_");            
            DNAZWA = dictionarry.ContainsKey("DNAZWA") ? dictionarry["DNAZWA"] : "";
            DOPIS = dictionarry.ContainsKey("DOPIS") ? dictionarry["DOPIS"] : "";
            return true;
        }
    }
}