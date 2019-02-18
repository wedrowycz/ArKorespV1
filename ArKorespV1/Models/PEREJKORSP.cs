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
    /// correspondence register definition
    /// </summary>
    [CollectionType(ACollectionType.Document)]
    [CollectionName("PEREJKORESP")]
    public class PEREJKORESP : AutoSignedCollectionMember, IDataRecord, IDictionaryAssignable
    {        
        /// <summary>
        /// collection's property - name
        /// </summary>
        [Display(Name ="Nazwa rejestru")]
        public string DNAZWA { get; set; }
        /// <summary>
        /// collection's property 
        /// </summary>
        [Display(Name ="Symbol")]
        public string DSYMBOL { get; set; }
        /// <summary>
        /// collections's property - numbering format
        /// </summary>
        [Display(Name ="Format numeracji")]
        public string DFORMAT { get; set; }        
        /// <summary>
        /// collection's property - direction
        /// </summary>
        [Display(Name ="Kierunek")]
        public int? DKIERUNEK { get; set; }
        /// <summary>
        /// non standard assignement method
        /// </summary>
        /// <param name="dictionarry">dictionary of data</param>
        /// <returns>success</returns>
        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            _id = dictionarry.ContainsKey("_id") ? dictionarry["_id"] : "";
            ID = _id.Replace("/", "_");
            DSYMBOL = dictionarry.ContainsKey("DSYMBOL") ? dictionarry["DSYMBOL"] : "";
            DNAZWA = dictionarry.ContainsKey("DNAZWA") ? dictionarry["DNAZWA"] : "";
            SDATA = dictionarry.ContainsKey("SDATA") ? DateTime.Parse(dictionarry["SDATA"]):DateTime.Now;

            return true;
        }
    }
}