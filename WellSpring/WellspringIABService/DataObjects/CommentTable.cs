using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WellspringIABService.DataObjects
{
    public class CommentTable : EntityData
    {
        public string HostID { get; set; }
        public string UserID { get; set; }
        public string PostID { get; set; }
        public string Description { get; set; }
    }
}