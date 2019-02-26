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
        where T : class, IDictionaryAssignable, IDataRecord, ICollectionMember, IEdgeCollection, new()
    {
        /// <summary>
        /// get document collection from specified side
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="key">start key</param>
        /// <param name="direction">direction</param>
        /// <param name="depth">search depth</param>
        /// <returns></returns>
        public virtual List<V> GetOtherSide<V>(string key, ADirection direction, int depth)
            where V : IDataRecord, ICollectionMember, new()
        {
            //todo:check if T is Edge Collection
            List<V> lista = db.GetOtherSide<T, V>(key, direction, depth);
            return lista;
        }

        /// <summary>
        /// insert edge using strong typed data T
        /// </summary>        
        /// <param name="element"> element that contains data</param>
        /// <returns> edge element with id</returns>
        public virtual T CreateEdge(T element)            
        {
            return db.InsertEdge<T>(element);
        }

        /// <summary>
        /// get document collection from specified side, version without paging
        /// </summary>
        /// <typeparam name="V">result class</typeparam>
        /// <param name="key">start key</param>
        /// <param name="direction">search direction</param>
        /// <returns></returns>
        public virtual List<V> GetOtherSide<V>(string key, ADirection direction)
        where V : IDataRecord, ICollectionMember, new()
        {
            //todo:check if T is Edge Collection
            List<V> lista = db.GetOtherSide<T, V>(key, direction);
            return lista;
        }

        /// <summary>
        /// gets edges as list
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="direction">direction</param>
        /// <returns></returns>
        public virtual bool GetEdges(string key, ADirection direction)
        {
            //todo:check if T is Edge Collection
            this.AddRange(db.GetEdges<T>(key, direction));
            return true;
        }

        /// <summary>
        /// removes edges
        /// </summary>
        /// <param name="_from">start key</param>
        /// <param name="_to">end key</param>
        /// <returns></returns>
        public virtual bool RemoveEdge(string _from, string _to)
        {
            return db.RemoveEdge<T>(_from, _to);
        }

        /// <summary>
        /// insert edge using simple from - to with additional tags from dictionary
        /// </summary>
        /// <param name="_from"> id - from document collection</param>
        /// <param name="_to"> _id - to document collection </param>
        /// <param name="elements"> extra tags</param>
        /// <returns></returns>
        public virtual bool CreateEdge(string _from, string _to, Dictionary<string, object> elements)
        {
            return db.InsertEdge<T>(_from, _to, elements);
        }
    }
}