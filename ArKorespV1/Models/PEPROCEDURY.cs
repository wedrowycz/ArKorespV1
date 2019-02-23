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
    /// edge collection for handling routes between tasks definitions
    /// </summary>
    [CollectionName("PEPROCEDURY")]
    [CollectionType(ACollectionType.Edge)]
    public class PEPROCEDURY:EdgeCollectionMember, IDataRecord, IDictionaryAssignable
    {
        /// <summary>
        /// collection property - name
        /// </summary>
        [Display(Name = "nazwa procedury")]
        public string DNAZWA { get; set; }
        /// <summary>
        /// collection property - description
        /// </summary>
        [Display(Name = "opis procedury")]
        public string DOPIS { get; set; }
        /// <summary>
        /// non default assignement
        /// </summary>
        /// <param name="dictionarry"></param>
        /// <returns></returns>
        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            _id = dictionarry.ContainsKey("_id") ? dictionarry["_id"] : "";
            ID = _id.Replace("/", "_");
            DNAZWA = dictionarry.ContainsKey("DNAZWA") ? dictionarry["DNAZWA"] : "";
            SDATA = dictionarry.ContainsKey("SDATA") ? DateTime.Parse(dictionarry["SDATA"]) : DateTime.Now;
            _from = dictionarry.ContainsKey("_from") ? dictionarry["_from"] : "";
            _to = dictionarry.ContainsKey("_to") ? dictionarry["_to"] : "";
            return true;
        }
    }
}