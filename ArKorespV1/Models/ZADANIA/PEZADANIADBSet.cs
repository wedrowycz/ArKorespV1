using ArKorespV1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ArKorespV1.Models.ZADANIA
{
    /// <summary>
    /// class for data manipulation derives from ADBSet
    /// </summary>
    public class PEZADANIADBSet:ADBSet<PEZADANIA>
    {
        /// <summary>
        /// specialized query method - retrieves list of task object with it's coresponding task definition
        /// </summary>
        /// <param name="skrzynka">mailbox filter</param>
        /// <param name="status">task's staus filter</param>
        /// <param name="pagesize">number of records to retrieve</param>
        /// <param name="pagenumber">page number - 0 and 1 means the same</param>
        /// <returns>list of PEZADANIEZPROCEDURA objects</returns>
        public List<PEZADANIEZPROCEDURA> GetPEZADANIAList(string skrzynka, int status ,int pagesize, int pagenumber )
        {
            StringBuilder aql = new StringBuilder();
            aql.Append("for zad in PEZADANIA ");
            aql.Append("for ob in PEOBDOK ");
            aql.Append("for proc in PEPROCOBDOKPOZ ");
            aql.Append("for kor in VPEKORESP ");
            aql.Append("FILTER zad._id == ob._to ");
            aql.Append("filter ob.Skrzynka == '"+skrzynka.Replace("_","/")+ "' ");
            aql.Append("filter zad.DSTATUS == " + status.ToString() + " ");
            aql.Append("filter proc._id == SUBSTITUTE(zad.DPROCEDURAID, '_', '/') ");
            aql.Append("filter kor._id == SUBSTITUTE(ob.Korespondencja, '_', '/') ");
            aql.Append("return { zadanie: zad , procedura: proc , obieg : ob, koresp : kor }");

            return db.GetData<PEZADANIEZPROCEDURA>(aql.ToString());
        }

        /// <summary>
        /// specialized query method - retrieves single task object with it's coresponding task definition
        /// </summary>
        /// <param name="skrzynka">mailbox filter</param>
        /// <param name="zadanieid">task id</param>
        /// <returns>PEZADANIEZPROCEDURA object</returns>
        public PEZADANIEZPROCEDURA GetZadanie(string skrzynka, string zadanieid)
        {
            StringBuilder aql = new StringBuilder();
            aql.Append("for zad in PEZADANIA ");
            aql.Append("for ob in PEOBDOK ");
            aql.Append("for proc in PEPROCOBDOKPOZ ");
            aql.Append("FILTER zad._id == ob._to ");
            aql.Append("filter ob.Skrzynka == '" + skrzynka.Replace("_", "/") + "'");
            aql.Append("filter zad._id == " + zadanieid.Replace("_","/") + " ");
            aql.Append("filter proc._id == SUBSTITUTE(zad.DPROCEDURAID, '_', '/')");
            aql.Append("return { zadanie: zad , procedura: proc , obieg : ob}");

            return db.GetData<PEZADANIEZPROCEDURA>(aql.ToString()).FirstOrDefault();
        }

        /// <summary>
        /// specialized query method
        /// </summary>
        /// <param name="skrzynka">mailbox</param>
        /// <param name="status">status</param>
        /// <param name="pagesize">page size</param>
        /// <param name="pagenumber">page number</param>
        /// <returns></returns>
        public List<ZadanieObiegKorespondencja> GetZadaniaWithKoresp(string skrzynka, int status, int pagesize, int pagenumber)
        {
            StringBuilder aql = new StringBuilder();
            aql.Append("for zad in PEZADANIA ");
            aql.Append("for ob in PEOBDOK ");
            aql.Append("for kor in PEPROCOBDOKPOZ ");
            aql.Append("FILTER zad._id == ob._to ");
            aql.Append("filter ob.Skrzynka == '" + skrzynka.Replace("_", "/") + "'");
            aql.Append("filter zad.DSTATUS == " + status.ToString() + " ");
            aql.Append("filter proc._id == SUBSTITUTE(zad.DPROCEDURAID, '_', '/')");
            aql.Append("return { zadania: zad ,  obieg : ob, korespondencja : kor}");

            return db.GetData<ZadanieObiegKorespondencja>(aql.ToString());

        }

    }
}