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
    public class PEKORESP : AutoSignedCollectionMember, IDataRecord, IDictionaryAssignable
    {
        [Key]
        public string ID { get ; set ; }        
        [Display(Name ="kolejny numer")]
        public string DNUMER { get; set; }
        [Display(Name ="data przyjęcia")]
        [UIHint("DateTimePicker")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DDATA { get; set; }
        [Display(Name ="nr nadany przez kontrahenta")]
        public string DNRWGKONTRAH { get; set; }
        [Display(Name ="data nadania przez kontrahenta")]
        [UIHint("DateTimePicker")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DDATAWGKONTRAH { get; set; }
        [Display(Name ="dotyczy")]
        [StringLength(10000)]
        [DataType(DataType.MultilineText)]
        public string DDOTYCZY { get; set; }
        [Display(Name ="kontrahent ,nadawca")]
        [StringLength(1000)]
        public string DKONTRAHENT { get; set; }
        [Display(Name= "adres kontrahenta,nadawcy")]
        public string DKONTRAHENTADRES { get; set; }
        [Display(Name ="dekret - przeznaczenie")]
        public string DDEKRET { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "notatka")]
        [MaxLength(10000)]
        public string DNOTATKA { get; set; }
        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            return true;
        }
    }
}