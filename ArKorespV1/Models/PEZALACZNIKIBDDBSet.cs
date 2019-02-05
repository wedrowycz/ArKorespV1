using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    public class PEZALACZNIKIBDDBSet : ADBSet<PEZALACZNIKIBD>
    {
        private object uzytkownik;

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