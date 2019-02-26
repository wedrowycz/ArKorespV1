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
    public class PEPROCOBDOKPOZWithTail
    {
        public PEPROCOBDOKPOZ pEPROCOBDOKPOZ { get;set;}
        /// <summary>
        /// elements that are directly linked to pEPROCOBDOKPOZ through PEPROCEDURY
        /// </summary>
        public List<PEPROCOBDOKPOZ> leaf { get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        public PEPROCOBDOKPOZWithTail()
        {
            leaf = new List<PEPROCOBDOKPOZ>();
        }
    }
}