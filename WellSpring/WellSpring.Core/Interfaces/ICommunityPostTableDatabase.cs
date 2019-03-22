using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellSpring.Core.Model;

namespace WellSpring.Core.Interfaces
{
    public interface ICommunityPostTableDatabase
    {
        Task<IEnumerable<CommunityPostTable>> GetConnection();

        Task<int> InsertCommunityPost(CommunityPostTable post);
        Task<int> InsertCommunityPost(CommunityPostTableAutoCompleteResult post);

        Task<bool> CheckIfExists(CommunityPostTable post);
        Task<bool> CheckIfExists(CommunityPostTableAutoCompleteResult post);
        Task<IEnumerable<CommunityPostTable>> GetCp();
    }
}
