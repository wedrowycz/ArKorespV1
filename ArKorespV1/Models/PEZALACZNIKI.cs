using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    public class PEZALACZNIKI : CollectionMember, IDataRecord, IDictionaryAssignable
    {
        public string ID { get ; set ; }
        public DateTime SDATA { get; set; }
        [Display(Name ="nazwa pliku")]
        public string DNAZWAPLIKU { get; set; }
        [Display(Name ="plik jako taki")]
        public string DDANE { get; set; }
        public string DWERSJA { get; set; }
        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            return true;
        }
    }
}