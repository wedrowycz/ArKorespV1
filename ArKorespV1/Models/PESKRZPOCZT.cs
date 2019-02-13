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
    /// 
    /// </summary>
    [CollectionType(ACollectionType.Document)]
    [CollectionName("PESKRZPOCZT")]
    public class PESKRZPOCZT : AutoSignedCollectionMember, IDataRecord, IDictionaryAssignable
    {
        /// <summary>
        /// collection's property - mailbox name
        /// </summary>
        [Display(Name ="Nazwa skrzynki")]
        public string DNAZWA { get; set; }
        /// <summary>
        /// collection's property - mailbox short name
        /// </summary>
        [Display(Name ="Symbol skrzynki")]
        [StringLength(50)]
        public string DSYMBOL { get; set; }
        /// <summary>
        /// collection's property - email associated
        /// </summary>
        [Display(Name ="email skrzynki")]
        [StringLength(80)]
        public string DEMAIL { get; set; }
        [Display(Name ="użytkownik podstawowy")]
        public string DUZYTKOWNIKPODSTID { get; set; }
        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            if (dictionarry != null)
            {
                _id = dictionarry.ContainsKey("_id") ? dictionarry["_id"] : "";
                ID = _id.Replace("/","_");
                DSYMBOL = dictionarry.ContainsKey("DSYMBOL") ? dictionarry["DSYMBOL"] : "";
                DNAZWA = dictionarry.ContainsKey("DNAZWA") ? dictionarry["DNAZWA"] : "";
                DEMAIL = dictionarry.ContainsKey("DEMAIL") ? dictionarry["DEMAIL"] : "";
                SDATA = dictionarry.ContainsKey("SDATA") ? DateTime.Parse(dictionarry["SDATA"]):DateTime.Now;
            }
            return dictionarry != null;
        }
    }
}