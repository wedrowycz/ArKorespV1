using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ArKorespV1.Models
{
    public class ADBSet<T>: List<T>
        where T: class, IDictionaryAssignable, new()
    {
        public ADBContext db = new ADBContext("127.0.0.1", 8529, "obieg", "tomasz", "tomasz");
        
        public string CollectionName()
        {
            var attr = typeof(ATUZYTK).GetCustomAttribute<CollectionNameAttribute>(false);
            if (attr == null)
            {
                return typeof(T).GetType().Name;
            }
            else
            {
                return attr.Name;
            }            
        }

        public virtual bool Query(string condition)
        {
            return true;
        }


    }
}