using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Arango.Client;
using ArKorespV1.Helpers;

namespace ArKorespV1.Models
{
    public class ADBContext
    {
        //connection settings
        private string hostname ="";
        private string dbname = "";
        private int dbport;
        private string username;
        private string password;

        public ADBContext(string hostname, int port , string dbname , string username, string password)
        {
            //todo: DBContext, need to be replaced with "connection strings in web.config"
            this.hostname = hostname;
            this.dbport = port;
            this.dbname = dbname;
            this.username = username;
            this.password = password;

            if (!ASettings.HasConnection("obieg"))
            {
                ASettings.AddConnection("obieg", hostname, dbport, false, dbname, username, password);
            }
        }

        /// <summary>
        /// retrieve one record then call s=assign from caller
        /// </summary>
        /// <param name="query"> query text</param>
        /// <param name="dictreader">object where data are assigned</param>
        /// <returns>if data are present</returns>
        public bool GetRecord( string query, ADictionaryReader dictreader)
        {
            Dictionary<string, string> dict = GetData(query);
            if (dict != null)
            {
                dictreader.AssignFromDictionary(dict);
                return true;
            }
            else
            {
                return false;
            }
        }

        //retrieve one record
        public Dictionary<string,string> GetData(string query)
        {
            var db = new ADatabase("obieg");

            var coll = db.Query.Aql(query).ToDocuments();
            if (coll.Success)
            {
                Dictionary<string, string> rezult = new Dictionary<string, string>();
                foreach (var document in coll.Value)
                {
                    foreach (string klucz in document.Keys)
                    {
                        rezult.Add(klucz, document.String(klucz));
                    }
                }
                return rezult;
            }
            else
            return null;
        }


        public bool GetRecords(string query, Func<Dictionary<string,string>,bool> addmethod, int datacount, int offset)
        {
            var db = new ADatabase("obieg");

            var coll = db.Query.Aql(query).ToDocuments();
            if (coll.Success)
            {
                
                foreach (var document in coll.Value)
                {
                    Dictionary<string, string> rezult = new Dictionary<string, string>();
                    foreach (string klucz in document.Keys)
                    {
                        rezult.Add(klucz, document.String(klucz));
                    }
                    addmethod(rezult);

                }
                return true;
            }
            else
                return false;
            
        }

        /// <summary>
        /// returns one (?) document provided by document id
        /// </summary>
        /// <typeparam name="T"> class which type is collection</typeparam>
        /// <param name="id">documents id</param>
        /// <returns>whole document of type T</returns>
        public T GetById<T>(string id)
            where T : IDataRecord,  new()
        {
            var db = new ADatabase("obieg");
            var getbyidresult = db.Document.Get<T>(id.Replace("_","/"));
            if (getbyidresult.Success)
            {
                //var dtaresult = new T();
                var dtaresult = getbyidresult.Value;
                dtaresult.ID = id;
                return dtaresult;
            }
            else
                return default(T);
        }

        public string Insert<T>(T newdata)
            where T : IDataRecord
        {
            var db = new ADatabase("obieg");
            var createresult = 
                db.Document.WaitForSync(true)
                .Create<T>(newdata.GetType().Name,newdata);
            if (createresult.Success)
            {
                var key = createresult.Value.String("_id");
                return key;
            }

            return "";
        }

        public string Delete<T>(T datatodelete)
            where T : IDataRecord
        {
            var db = new ADatabase("obieg");
            var deleteresult = db.Document.Delete(datatodelete.ID);
            if (deleteresult.Success)
                return datatodelete.ID;
            else
                return "";
        }

        public string Delete<T>(string datatodelete)
           where T : IDataRecord
        {
            var db = new ADatabase("obieg");
            var deleteresult = db.Document.Delete(datatodelete);
            if (deleteresult.Success)
                return datatodelete;
            else
                return "";
        }

        public T Update<T>(T updaterecord)
            where T : IDataRecord
        {
            var db = new ADatabase("obieg");
            var updaterezult = db.Document.Update<T>(updaterecord.ID.Replace("_","/"), updaterecord);

            if (updaterezult.Success)
            {
                return updaterecord;
            }

            return default(T);
        }

        //retrieve all records from collection T
        public List<T> Get<T>(string filter)
            where T : IDataRecord , new() 
        {
            var db = new ADatabase("obieg");
            var tmpobj = new T();
            string aquery = "FOR item IN " + tmpobj.GetType().Name +
                (filter != "" ? " FILTER " + filter : "") +
                " RETURN item";
            var getrezult = db.Query.Aql(aquery).ToList<T>();
            if(getrezult.Success)
            {
                for (int i = 0; i < getrezult.Value.Count; i++)
                {
                    getrezult.Value[i].ID = getrezult.Value[i]._id.Replace("/","_");
                }
                return getrezult.Value;
            }
           
            return default(List<T>);
        }

        public bool InitializeCollection<T>()
            where T : IDataRecord, new()
        {
            var db = new ADatabase("obieg");
            var tmpobj = new T();
            var colection = db.Collection.Get(tmpobj.GetType().Name);
            if (!colection.Success)
            {
                var createCollectionResult = db.Collection
                    .KeyGeneratorType(AKeyGeneratorType.Autoincrement)
                    .WaitForSync(true)
                    .Create(tmpobj.GetType().Name);
                if (!createCollectionResult.Success)
                {
                    return false;
                }
            }

            return true;
        }


    }
}