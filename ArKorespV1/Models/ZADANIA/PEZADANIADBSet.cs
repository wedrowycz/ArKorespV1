using ArKorespV1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ArKorespV1.Models.ZADANIA
{
    public class PEZADANIADBSet:ADBSet<PEZADANIA>
    {
        public List<PEZADANIEZPROCEDURA> GetPEZADANIAList(string skrzynka, int status ,int pagesize, int pagenumber )
        {
            StringBuilder aql = new StringBuilder();
            aql.Append("for zad in PEZADANIA ");
            aql.Append("for ob in PEOBDOK ");
            aql.Append("for proc in PEPROCOBDOKPOZ ");
            aql.Append("FILTER zad._id == ob._to ");
            aql.Append("filter ob.Skrzynka == '"+skrzynka.Replace("_","/")+ "'");
            aql.Append("filter zad.DSTATUS == " + status.ToString() + " ");
            aql.Append("filter proc._id == SUBSTITUTE(zad.DPROCEDURAID, '_', '/')");
            aql.Append("return { zadanie: zad , procedura: proc , obieg : ob}");

            return db.GetData<PEZADANIEZPROCEDURA>(aql.ToString());
        }

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

    }
}