using Arango.Client;
using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArKorespV1.Models
{
    /// <summary>
    /// Class that extends ADBSet for graph queries
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AEdgeDBSet<T>:ADBSet<T>
        where T : class, IDictionaryAssignable, IDataRecord, ICollectionMember, new()
    {
        public virtual List<V> GetOtherSide<V>(string key, ADirection direction, int depth)
            where V : IDataRecord, ICollectionMember, new()
        {
            //todo:check if T is Edge Collection
            List<V> lista = db.GetOtherSide<T, V>(key, direction, depth);
            return lista;
        }
    }
}