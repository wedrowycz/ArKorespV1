using System;

namespace ArKorespV1.Models
{
    internal class CollectionNameAttribute : Attribute
    {
        private string v;

        public CollectionNameAttribute(string v)
        {
            this.v = v;
        }

        public virtual string Name
        {
            get { return v; }
        }
    }
}