using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArKorespTexts
{
    class TestEntityDBSet : ADBSet<TestEntity>
    {
        public TestEntityDBSet(string prefix)
        {
            if (db != null)
            {
                bool created;
                if (db.InitializeCollection<TestEntity>(out created, prefix.Replace("_", "").Replace("/", "")))
                {
                    alreadycreated = created;
                }
                
            }
        }
    }
}
