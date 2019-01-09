using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    /// <summary>
    /// Model class for user login controller 
    /// also includes methods to validate password
    /// </summary>
    public class User
    {
        [Display(Name ="Nazwa użytkownika")]
        public string UserName { get; set; }
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"> provided user name</param>
        /// <param name="password"> provided password</param>
        /// <returns> ATUZYTK object if user exists</returns>
        public ATUZYTK IsValid2(string username, string password)
        {
            ATUZYTKDBSet uds = new ATUZYTKDBSet();
            if (uds.alreadycreated)
            {
                ATUZYTK firstadmin = new ATUZYTK
                {
                    UserName = username,
                    Password = password,
                    UserRole = 2
                };

                uds.Insert(firstadmin);
                
            }

            if (uds.Get(" item.UserName =='"+ username.Trim()+"'"))
            {
                var uzytk = uds.Where(uz => uz.Password == password).FirstOrDefault();
                if (uzytk != null)
                {
                    return uzytk;
                }
            }
            return null;
        }

        public ATUZYTK IsValid(string username, string password)
        {
            ADBContext db = new ADBContext("127.0.0.1",8529,"obieg","tomasz","tomasz");
            var dane = db.GetData("FOR item IN ATUZYTK filter item.UserName == '" + username  + "' RETURN item");
            ATUZYTK uzytk = null;
            if (dane != null)
            {
                uzytk = new ATUZYTK(dane["_id"],
                                        dane["UserName"].Trim(),
                                        dane["Password"].Trim(), 
                                        Int32.Parse(dane["Status"]),
                                        Int32.Parse(dane["UserRole"]));
                
                if (password.Trim().Equals(uzytk.Password))
                {
                    return uzytk;
                }
            }

            return null;
        }
    }
}