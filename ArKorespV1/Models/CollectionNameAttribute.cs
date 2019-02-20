using System;

namespace ArKorespV1.Models
{
    /// <summary>
    /// collection name atribute class
    /// </summary>
    public class CollectionNameAttribute : Attribute
    {
        private string v;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="v"></param>
        public CollectionNameAttribute(string v)
        {
            this.v = v;
        }

        /// <summary>
        /// atribute value - collection name read only property
        /// </summary>
        public virtual string Name
        {
            get { return v; }
        }
    }
}