using Arango.Client;
using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models.ZADANIA
{
    /// <summary>
    /// Defines edge collection element for relation between PEZADANIA and PEPROCOBDOKPOZ
    /// </summary>
    [CollectionName("PEOBDOK")]
    [CollectionType(ACollectionType.Edge)]
    public class PEOBDOK : EdgeCollectionMember, IDataRecord, IDictionaryAssignable
    {        
        public string Skrzynka { get; set; }
        public string Korespondencja { get; set; }
        /// <summary>
        /// standard mapper from dictionary to class
        /// </summary>
        /// <param name="dictionarry"></param>
        /// <returns></returns>
        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            _id = dictionarry.ContainsKey("_id") ? dictionarry["_id"] : "";
            ID = _id.Replace("/", "_");
            Skrzynka = dictionarry.ContainsKey("Skrzynka") ? dictionarry["Skrzynka"] : "";
            Korespondencja = dictionarry.ContainsKey("Korespondencja") ? dictionarry["Korespondencja"] : "";
            SDATA = dictionarry.ContainsKey("SDATA") ? DateTime.Parse(dictionarry["SDATA"]) : DateTime.Now;
            _from = dictionarry.ContainsKey("_from") ? dictionarry["_from"] : "";
            _to = dictionarry.ContainsKey("_to") ? dictionarry["_to"] : "";
            return true;
        }
    }
}