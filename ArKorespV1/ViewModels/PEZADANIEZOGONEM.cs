using ArKorespV1.Models;
using ArKorespV1.Models.ZADANIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArKorespV1.ViewModels
{
    public class PEZADANIEZOGONEM
    {
        public PEZADANIA pEZADANIA { get; set; }
        public PESKRZPOCZT pESKRZPOCZT { get; set; }
        public string extradane { get; set; }
    }
}