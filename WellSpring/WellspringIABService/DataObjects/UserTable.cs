using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WellspringIABService.DataObjects
{
    public class UserTable : EntityData
    {
        public string Name { get; set; }
        public int AimCalorie { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public int Weight { get; set; }
    }
}