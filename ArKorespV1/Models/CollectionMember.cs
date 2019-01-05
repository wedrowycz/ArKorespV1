using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Arango.Client;

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

        public ACollectionType CollectionType()
        {
            var attr = GetType().GetCustomAttribute<CollectionTypeAttribute>(false);
            if (attr == null)
            {
                return ACollectionType.Document;
            }
            else
            {
                return attr.CollectionType;
            }
        }
    }
}