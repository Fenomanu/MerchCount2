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
        public string DataPath
        {
            get
            {
                return Database.DatabasePath;
            }
        }
        public GroupDAO()
        {

        }
        async Task Init()
        {
            if (Database is not null)
            {
                Debug.Print("Database exists");
                return;
            }

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<Group>();
            if(result.CompareTo(CreateTableResult.Created) == 0)
            {
                Debug.Print("Creating Groups");
                await CreateDefaultGroupsAsync();
            }
        }

        public async Task<List<Group>> GetGroupsAsync()
        {
            await Init();
            return await Database.Table<Group>().ToListAsync();
        }

        public async Task<List<Group>> GetPublicGroupsAsync()
        {
            await Init();
            //return await Database.Table<Group>().Where(t => t.Done).ToListAsync();

            //SQL queries are also possible
            //Debug.Print(string.Format(" ++ Getting from {0}", Constants.DatabasePath));
            return await Database.QueryAsync<Group>("SELECT * FROM [Group] WHERE [IsAdminOnly] == false");
        }

        public async Task<Group> GetGroupAsync(int id)
        {
            await Init();
            return await Database.Table<Group>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveGroupAsync(Group item)
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

        public async Task<int> CreateDefaultGroupsAsync()
        {
            List<Group> items = new List<Group>();
            items.Add(new Group("Packs", "not_ready", 14, "You can combine other products into packs", true));
            items.Add(new Group("Stock", "not_ready", 1, "You can create stock items for every group", true));
            items.Add(new Group("", "", 0, "", true));
            items.Add(new Group("", "", 0, "", true));
            items.Add(new Group("", "", 0, "", true));
            items.Add(new Group("", "", 0, "", true));
            items.Add(new Group("", "", 0, "", true));
            items.Add(new Group("", "", 0, "", true));
            items.Add(new Group("", "", 0, "", true));

            await Init();
            if (items.All(item => item.ID == 0))
            {
                return await Database.InsertAllAsync(items);
            }
            else
            {
                try
                {
                    return await Database.UpdateAllAsync(items);
                }
                catch
                {
                    return await Database.InsertAsync(new Product());
                }
            }
        }

        public async Task<int> DeleteGroupAsync(Group item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}
