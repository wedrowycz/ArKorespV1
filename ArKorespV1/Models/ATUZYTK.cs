using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using Arango.Client;
using ArKorespV1.Helpers;

namespace ArKorespV1.Models
{
    /// <summary>
    /// User collection type definition
    /// </summary>
    [CollectionType(ACollectionType.Document)]
    [CollectionName("ATUZYTK")]
    public class ATUZYTK : CollectionMember, ADictionaryReader, IDictionaryAssignable , IDataRecord 
    {                             
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
            ID = dictionarry["_id"].Replace("/","_");
            UserName = dictionarry["UserName"];
            Password = dictionarry["Password"];
            Status = Int32.Parse(dictionarry["Status"]);
            UserRole = Int32.Parse(dictionarry["UserRole"]);
            return true;
        }

        void ADictionaryReader.AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            ID = dictionarry["_id"].Replace("/", "_");
            UserName = dictionarry["UserName"];
            Password = dictionarry["Password"];
            Status = Int32.Parse(dictionarry["Status"]);
            UserRole = Int32.Parse(dictionarry["UserRole"]);
            //throw new NotImplementedException();
        }

        public override string CollectionName()
        {
            var attr = typeof(ATUZYTK).GetCustomAttribute<CollectionNameAttribute>(false);
            if (attr == null)
            {
                return this.GetType().Name;
            }
            else
            {
                return attr.Name;
            }
        }
    }
}