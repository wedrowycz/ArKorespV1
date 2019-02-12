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
    /// users logins register
    /// </summary>
    [CollectionType(ACollectionType.Document)]
    [CollectionName("ATLOG")]
    public class ATLOG :CollectionMember, IDataRecord, IDictionaryAssignable
    {
        /// <summary>
        /// collection's property - users id
        /// </summary>
        [Display(Name ="Id użytkownika")]
        public string UserId { get; set; }
        /// <summary>
        /// collection's property -login datetime
        /// </summary>
        [Display(Name ="Data i czas logowania")]
        public string LoginDateTime { get; set; }
        /// <summary>
        /// collection's property - login url
        /// </summary>
        [Display(Name ="adres logowania")]
        public string LoginUrl { get; set; }        
        /// <summary>
        /// non default proerty assignment
        /// </summary>
        /// <param name="dictionarry">dictionary of parameters</param>
        /// <returns>success</returns>
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