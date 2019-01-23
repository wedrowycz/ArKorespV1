using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    public class PEKORESP : CollectionMember, IDataRecord, IDictionaryAssignable
    {
        public string ID { get ; set ; }
        public DateTime SDATA { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "notatka")]
        [MaxLength(10000)]
        public string DNOTATKA { get; set; }
        [Display(Name ="kolejny numer")]
        public string DNUMER { get; set; }
        [Display(Name ="data przyjęcia")]
        public DateTime DDATA { get; set; }
        [Display(Name ="nr nadany przez kontrahenta")]
        public string DNRWGKONTRAH { get; set; }
        [Display(Name ="data nadania przez kontrahenta")]
        public DateTime DDATAWGKONTRAH { get; set; }
        [Display(Name ="dotyczy")]
        public string DDOTYCZY { get; set; }
        [Display(Name ="kontrahent/nadawca")]
        public string DKONTRAHENT { get; set; }
        [Display(Name= "adres kontrahenta/nadawcy")]
        public string DKONTRAHENTADRES { get; set; }
        [Display(Name ="dekret - przeznaczenie")]
        public string DDEKRET { get; set; }
        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            return true;
        }
    }
}