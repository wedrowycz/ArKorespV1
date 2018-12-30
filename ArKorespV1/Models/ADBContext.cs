using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Arango.Client;

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



    }
}