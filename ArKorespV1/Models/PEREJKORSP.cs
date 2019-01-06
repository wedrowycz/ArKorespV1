using Arango.Client;
using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    [CollectionType(ACollectionType.Document)]
    [CollectionName("PEREJKORESP")]
    public class PEREJKORESP : CollectionMember, IDataRecord, IDictionaryAssignable
    {        
        [Key]
        public string ID { get ; set ; }
        [Display(Name ="Nazwa rejestru")]
        public string DNAZWA { get; set; }
        [Display(Name ="Symbol")]
        public string DSYMBOL { get; set; }
        [Display(Name ="Format numeracji")]
        public string DFORMAT { get; set; }
        [Display(Name ="Data aktualizacji")]
        public DateTime SDATA { get; set; }
        [Display(Name ="Kierunek")]
        public int DKIERUNEK { get; set; }
        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            _id = dictionarry.ContainsKey("_id") ? dictionarry["_id"] : "";
            ID = _id.Replace("/", "_");
            DSYMBOL = dictionarry.ContainsKey("DSYMBOL") ? dictionarry["DSYMBOL"] : "";
            DNAZWA = dictionarry.ContainsKey("DNAZWA") ? dictionarry["DNAZWA"] : "";
            SDATA = dictionarry.ContainsKey("SDATA") ? DateTime.Parse(dictionarry["SDATA"]):DateTime.Now;

            return true;
        }
    }
}