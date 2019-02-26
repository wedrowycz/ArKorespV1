using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArKorespV1.ViewModels
{
    /// <summary>
    /// special container for complex view object
    /// </summary>
    public class IdDescription : CollectionMember
    {
        /// <summary>
        /// collection property - description
        /// </summary>
        public string DOPIS { get; set; }        
    }
}