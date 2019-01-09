using Arango.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArKorespV1.Models
{
    /// <summary>
    /// Interface defines methods that informs dbcontext about collection type from atributes
    /// </summary>
    public interface ICollectionMember
    {
        string CollectionName();
        ACollectionType CollectionType();
    }
}
