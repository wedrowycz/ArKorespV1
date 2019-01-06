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
    /// Class defines routes from user - ATUZYTK to mail boxes - PESKRZPOCZT
    /// </summary>
    [CollectionType(ACollectionType.Edge)]
    [CollectionName("PESKRZPOCZTPRAC")]
    public class PESKRZPOCZTPRAC : CollectionMember, IDataRecord, IDictionaryAssignable
    {        
        public string ID { get ; set; }
        [Display(Name ="Obiekt źródłowy")]
        public string _from { get; set; }
        [Display(Name ="Obiekt docelowy")]
        public string _to { get; set; }
        [Display(Name ="Poziom uprawnień")]
        public int PERMISSIONTYPE { get; set; }
        [Display(Name ="Data modyfikacji")]
        public DateTime SDATA { get; set; }
        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            _id = dictionarry.ContainsKey("_id") ? dictionarry["_id"] : "";
            ID = _id.Replace("/", "_");
            PERMISSIONTYPE = dictionarry.ContainsKey("PERMISSIONTYPE") ? Int32.Parse(dictionarry["PERMISSIONTYPE"]) : 0;
            SDATA = dictionarry.ContainsKey("SDATA") ? DateTime.Parse(dictionarry["SDATA"]) : DateTime.Now;
            return true;
        }
    }
}