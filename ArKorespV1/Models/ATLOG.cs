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
    [CollectionName("ATLOG")]
    public class ATLOG :CollectionMember, IDataRecord, IDictionaryAssignable
    {        
        [Display(Name ="Id użytkownika")]
        public string UserId { get; set; }
        [Display(Name ="Data i czas logowania")]
        public string LoginDateTime { get; set; }
        [Display(Name ="adres logowania")]
        public string LoginUrl { get; set; }
        public string ID { get; set; }

        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            if (dictionarry != null)
            {
                _id = dictionarry.ContainsKey("_id")?dictionarry["_id"]: "";
                UserId = dictionarry.ContainsKey("UserId") ? dictionarry["UserId"] : "";
                LoginDateTime = dictionarry.ContainsKey("LoginDateTime") ? dictionarry["LoginDateTime"] : "";
                LoginUrl = dictionarry.ContainsKey("LoginUrl") ? dictionarry["LoginUrl"] : "";
            }
            return dictionarry != null;
        }
    }
}