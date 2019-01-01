using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    public class User
    {
        [Display(Name ="Nazwa użytkownika")]
        public string UserName { get; set; }
        [Display(Name = "Hasło")]
        public string Password { get; set; }

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