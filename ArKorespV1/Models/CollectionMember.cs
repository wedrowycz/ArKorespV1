using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using Arango.Client;

namespace ArKorespV1.Models
{
    /// <summary>
    /// Class tha represents collection's base properties 
    /// _id (ID),_key and _rev
    /// </summary>
    public class CollectionMember : ICollectionMember
    {
        /// <summary>
        /// revision
        /// </summary>
        [Display(Name ="wersja wpisu")]
        public string _rev { get; set; }
        /// <summary>
        /// automaticalyy driven id
        /// </summary>
        public string _id { get; set; }
        /// <summary>
        /// _id converted to safe model
        /// </summary>
        [Key]   
        public string ID { get; set; }
        //public string _key { get; set; }
        /// <summary>
        /// retrieves collection's name from class name or annotation (when provided)
        /// </summary>
        /// <returns>collection's name</returns>
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

        /// <summary>
        /// retrieves collection's type from annotation (when provided) or simply document-type
        /// </summary>
        /// <returns>ACollectionType type of collection</returns>
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