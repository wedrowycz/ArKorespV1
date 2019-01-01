using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Arango.Client;
using ArKorespV1.Helpers;

namespace ArKorespV1.Models
{
    [CollectionName("ATUZYTK")]
    public class ATUZYTK : ADictionaryReader, IDictionaryAssignable
    {
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

        public ATUZYTK()
        { }
        public ATUZYTK(string iD, string userName, string password, int status, int userRole)
        {
            ID = iD ?? throw new ArgumentNullException(nameof(iD));
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Status = status;
            UserRole = userRole;
        }

        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            UserName = dictionarry["UserName"];
            Password = dictionarry["Password"];
            Status = Int32.Parse(dictionarry["Status"]);
            UserRole = Int32.Parse(dictionarry["Role"]);
            return true;
        }

        void ADictionaryReader.AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            UserName = dictionarry["UserName"];
            Password = dictionarry["Password"];
            Status = Int32.Parse(dictionarry["Status"]);
            UserRole = Int32.Parse(dictionarry["Role"]);
            //throw new NotImplementedException();
        }
    }
}