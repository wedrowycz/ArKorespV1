using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models.ZADANIA
{
    public class PEZADANIA : AutoSignedCollectionMember, IDataRecord, IDictionaryAssignable
    {
        [Display(Name ="treść zadania")]
        public string DNAZWA { get; set; }
        public string ID { get; set; }
        [Display(Name ="Treść - opis wykonania")]
        [DataType(DataType.MultilineText)]
        public string DTRESC { get; set; }
        [Display(Name ="status")]
        public int DSTATUS { get; set; }
        public string DPROCEDURAID { get; set; }

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