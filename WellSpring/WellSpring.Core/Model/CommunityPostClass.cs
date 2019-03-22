using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class CommunityPostClass
    {
        public int PostID { get; set; }
        public UserClass Host { get; set; }
        private CommunityCommentClass[] lstcomment;
        public int Likes { get; set; }

    }
}
