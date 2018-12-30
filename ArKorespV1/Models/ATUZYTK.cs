using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Arango.Client;

namespace ArKorespV1.Models
{
    public class ATUZYTK
    {
        //[DocumentProperty(Identifier = IdentifierType.Key)]
        [Key]
        public string ID { get; set; }
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }
        [Display(Name = "Hasło")]
        public string Password { get; set; }
        [Display(Name = "Status")]
        public int Status { get; set; }
        [Display(Name = "rola użytkownika")]
        public int UserRole { get; set; }
    }
}