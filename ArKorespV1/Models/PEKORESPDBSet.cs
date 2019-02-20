using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    /// <summary>
    /// data registy entity 
    /// </summary>
    public class PEKORESPDBSet:ADBSet<PEKORESP>
    {
        //private string rejestr;
        /// <summary>
        /// constructor with collection prefix
        /// </summary>
        /// <param name="rejestr"></param>
        public PEKORESPDBSet(string rejestr)
        {
            if (db != null)
            {
                bool created;
                if (db.InitializeCollection<PEKORESP>(out created, rejestr.Replace( "_","").Replace("/","")))
                {
                    alreadycreated = created;
                }
                //this.rejestr = rejestr.Replace("_", "").Replace("/", "");
            }
        }
    }
}