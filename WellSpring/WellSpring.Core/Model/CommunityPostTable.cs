using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class CommunityPostTable
    {
        public CommunityPostTable() { }
        public CommunityPostTable(CommunityPostTableAutoCompleteResult post)
        {
            HostID = post.HostID;
            Description = post.Description;
            Image = post.Image;
        }
        public string Id { get; set; }
        public string HostID { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
