using Arango.Client;
using ArKorespV1.Helpers;
using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArKorespTexts
{
    [CollectionType(ACollectionType.Document)]
    [CollectionName("TestEntity")]
    public class TestEntity : AutoSignedCollectionMember, IDataRecord, IDictionaryAssignable
    {
        public string FieldOne { get; set; }
        public bool FieldTwo { get; set; }
        public int FieldThree { get; set; }
        public DateTime FieldFour { get; set; }
        public double FieldFive { get; set; }

        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            return true;
        }
    }
}
