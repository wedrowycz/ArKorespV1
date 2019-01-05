using Arango.Client;
using System;

namespace ArKorespV1.Models
{
    internal class CollectionTypeAttribute : Attribute
    {
        private ACollectionType collectiontype;

        public CollectionTypeAttribute(ACollectionType collectiontype)
        {
            this.collectiontype = collectiontype;
        }

        public virtual ACollectionType CollectionType 
        {
            get { return this.collectiontype; }
        }
    }
}