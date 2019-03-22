using MvvmCross.Platform;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellSpring.Core.Interfaces;
using WellSpring.Core.Model;

namespace WellSpring.Core.Database
{
    public class CommunityPostTableDatabase : ICommunityPostTableDatabase
    {
        private SQLiteConnection database;

        public CommunityPostTableDatabase(ISqlite sqlite)
        {
            database = sqlite.GetConnection();
            database.CreateTable<CommunityPostTable>();
        }
        public async Task<bool> CheckIfExists(CommunityPostTableAutoCompleteResult post)
        {
            return await CheckIfExists(new CommunityPostTable(post));
        }

        public async Task<bool> CheckIfExists(CommunityPostTable post)
        {
            var exist = database.Table<CommunityPostTable>().Any(x => x.Id == post.Id);
            return exist;
        }

        public async Task<IEnumerable<CommunityPostTable>> GetConnection()
        {
            return database.Table<CommunityPostTable>().ToList();
        }

        public async Task<int> InsertCommunityPost(CommunityPostTableAutoCompleteResult post)
        {
            return await InsertCommunityPost(new CommunityPostTable(post));
        }

        public async Task<int> InsertCommunityPost(CommunityPostTable post)
        {
            var num = database.Insert(post);
            database.Commit();
            return num;
        }

        public Task<IEnumerable<CommunityPostTable>> GetCp()
        {
            return null;
        }
    }
}
