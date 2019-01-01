using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    [CollectionName("PESKRZPOCZT")]
    public class PESKRZPOCZT : IDataRecord, IDictionaryAssignable
    {
        [Display(Name = "Id")]
        public string _id { get ; set ; }        
        public string ID { get ; set ; }
        public string DNAZWA { get; set; }
        [Display(Name ="data modyfikacji")]
        public DateTime? SDATA { get; set; }
        [Display(Name ="Symbol skrzynki")]
        [StringLength(50)]
        public string DSYMBOL { get; set; }
        [Display(Name ="email skrzynki")]
        [StringLength(80)]
        public string DEMAIL { get; set; }
        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            if (dictionarry != null)
            {
                _id = dictionarry.ContainsKey("_id") ? dictionarry["_id"] : "";

            }
            return dictionarry != null;
        }
    }
}