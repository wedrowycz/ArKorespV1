using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    /// <summary>
    /// binary data operation class
    /// </summary>
    public class PEZALACZNIKIDBSet:ADBSet<PEZALACZNIKI>
    {
        private object uzytkownik;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="uzytkownik">user name for collection operation</param>
        public PEZALACZNIKIDBSet(string uzytkownik)
        {
            if (db != null)
            {
                bool created;
                if (db.InitializeCollection<PEZALACZNIKI>(out created, uzytkownik.Replace("_", "")))
                {
                    alreadycreated = created;
                }
                this.uzytkownik = uzytkownik.Replace("_", "");
            }
        }
    }
}