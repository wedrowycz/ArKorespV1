using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ArKorespV1.Models
{
    public class CollectionMember : ICollectionMember
    {
        public virtual string CollectionName()
        {
            var attr = GetType().GetCustomAttribute<CollectionNameAttribute>(false);
            if (attr == null)
            {
                return this.GetType().Name;
            }
            else
            {
                return attr.Name;
            }
        }
    }
}