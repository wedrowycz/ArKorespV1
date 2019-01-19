using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    /// <summary>
    /// User notes collection
    /// </summary>
    public class UserNotesDBSet : ADBSet<UserNotes>
    {
        protected string prefix;
        public UserNotesDBSet()
        { }
        public UserNotesDBSet(string prefix)
        {
            if (db != null)
            {
                bool created;
                if (db.InitializeCollection<UserNotes>(out created, prefix))
                {
                    alreadycreated = created;
                }
                this.prefix = prefix;
            }
        }


    }
}