using MerchCount2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchCount2.DataLayer
{
    public class ProductDAO
    {
        SQLiteAsyncConnection Database;
        public ProductDAO()
        {

        }
        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<Product>();
            if (result.CompareTo(CreateTableResult.Created) == 1)
            {
                await CreateDefaultItemsAsync();
            }
        }

        public async Task<List<Product>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<Product>().ToListAsync();
        }

        public async Task<List<Product>> GetItemsNotDoneAsync()
        {
            await Init();
            return await Database.Table<Product>().Where(t => t.Done).ToListAsync();

            // SQL queries are also possible
            //return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public async Task<Product> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<Product>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(Product item)
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

        public async Task<int> CreateDefaultItemsAsync()
        {
            List<Product> items = new List<Product>();
            items.Add(new Product());

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

        public async Task<int> DeleteItemAsync(Product item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}
