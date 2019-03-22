using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class CommunityCommentClass
    {
        public UserClass User { get; set; }
        public UserClass Host { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
