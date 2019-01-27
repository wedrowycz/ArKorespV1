using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArKorespV1.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class PEZalacznikiZOgonem
    {
        public PEZALACZNIKI pEZALACZNIKI { get; set; }
        /// <summary>
        /// subitem up to 10th level
        /// </summary>
        public List<IdDescription> idDescriptions {get;set;}
    }
}