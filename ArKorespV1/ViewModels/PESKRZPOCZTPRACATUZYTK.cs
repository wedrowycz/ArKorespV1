using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArKorespV1.ViewModels
{
    /// <summary>
    /// view-content class for user and it's mailbox
    /// </summary>
    public class PESKRZPOCZTPRACATUZYTK
    {
        /// <summary>
        /// user information class
        /// </summary>
        public ATUZYTK user { get; set; }
        /// <summary>
        /// mailbox for user
        /// </summary>
        public PESKRZPOCZTPRAC powiazanie { get; set; }        
    }
}