using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    public class PEKORESPDBSet:ADBSet<PEKORESP>
    {
        private string rejestr;

        public PEKORESPDBSet(string rejestr)
        {
            if (db != null)
            {
                bool created;
                if (db.InitializeCollection<UserNotes>(out created, rejestr))
                {
                    alreadycreated = created;
                }
                this.rejestr = rejestr;
            }
        }
    }
}