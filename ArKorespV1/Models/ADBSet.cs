using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ArKorespV1.Models
{
    public class ADBSet<T> : List<T>
        where T : class, IDictionaryAssignable, IDataRecord, ICollectionMember, new()
    {
        //TODO: change db connection parameters to web.config values
        public ADBContext db = new ADBContext("127.0.0.1", 8529, "obieg", "tomasz", "tomasz");

        public ADBSet()
        {
            if (db != null)
            {
                db.InitializeCollection<T>();
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
    }
}