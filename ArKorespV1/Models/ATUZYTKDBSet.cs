using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ArKorespV1.Models
{
    public class ATUZYTKDBSet: ADBSet<ATUZYTK>
    {

        public bool AddNewItem(Dictionary<string, string> newdata)
        {
            ATUZYTK atu = new ATUZYTK();
            atu.AssignFromDictionary(newdata);
            Add(atu);
            return true;
        }

        public override bool Query(string condition)
        {
            
            string aquery = "FOR item IN " + CollectionName();
            if (condition != "")
            {
                aquery += " FILTER item." + condition;
            }
            aquery += " RETURN item";            
            
            return db.GetRecords(aquery, this.AddNewItem, -1, -1);            
        }

        public override ATUZYTK Insert(ATUZYTK newdata)
        {

            string newkey = db.Insert<ATUZYTK>(newdata);
            newdata.ID = newkey;
            return newdata;
        }

        //public override ATUZYTK GetById(string id)
        //{
        //    ATUZYTK rezult = db.GetById<ATUZYTK>(id);
        //    return rezult;
        //}

    }
}