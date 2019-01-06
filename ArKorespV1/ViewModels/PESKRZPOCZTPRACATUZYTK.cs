using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArKorespV1.ViewModels
{
    public class PESKRZPOCZTPRACATUZYTK
    {
        public ATUZYTK user { get; set; }
        public PESKRZPOCZTPRAC powiazanie { get; set; }
        public string _from { get; set; }
    }
}