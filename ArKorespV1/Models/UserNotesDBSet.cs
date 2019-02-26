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
        /// <summary>
        /// default empty constructor
        /// </summary>
        public UserNotesDBSet()
        { }
        /// <summary>
        /// constructor - initialize collection with param
        /// </summary>
        /// <param name="prefix">prefix for collection</param>
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