using Arango.Client;
using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    /// <summary>
    /// register of correspondence base record definition
    /// </summary>
    [CollectionType(ACollectionType.Document)]    
    public class PEKORESP : AutoSignedCollectionMember, IDataRecord, IDictionaryAssignable
    {        
        /// <summary>
        /// collection's property - next number
        /// </summary>
        [Display(Name ="kolejny numer")]
        public string DNUMER { get; set; }
        /// <summary>
        /// collection's property - date
        /// </summary>
        [Required]
        [Display(Name ="data przyjęcia")]
        [UIHint("DateTimePicker")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DDATA { get; set; }
        /// <summary>
        /// collection's property - external number
        /// </summary>
        [Display(Name ="nr nadany przez kontrahenta")]
        public string DNRWGKONTRAH { get; set; }
        /// <summary>
        /// collection's property - external date
        /// </summary>
        [Display(Name ="data nadania przez kontrahenta")]
        [UIHint("DateTimePicker")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DDATAWGKONTRAH { get; set; }
        /// <summary>
        /// collection's property - correnspondence content
        /// </summary>
        [Display(Name ="dotyczy")]
        [StringLength(10000)]
        [DataType(DataType.MultilineText)]
        [Required]
        public string DDOTYCZY { get; set; }
        /// <summary>
        /// collection's property - sender
        /// </summary>
        [Display(Name ="kontrahent ,nadawca")]
        [StringLength(1000)]
        public string DKONTRAHENT { get; set; }
        /// <summary>
        /// collection's property - sender,receipient address
        /// </summary>
        [Display(Name= "adres kontrahenta,nadawcy")]
        public string DKONTRAHENTADRES { get; set; }
        /// <summary>
        /// collection's property - corrrespondence destination
        /// </summary>
        [Display(Name ="dekret - przeznaczenie")]
        public string DDEKRET { get; set; }
        /// <summary>
        /// collection's property - free notes
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name = "notatka")]
        [MaxLength(10000)]
        public string DNOTATKA { get; set; }
        /// <summary>
        /// assign not default values
        /// </summary>
        /// <param name="dictionarry"> extra contenets</param>
        /// <returns></returns>
        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            return true;
        }
    }
}