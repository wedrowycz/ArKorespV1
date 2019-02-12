using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    /// <summary>
    /// class defines routes between Document collections 
    /// - edges : _from ,_to are route's ends
    /// </summary>
    public class EdgeCollectionMember: AutoSignedCollectionMember, IEdgeCollection
    {
        [Display(Name = "Obiekt źródłowy - skrzynka")]
        public string _from { get; set; }
        [Display(Name = "Obiekt docelowy - użytkownik")]
        public string _to { get; set; }
    }
}