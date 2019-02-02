using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    public class AutoSignedCollectionMember: CollectionMember
    {
        [Display(Name = "data aktualizacji")]
        public DateTime SDATA { get; set; }
        [Display(Name = "aktualizował")]
        public string SUZYTKOWNIK { get; set; }
    }
}