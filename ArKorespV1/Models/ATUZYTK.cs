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
        /// <summary>
        /// collection property - user name
        /// </summary>
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }
        /// <summary>
        /// collection property - password
        /// </summary>
        [Display(Name = "Hasło")]
        public string Password { get; set; }
        /// <summary>
        /// collection property - user status
        /// </summary>
        [Display(Name = "Status")]
        public int Status { get; set; }
        /// <summary>
        /// collection property - use role
        /// </summary>
        [Display(Name = "rola użytkownika")]
        public int UserRole { get; set; }

        /// <summary>
        /// empty default constructor
        /// </summary>
        public ATUZYTK()
        { }

        /// <summary>
        /// constructor with certain parameters
        /// </summary>
        /// <param name="iD"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="status"></param>
        /// <param name="userRole"></param>
        public ATUZYTK(string iD, string userName, string password, int status, int userRole)
        {
            ID = iD ?? throw new ArgumentNullException(nameof(iD));
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Status = status;
            UserRole = userRole;
        }

        /// <summary>
        /// non standard map function
        /// </summary>
        /// <param name="dictionarry">data to be assigned from</param>
        /// <returns>success</returns>
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

        
    }
}