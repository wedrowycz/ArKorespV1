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
        private string hostname = "";
        private string dbname = "";
        private int dbport;
        private string username;
        private string password;
        protected string collectionprefix = "";

        public ADBContext(string hostname, int port, string dbname, string username, string password)
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
        public bool GetRecord(string query, ADictionaryReader dictreader)
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
        public Dictionary<string, string> GetData(string query)
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

        public List<T> GetData<T>(string aql)
        where T :  new()
        {
            var db = new ADatabase("obieg");
            var tmpobj = new T();
            string aquery = aql;
            var getrezult = db.Query.Aql(aquery).ToList<T>();
            if (getrezult.Success)
            {
                //for (int i = 0; i < getrezult.Value.Count; i++)
                //{
                //    getrezult.Value[i].ID = getrezult.Value[i]._id.Replace("/", "_");
                //}
                return getrezult.Value;
            }

            return default(List<T>);
        }

        public bool GetRecords(string query, Func<Dictionary<string, string>, bool> addmethod, int datacount, int offset)
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
            where T : IDataRecord, new()
        {
            var db = new ADatabase("obieg");
            var getbyidresult = db.Document.Get<T>(id.Replace("_", "/"));
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
            where T : IDataRecord, ICollectionMember, new()
        {
            if (newdata == null)
            {
                return null;
            }
            var db = new ADatabase("obieg");
            var createresult =
                db.Document.WaitForSync(true)
                .Create<T>(collectionprefix + newdata.CollectionName(), newdata);
            if (createresult.Success)
            {
                var key = createresult.Value.String("_id");
                return key;
            }

            return "";
        }

        /// <summary>
        /// call delete collection item identified by datatodelete.id
        /// </summary>
        /// <typeparam name="T">data type</typeparam>
        /// <param name="datatodelete">data entity</param>
        /// <returns>entity id on succesfull , empty string otherwise</returns>
        public string Delete<T>(T datatodelete)
            where T : IDataRecord
        {
            var db = new ADatabase("obieg");
            var deleteresult = db.Document.Delete(datatodelete.ID.Replace("_", "/"));
            if (deleteresult.Success)
                return datatodelete.ID;
            else
                return "";
        }

        /// <summary>
        /// call delete collection item identified by datatodelete(id)
        /// </summary>        
        /// <param name="datatodelete">entity id</param>
        /// <returns>entity id on succesfull, empty string otheriwse</returns>
        public string Delete(string datatodelete)
        {
            var db = new ADatabase("obieg");
            var deleteresult = db.Document.Delete(datatodelete.Replace("_", "/"));
            if (deleteresult.Success)
                return datatodelete;
            else
                return "";
        }

        public T Update<T>(T updaterecord)
            where T : IDataRecord
        {
            var db = new ADatabase("obieg");
            var updaterezult = db.Document.Update<T>(updaterecord.ID.Replace("_", "/"), updaterecord);

            if (updaterezult.Success)
            {
                return updaterecord;
            }

            return default(T);
        }


        /// <summary>
        /// retrieve all records from collection T
        /// </summary>
        /// <typeparam name="T">class</typeparam>
        /// <param name="filter">AQL filter where entity is named item</param>
        /// <returns>List of T-type items</returns>
        public List<T> Get<T>(string filter)
            where T : IDataRecord, ICollectionMember, new()
        {
            var db = new ADatabase("obieg");
            var tmpobj = new T();
            string aquery = "FOR item IN " + collectionprefix +  tmpobj.CollectionName() +
                (filter != "" ? " FILTER " + filter : "") +
                " RETURN item";
            var getrezult = db.Query.Aql(aquery).ToList<T>();
            if (getrezult.Success)
            {
                for (int i = 0; i < getrezult.Value.Count; i++)
                {
                    getrezult.Value[i].ID = getrezult.Value[i]._id.Replace("/", "_");
                }
                return getrezult.Value;
            }

            return default(List<T>);
        }
        
        /// <summary>
        ///retrieve all records from collection T, including paging ability 
        /// </summary>
        /// <typeparam name="T">class for which result is mapped</typeparam>
        /// <param name="filter">AQL-syntax filter where current collection is referenced as item</param>
        /// <param name="page">page number to display</param>
        /// <param name="pagesize">page size - when not defined paging is not enabled</param>
        /// <returns></returns>
        public List<T> Get<T>(string filter, int page, int pagesize)
            where T : IDataRecord, ICollectionMember, new()
        {
            var db = new ADatabase("obieg");
            var tmpobj = new T();
            string aquery = "FOR item IN " + collectionprefix + tmpobj.CollectionName() +
                (filter != "" ? " FILTER " + filter : "") +
                (pagesize > 0 ? " Limit " + (pagesize * (page - 1)).ToString() + "," + pagesize.ToString() : "")
                + " RETURN item"
                
                ;
            var getrezult = db.Query.Aql(aquery).ToList<T>();
            if (getrezult.Success)
            {
                for (int i = 0; i < getrezult.Value.Count; i++)
                {
                    getrezult.Value[i].ID = getrezult.Value[i]._id.Replace("/", "_");
                }
                return getrezult.Value;
            }

            return default(List<T>);
        }

        /// <summary>
        /// returns count of collection T items
        /// </summary>
        /// <typeparam name="T">class for collection</typeparam>
        /// <param name="filter">AQL condition, item stands for collection alias</param>
        /// <returns>number of items</returns>
        public int GetCount<T>(string filter)
            where T : IDataRecord, ICollectionMember, new()
        {
            int wynik = 0;
            var db = new ADatabase("obieg");
            var tmpobj = new T();
            string aquery = "FOR item IN " + collectionprefix + tmpobj.CollectionName() +
                (filter != "" ? " FILTER " + filter : "") +
                " COLLECT WITH COUNT INTO length"
                + " RETURN length"  ;
            var getresult = db.Query.Aql(aquery).ToObject();
            if (getresult.Success)
            {
                wynik = Int32.Parse(getresult.Value.ToString());
            }
            return wynik;
        }

        /// <summary>
        /// Initializes view - checks for existence, when missing creating
        /// </summary>
        /// <param name="created">wheter view is created et this time</param>
        /// <param name="viewName">name of a view</param>
        /// <returns>success</returns>
        public bool InitializeView(out bool created, String viewName)
        {
            var db = new ADatabase("obieg");
            created = false;
            var view = db.View.GetProperties(viewName);
            if (!view.Success)
            {
                created = false;
                var createViewResult = db.View.Type(AViewType.arangosearch)
                    .Create(viewName);
                if (!createViewResult.Success)
                { return false; }
                else
                {
                    created = true;
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="viewName"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public bool ModifyView<T>(string viewName, string collectionName)
            where T : IDataRecord, ICollectionMember, new()
        {
            var db = new ADatabase("obieg");
            var tmpobj = new T();
            var modified = db.View.Link(collectionName ==""?tmpobj.CollectionName(): collectionName).
                ChangeProperties(viewName, collectionName == "" ? tmpobj.CollectionName() : collectionName);

            return true;
        }

        /// <summary>
        /// Checks for collection's existence 
        /// when not exists collection is created using T annotations
        /// for collection name and type
        /// </summary>
        /// <typeparam name="T">collection's class</typeparam>
        /// <param name="created">returns creation state</param>
        /// <param name="prefix">optional prefic for collection name</param>
        /// <returns>success</returns>
        public bool InitializeCollection<T>( out bool created, String prefix = "")
            where T : IDataRecord, ICollectionMember, new()
        {
            var db = new ADatabase("obieg");
            var tmpobj = new T();
            this.collectionprefix = prefix;
            created = false;
            var colection = db.Collection.Get(prefix+tmpobj.CollectionName());
            if (!colection.Success)
            {
                var createCollectionResult = db.Collection
                    .Type(tmpobj.CollectionType())
                    //.KeyGeneratorType(AKeyGeneratorType.Autoincrement)                    
                    //.WaitForSync(true)                    
                    .Create(collectionprefix + tmpobj.CollectionName());
                if (!createCollectionResult.Success)
                {
                    return false;
                }
                else
                {
                    created = true;
                }
            }

            return true;
        }

        public List<T> GetEdges<T>(string key, ADirection direction)
            where T : ICollectionMember, IDictionaryAssignable, new()
        {
            var db = new ADatabase("obieg");
            var tmpObj = new T();
            var getresult = db.Document
                .GetEdges(collectionprefix + tmpObj.CollectionName(), key.Replace("_", "/"), direction);

            if (getresult.Success)
            {
                var retlist = new List<T>();
                foreach (var edge in getresult.Value)
                {
                    var tmpO = new T();
                    var rezult = new Dictionary<string, string>();
                    foreach (string klucz in edge.Keys)
                    {
                        rezult.Add(klucz, edge.String(klucz));
                    }
                    tmpO.AssignFromDictionary(rezult);
                    retlist.Add(tmpO);
                }
                return retlist;
            }
            return null;
        }

        /// <summary>
        /// queries edge collection
        /// </summary>
        /// <typeparam name="T">edge collection class</typeparam>
        /// <typeparam name="V">document collection class</typeparam>
        /// <param name="key">start key</param>
        /// <param name="direction">which side of edge collection will be queried for documents</param>
        /// <returns></returns>
        public List<V> GetOtherSide<T, V>(string key, ADirection direction)
            where T : IDataRecord, ICollectionMember, new()
            where V : IDataRecord, ICollectionMember, new()
        {
            var db = new ADatabase("obieg");
            var tmpObj = new T();
            string dirstr = direction == ADirection.Any ? " ANY " : (direction == ADirection.In ? " INBOUND " : " OUTBOUND ");
            string querry = "FOR item in " + dirstr + " '" + key.Replace("_","/") + "' " + collectionprefix + tmpObj.CollectionName() + " OPTIONS {bfs: true, uniqueVertices: 'global'} return item";
            var getrezult = db
                .Query.Aql(querry).ToList<V>();
            //.Document
            //.GetEdges(tmpObj.CollectionName(), key.Replace("_", "/"), ADirection.In);

            if (getrezult.Success)
            {
                for (int i = 0; i < getrezult.Value.Count; i++)
                {
                    getrezult.Value[i].ID = getrezult.Value[i]._id.Replace("/", "_");
                }
                return getrezult.Value;
            }
            return null;
        }

        /// <summary>
        /// queries edge collection
        /// </summary>
        /// <typeparam name="T">edge collection class</typeparam>
        /// <typeparam name="V">document collection class</typeparam>
        /// <param name="key">start key</param>
        /// <param name="direction">which side of edge collection will be queried for documents</param>
        /// <param name="depth">search traversal depth</param>
        /// <returns></returns>
        public List<V> GetOtherSide<T, V>(string key, ADirection direction,int depth)
            where T : IDataRecord, ICollectionMember, new()
            where V : IDataRecord, ICollectionMember, new()
        {
            var db = new ADatabase("obieg");
            var tmpObj = new T();
            string dirstr = direction == ADirection.Any ? " ANY " : (direction == ADirection.In ? " INBOUND " : " OUTBOUND ");
            string querry = "FOR item in 1.."+ depth.ToString()+" "+ dirstr + " '" + key.Replace("_", "/") + "' " + collectionprefix + tmpObj.CollectionName() + " OPTIONS {bfs: true, uniqueVertices: 'global'} return item";
            var getrezult = db
                .Query.Aql(querry).ToList<V>();
            //.Document
            //.GetEdges(tmpObj.CollectionName(), key.Replace("_", "/"), ADirection.In);

            if (getrezult.Success)
            {
                for (int i = 0; i < getrezult.Value.Count; i++)
                {
                    getrezult.Value[i].ID = getrezult.Value[i]._id.Replace("/", "_");
                }
                return getrezult.Value;
            }
            return null;
        }

        /// <summary>
        /// removes edges from T edge collection
        /// </summary>
        /// <typeparam name="T">class for collection</typeparam>
        /// <param name="_from">filter</param>
        /// <param name="_to">filter</param>
        /// <returns>success</returns>
        public bool RemoveEdge<T>(string _from, string _to)
            where T : ICollectionMember, new()
        {
            var tmpObj = new T();
            if (tmpObj.CollectionType() == ACollectionType.Edge)
            {
                var db = new ADatabase("obieg");
                string delstr = "for u in " + collectionprefix + tmpObj.CollectionName() +
                    " filter u._from == '" + _from.Replace("_","/") + "' && u._to == '" + _to.Replace("_","/") + "' " +
                " REMOVE u in " + collectionprefix + tmpObj.CollectionName();

                var qresult = db.Query.Aql(delstr).ExecuteNonQuery();

                return qresult.Success;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// insert simple element to edge collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_from">edge property</param>
        /// <param name="_to">edge property</param>
        /// <param name="elements">additional optional elements</param>
        /// <returns>success</returns>
        public bool InsertEdge<T>(string _from, string _to, Dictionary<string, object> elements)
            where T : ICollectionMember, new()
        {
            T edgedef = new T();
            var db = new ADatabase("obieg");
            var insertresult = db.Document.CreateEdge(collectionprefix + edgedef.CollectionName()
                    , _from.Replace("_","/"), _to.Replace("_","/"), elements);
            
            if (insertresult.Success)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public T InsertEdge<T>(T edgetoinsert)
            where T : ICollectionMember, IEdgeCollection, IDataRecord, new()
        {
            var rezult = new T();
            var db = new ADatabase("obieg");
            var insertresult = db.Document.CreateEdge<T>(collectionprefix + edgetoinsert.CollectionName()
                , edgetoinsert._from.Replace("_","/")
                , edgetoinsert._to.Replace("_", "/"), 
                edgetoinsert);
            if (insertresult.Success)
            {
                var id = insertresult.Value.String("_id");
                edgetoinsert._id = id;
                edgetoinsert.ID = id.Replace("/","_");
                return edgetoinsert;
            }
            return rezult;
        }


    }
}