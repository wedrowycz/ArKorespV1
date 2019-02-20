using Arango.Client;
using System;

namespace ArKorespV1.Models
{
    /// <summary>
    /// Collection type atribute class
    /// </summary>
    public class CollectionTypeAttribute : Attribute
    {
        private ACollectionType collectiontype;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="collectiontype">type of collection</param>
        public CollectionTypeAttribute(ACollectionType collectiontype)
        {
            this.collectiontype = collectiontype;
        }

        /// <summary>
        /// collection type readonly property
        /// </summary>
        public virtual ACollectionType CollectionType 
        {
            get { return this.collectiontype; }
        }
    }
}