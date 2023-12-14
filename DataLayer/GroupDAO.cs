using MerchCount2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchCount2.DataLayer
{
    public class GroupDAO
    {

        SQLiteAsyncConnection Database;
        public GroupDAO()
        {

        }
        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            Debug.Print(string.Format("My Path is : {0}",Constants.DatabasePath));
            var result = await Database.CreateTableAsync<Group>();
        }

        public async Task<List<Group>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<Group>().ToListAsync();
        }

        public async Task<List<Group>> GetItemsNotDoneAsync()
        {
            await Init();
            //return await Database.Table<Group>().Where(t => t.Done).ToListAsync();

            //SQL queries are also possible
            return await Database.QueryAsync<Group>("SELECT * FROM [Group] WHERE [ID] >= 10");
        }
        public async Task<List<Group>> GetPublicGroupsAsync()
        {
            await Init();
            //return await Database.Table<Group>().Where(t => t.Done).ToListAsync();

            //SQL queries are also possible
            Debug.Print(string.Format(" ++ Getting from {0}", Constants.DatabasePath));
            return await Database.QueryAsync<Group>("SELECT * FROM [Group] WHERE [ID] >= 10");
        }

        public async Task<Group> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<Group>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(Group item)
        {
            await Init();
            if (item.ID != 0)
            {
                return await Database.UpdateAsync(item);
            }
            else
            {
                return await Database.InsertAsync(item);
            }
        }

        public async Task<int> DeleteItemAsync(Group item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}
