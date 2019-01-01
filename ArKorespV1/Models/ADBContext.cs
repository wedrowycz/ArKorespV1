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

        public string Insert<T>(T newdata)
            where T : IDictionaryAssignable
        {
            var db = new ADatabase("obieg");
            var createresult = 
                db.Document.WaitForSync(true)
                .Create<T>(newdata.GetType().Name,newdata);
            if (createresult.Success)
            {
                var key = createresult.Value.String("_key");
                return key;
            }

            return "";
        }
          
    }
}