using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    /// <summary>
    /// user notes collection
    /// </summary>
    [CollectionType(Arango.Client.ACollectionType.Document)]
    public class UserNotes : AutoSignedCollectionMember, IDataRecord, IDictionaryAssignable
    {        
        /// <summary>
        /// collection property - note
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name ="notatka")]
        [MaxLength(10000)]
        public string DNOTATKA { get; set; }
        /// <summary>
        /// colection property - creation datetime
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="data dodania")]
        [UIHint("DateTimePicker")]
        [DataType(DataType.Date)]
        public DateTime DDATA { get; set; }

        /// <summary>
        /// collection property - reminder date
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "data przypomnienia")]
        [UIHint("DateTimePicker")]
        [DataType(DataType.Date)]
        public DateTime DPRZYPOMNIENIE { get; set; }
        /// <summary>
        /// non default assignment method
        /// </summary>
        /// <param name="dictionarry"> dictionary param</param>
        /// <returns>success</returns>
        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            return true;
        }
    }
}