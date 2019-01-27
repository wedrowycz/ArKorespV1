using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    public class PEZALACZNIKIDBSet:ADBSet<PEZALACZNIKI>
    {
        private object uzytkownik;

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