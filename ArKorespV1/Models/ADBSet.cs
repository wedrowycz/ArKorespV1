﻿using Arango.Client;
using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ArKorespV1.Models
{
    /// <summary>
    /// Template class for ARango-db operations
    /// </summary>
    /// <typeparam name="T"> type for operations , see alfo requirements in class where clause</typeparam>
    public class ADBSet<T> : List<T>
        where T : class, IDictionaryAssignable, IDataRecord, ICollectionMember, new()
    {
        //TODO: change db connection parameters to web.config values
        public ADBContext db = new ADBContext("127.0.0.1", 8529, "obieg", "tomasz", "tomasz");
        public bool alreadycreated { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public ADBSet()
        {
            if (db != null)
            {
                bool created;
                if (db.InitializeCollection<T>(out created))
                {
                    alreadycreated = created;
                }
            }
        }
        public string CollectionName()
        {
            var attr = typeof(ATUZYTK).GetCustomAttribute<CollectionNameAttribute>(false);
            if (attr == null)
            {
                return typeof(T).GetType().Name;
            }
            else
            {
                return attr.Name;
            }            
        }

        public virtual bool Query(string condition)
        {
            return true;
        }

        
        public virtual T Insert(T newdata)
        {
            string newkey = db.Insert<T>(newdata);
            newdata.ID = newkey;
            return newdata;        
        }

        public virtual T GetById(string id)
        {
            T rezult = db.GetById<T>(id);
            return rezult;
        }

        public virtual string Delete(T datatodelete)
        {
            string rezult = db.Delete<T>(datatodelete);
            return rezult;
        }

        public virtual string Delete(string id)
        {
            string rezult = db.Delete<T>(id);
            return rezult;
        }

        public virtual T Update(T updatedata)
        {
            T rezult = db.Update(updatedata);
            return rezult;
        }

        public virtual bool Get(string condition)
        {
            List<T> rezult = db.Get<T>(condition);
            this.AddRange(rezult);
            return true;
        }

        public virtual List<V> GetOtherSide<V>(string key, ADirection direction)
            where V : IDataRecord , ICollectionMember,new()
        {
            //todo:check if T is Edge Collection
            List< V > lista  = db.GetOtherSide<T, V>(key, direction);
            return lista;
        }

        public virtual bool GetEdges(string key, ADirection direction)
        {
            //todo:check if T is Edge Collection
            this.AddRange(db.GetEdges<T>(key, direction));
            return true;
        }

        public virtual bool RemoveEdge(string _from, string _to)
        {
            return db.RemoveEdge<T>(_from, _to);
        }

        public virtual bool CreateEdge(string _from, string _to, Dictionary<string, object> elements)
        {
            return db.InsertEdge<T>(_from, _to, elements);
        }

    }
}