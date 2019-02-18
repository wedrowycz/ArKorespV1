using ArKorespV1.Models;
using ArKorespV1.Models.ZADANIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArKorespV1.ViewModels
{
    /// <summary>
    /// html view container class
    /// </summary>
    public class PEZADANIEZPROCEDURA
    {
        public PEZADANIA zadanie { get; set; }
        public PEPROCOBDOKPOZ procedura { get; set; }
        public PEOBDOK obieg { get; set; }
        public PEKORESP koresp { get; set; }
    }
}