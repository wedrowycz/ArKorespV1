using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    [CollectionType(Arango.Client.ACollectionType.Document)]
    public class UserNotes : CollectionMember, IDataRecord, IDictionaryAssignable
    {
        public string ID { get ; set ; }
        public DateTime SDATA { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name ="notatka")]
        [MaxLength(10000)]
        public string DNOTATKA { get; set; }
        [Display(Name ="data dodania")]
        public DateTime DDATA { get; set; }

        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            return true;
        }
    }
}