using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    /// <summary>
    /// encapsulates most used fields within collections
    /// </summary>
    public class AutoSignedCollectionMember: CollectionMember
    {
        /// <summary>
        /// data modification datetime
        /// </summary>
        [Display(Name = "data aktualizacji")]        
        public DateTime SDATA { get; set; }
        /// <summary>
        /// user that modifies or created data
        /// </summary>
        [Display(Name = "aktualizował")]
        public string SUZYTKOWNIK { get; set; }
    }
}