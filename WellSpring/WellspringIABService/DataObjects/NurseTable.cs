using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WellspringIABService.DataObjects
{
    public class NurseTable : EntityData
    {
        public string NurseName { get; set; }
        public string Company { get; set; }
    }
}