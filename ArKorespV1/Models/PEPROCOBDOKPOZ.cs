using Arango.Client;
using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    [CollectionName("PEPROCOBDOKPOZ")]
    [CollectionType(ACollectionType.Document)]
    public class PEPROCOBDOKPOZ : AutoSignedCollectionMember, IDataRecord, IDictionaryAssignable
    {
        [Key]
        public string ID { get ; set ; }
        [Display(Name = "nazwa etapu")]
        public string DNAZWA { get; set; }
        [Display(Name = "opis etapu")]
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