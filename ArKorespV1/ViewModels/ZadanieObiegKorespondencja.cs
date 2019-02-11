using ArKorespV1.Models;
using ArKorespV1.Models.ZADANIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArKorespV1.ViewModels
{
    /// <summary>
    /// complex template for tasks view
    /// </summary>
    public class ZadanieObiegKorespondencja
    {
        PEZADANIA zadania { get; set; } 
        PEOBDOK obieg { get; set; }
        PEKORESP korespondencja { get; set; } 
    }
}