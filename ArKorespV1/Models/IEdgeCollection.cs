using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArKorespV1.Models
{
    /// <summary>
    /// edge collection base definition
    /// </summary>
    public interface IEdgeCollection
    {
        /// <summary>
        /// from document - key
        /// </summary>
        string _from { get; set; }
        /// <summary>
        /// to document - key
        /// </summary>
        string _to { get; set; }
    }
}
