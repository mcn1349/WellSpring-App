using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WellspringIABService.DataObjects
{
    public class CommunityPostTable : EntityData
    {
        public string HostID { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}