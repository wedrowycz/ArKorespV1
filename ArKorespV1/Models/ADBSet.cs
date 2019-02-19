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
        public ADBContext db = null;
            //new ADBContext("127.0.0.1", 8529, "obieg", "tomasz", "tomasz");
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
            //ADBContext db = null;
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
        
        /// <summary>
        /// inserts new data do T collection
        /// </summary>
        /// <param name="newdata">entity to be inserted into database</param>
        /// <returns>entity with _id obtained during insert</returns>
        public virtual T Insert(T newdata)
        {
            if (newdata == null)
            {
                return null;
            }
            string newkey = db.Insert<T>(newdata);
            newdata.ID = newkey;
            newdata._id = newkey;
            return newdata;        
        }
        /// <summary>
        /// gets T-type data from any collection referenced by id
        /// </summary>
        /// <param name="id">entity id</param>
        /// <returns>T-type data</returns>
        public virtual T GetById(string id)
        {
            T rezult = db.GetById<T>(id);
            return rezult;
        }

        /// <summary>
        /// delete record from collection passing T-tepe data
        /// </summary>
        /// <param name="datatodelete">entity</param>
        /// <returns>deleted entity id</returns>
        public virtual string Delete(T datatodelete)
        {
            string rezult = db.Delete<T>(datatodelete);
            return rezult;
        }

        /// <summary>
        /// delete record from collection, using it's id
        /// </summary>
        /// <param name="id">entity id</param>
        /// <returns>deleted record id</returns>
        public virtual string Delete(string id)
        {
            string rezult = db.Delete(id);
            return rezult;
        }

        public virtual T Update(T updatedata)
        {
            T rezult = db.Update(updatedata);
            return rezult;
        }

        /// <summary>
        /// retrieve all records from collection T
        /// </summary>
        /// <param name="condition">AQL filter where entity is named item</param>
        /// <returns>success</returns>
        public virtual bool Get(string condition)
        {
            List<T> rezult = db.Get<T>(condition);
            if (rezult != null)
            {
                this.AddRange(rezult);
            }
            return true;
        }

        /// <summary>
        /// retrieve all records from collection T on specified page
        /// </summary>
        /// <param name="condition">AQL filter where entity is named item</param>
        /// <param name="page">page number</param>
        /// <param name="pagesize">page size - number of returned records</param>
        /// <returns></returns>
        public virtual bool Get(string condition, int page, int pagesize)
        {
            List<T> rezult = db.Get<T>(condition,page,pagesize);
            if (rezult != null)
            {
                this.AddRange(rezult);
            }
            return true;
        }

        /// <summary>
        /// returns collection's element count
        /// </summary>
        /// <param name="filter">aql filter</param>
        /// <returns>number</returns>
        public int GetCount(string filter)
        {
            return db.GetCount<T>(filter);
        }
        /// <summary>
        /// initialize view - check for existence, creating it when missing
        /// </summary>
        /// <param name="viewName">name of a view</param>
        /// <returns>success</returns>
        public bool InitializeView(string viewName)
        {
            bool stworzone;
            return db.InitializeView(out stworzone,  viewName);
        }

        /// <summary>
        /// adds link to collection to view
        /// </summary>
        /// <param name="viewName">name of a view</param>
        /// <param name="collectionName">name of collection to be added</param>
        /// <returns></returns>
        public bool ModifyView(string viewName, string collectionName)
        {
            return db.ModifyView<T>(viewName, collectionName);
        }

    }
}