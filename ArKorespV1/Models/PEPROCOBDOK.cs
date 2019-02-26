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
    /// flow procedure class
    /// </summary>
    [CollectionName("PEPROCOBDOK")]
    [CollectionType(ACollectionType.Document)]

    public class PEPROCOBDOK : AutoSignedCollectionMember, IDataRecord, IDictionaryAssignable
    {  
        /// <summary>
        /// name of procedure
        /// </summary>
        [Display(Name ="nazwa")]
        public string DNAZWA { get; set; }
        /// <summary>
        /// description
        /// </summary>
        [Display(Name = "opis scenariusza")]
        [DataType(DataType.MultilineText)]
        public string DOPIS { get; set; }
        /// <summary>
        /// non default assignement
        /// </summary>
        /// <param name="dictionarry">data to be assigned from</param>
        /// <returns>success</returns>
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