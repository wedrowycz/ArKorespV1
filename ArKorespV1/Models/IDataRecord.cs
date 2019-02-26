using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArKorespV1.Models
{
    /// <summary>
    /// basic arando document 
    /// </summary>
    public interface IDataRecord
    {
        /// <summary>
        /// document id
        /// </summary>
        string _id { get; set; }
        /// <summary>
        /// document revision
        /// </summary>
        string _rev { get; set;}
        /// <summary>
        /// collection property - ID without slash
        /// </summary>
        string ID { get; set; }
    }
}
