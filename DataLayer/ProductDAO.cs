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
    public class ProductDAO
    {
        SQLiteAsyncConnection Database;
        public ProductDAO()
        {

        }
        async Task Init()
        {
            Debug.Print(Database.DatabasePath);
            if (Database is not null)
            {
                Debug.Print("Database exists");
                return;
            }

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<Product>();
            if (result.CompareTo(CreateTableResult.Created) == 0)
            {
                Debug.Print("Creating Producs");
                await CreateDefaultProductsAsync();
            }
        }

        public async Task<List<Product>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<Product>().ToListAsync();
        }


        public async Task<Product> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<Product>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }


        public async Task<List<Product>> GetHotProductsAsync()
        {
            await Init();
            return await Database.QueryAsync<Product>("Select * FROM [Product]");
        }
        
        public async Task<Dictionary<int, List<Product>>> GetGroupProductsBySagas(int groupID)
        {
            await Init();
            var res =  await Database.Table<Product>().Where(t => t.GroupID == groupID).ToListAsync();
            return res.GroupBy(obj => obj.SagaID).ToDictionary(grupo => grupo.Key, grupo => grupo.ToList());

            //SQL queries are also possible
            Debug.Print(string.Format(" ++ Getting from {0}", Constants.DatabasePath));
            //return await Database.QueryAsync<Product>("SELECT * FROM [Product] WHERE [IsAdminOnly] == false");
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

        public async Task<int> CreateDefaultProductsAsync()
        {
            List<Product> items = new List<Product>();
            items.Add(new Product("Product A", 0, 0, "Created on default"));
            items.Add(new Product("Product B", 1, 0, "Created on default"));
            items.Add(new Product("Product C", 2, 0, "Created on default"));
            items.Add(new Product("Product D", 3, 0, "Created on default"));
            items.Add(new Product("Product E", 3, 0, "Created on default"));
            items.Add(new Product("Product F", 1, 0, "Created on default"));
            items.Add(new Product("Product G", 1, 1, "Created on default"));
            items.Add(new Product("Product H", 1, 1, "Created on default"));

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
