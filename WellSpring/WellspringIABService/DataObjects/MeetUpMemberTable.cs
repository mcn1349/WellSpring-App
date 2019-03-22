using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WellspringIABService.DataObjects
{
    public class MeetUpMemberTable : EntityData
    {
        public string MeetUpID { get; set; }
        public string UserID { get; set; }
    }
}