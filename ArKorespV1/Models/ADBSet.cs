using Arango.Client;
using ArKorespV1.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public ADBContext db =  new ADBContext("127.0.0.1", 8529, "obieg", "tomasz", "tomasz");
        public bool alreadycreated { get; set; }

        /// <summary>
        /// default constructor perform collection existnece check
        /// </summary>
        public ADBSet()
        {
            string hostvalue = ConfigurationManager.AppSettings["hostname"];
            string portavalue = ConfigurationManager.AppSettings["port"];
            string databasename = ConfigurationManager.AppSettings["databasename"];
            string user = ConfigurationManager.AppSettings["user"];
            string dbpassword = ConfigurationManager.AppSettings["password"];
            ADBContext db = null;
            if (hostvalue == null || portavalue == null || databasename == null || user == null || dbpassword == null)
            {
                db = new ADBContext("127.0.0.1", 8529, "obieg", "tomasz", "tomasz");
            }
            else
            {
                db = new ADBContext(hostvalue, Int32.Parse(portavalue), databasename, user, dbpassword);
            }

            if (db != null)
            {
                if (db.InitializeCollection<T>(out bool created))
                {
                    alreadycreated = created;
                }
            }
        }
        /// <summary>
        /// method provides T type collection name 
        /// </summary>
        /// <returns>string - collection name</returns>
        public virtual string CollectionName()
        {
            return new T().CollectionName();
        }

        /// <summary>
        /// virtual Query
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public virtual bool Query(string condition)
        {
            return true;
        }
        
        public virtual T Insert(T newdata)
        {
            string newkey = db.Insert<T>(newdata);
            newdata.ID = newkey;
            newdata._id = newkey;
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
            if (rezult != null)
            {
                this.AddRange(rezult);
            }
            return true;
        }


        public virtual bool Get(string condition, int page, int pagesize)
        {
            List<T> rezult = db.Get<T>(condition,page,pagesize);
            if (rezult != null)
            {
                this.AddRange(rezult);
            }
            return true;
        }

        public int GetCount(string filter)
        {
            return db.GetCount<T>(filter);
        }

 


    }
}