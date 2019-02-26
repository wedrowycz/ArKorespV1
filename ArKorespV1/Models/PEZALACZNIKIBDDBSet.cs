using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    /// <summary>
    /// binary data operation class - for each user
    /// </summary>
    public class PEZALACZNIKIBDDBSet : ADBSet<PEZALACZNIKIBD>
    {
        private object uzytkownik;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="uzytkownik">user name - for collection creation</param>
        public PEZALACZNIKIBDDBSet(string uzytkownik)
        {
            if (db != null)
            {
                bool created;
                if (db.InitializeCollection<PEZALACZNIKIBD>(out created, uzytkownik.Replace("_", "")))
                {
                    alreadycreated = created;
                }
                this.uzytkownik = uzytkownik.Replace("_", "");
            }
        }
    }
}