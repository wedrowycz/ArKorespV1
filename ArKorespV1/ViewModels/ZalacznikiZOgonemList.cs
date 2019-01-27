using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArKorespV1.ViewModels
{
    public class ZalacznikiZOgonemList: List<PEZalacznikiZOgonem>
    {
        public void Add(PEZALACZNIKI fpEZALACZNIKI )
        {
            Add(new PEZalacznikiZOgonem() { pEZALACZNIKI = fpEZALACZNIKI,idDescriptions = new List<IdDescription>() });
        }

        public void Add(PEZALACZNIKI fpEZALACZNIKI, List<IdDescription> fpidDescriptions )
        {
            Add(new PEZalacznikiZOgonem() { pEZALACZNIKI = fpEZALACZNIKI, idDescriptions = fpidDescriptions});
        }

    }
}