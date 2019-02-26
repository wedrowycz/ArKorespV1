using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    /// <summary>
    /// binary data class without binary data itself
    /// for special purposes
    /// </summary>
    [CollectionName("PEZALACZNIKI")]
    [CollectionType(Arango.Client.ACollectionType.Document)]
    public class PEZALACZNIKIBD : CollectionMember, IDataRecord, IDictionaryAssignable
    {
        /// <summary>
        /// collection property - filename
        /// </summary>
        [Display(Name = "nazwa pliku")]
        public string DNAZWAPLIKU { get; set; }
        /// <summary>
        /// collection property version
        /// </summary>
        [Display(Name = "wersja")]
        public string DWERSJA { get; set; }
        /// <summary>
        /// collection property - description
        /// </summary>
        [Display(Name = "opis")]
        public string DOPIS { get; set; }
        /// <summary>
        /// collection property file date
        /// </summary>
        [Display(Name = "Data pliku")]
        public DateTime DDATA { get; set; }
        /// <summary>
        /// collection property - file size
        /// </summary>
        public int DROZMIARPLIKU { get; set; }
        /// <summary>
        /// non default assignement
        /// </summary>
        /// <param name="dictionarry">data</param>
        /// <returns>success</returns>
        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            return true;
        }
    }
}