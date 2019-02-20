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
    [CollectionName("TestEdge")]
    [CollectionType(ACollectionType.Edge)]
    class TestEdge : EdgeCollectionMember, IDataRecord, IDictionaryAssignable
    {

        public bool AssignFromDictionary(Dictionary<string, string> dictionarry)
        {
            return true;
        }
    }
}
