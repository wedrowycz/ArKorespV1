using Arango.Client;
using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models.ZADANIA
{
    /// <summary>
    /// Entity class for tasks
    /// </summary>
    [CollectionType(ACollectionType.Document)]
    [CollectionName("PEZADANIA")]
    public class PEZADANIA : AutoSignedCollectionMember, IDataRecord, IDictionaryAssignable
    {
        /// <summary>
        /// collection property - task name
        /// </summary>
        [Display(Name ="nazwa zadania")]
        public string DNAZWA { get; set; }
        /// <summary>
        /// collection property task details
        /// </summary>
        [Display(Name ="Treść - opis wykonania")]
        [DataType(DataType.MultilineText)]
        public string DTRESC { get; set; }
        /// <summary>
        /// collection property task status
        /// </summary>
        [Display(Name ="status")]
        public int DSTATUS { get; set; }
        /// <summary>
        /// collection property procedure id
        /// </summary>
        public string DPROCEDURAID { get; set; }
        /// <summary>
        /// non default assignement
        /// </summary>
        /// <param name="dictionarry"></param>
        /// <returns></returns>
        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            _id = dictionarry.ContainsKey("_id") ? dictionarry["_id"] : "";
            ID = _id.Replace("/", "_");
            DTRESC = dictionarry.ContainsKey("DTRESC") ? dictionarry["DTRESC"] : "";
            DSTATUS = dictionarry.ContainsKey("DSTATUS") ? Int32.Parse(dictionarry["DSTATUS"]) : 0;
            DPROCEDURAID = dictionarry.ContainsKey("DPROCEDURAID") ? dictionarry["DPROCEDURAID"] : "";
            return true;
        }
    }
}