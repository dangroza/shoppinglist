using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace ShoppingList
{
    public class ShoppingListItemDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public ShoppingListItemDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ShoppingListItem).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ShoppingListItem)).ConfigureAwait(false);                    
                }
                initialized = true;
            }
        }

        public Task<List<ShoppingListItem>> GetItemsAsync()
        {
            return Database.Table<ShoppingListItem>().ToListAsync();
        }

        public Task<List<ShoppingListProduct>> GetProductsAsync()
        {
            return Database.Table<ShoppingListProduct>().ToListAsync();
        }

        public Task<List<ShoppingListItem>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<ShoppingListItem>("SELECT * FROM [ShoppingListItem] WHERE [Aquired] = 0");
        }

        public Task<ShoppingListItem> GetItemAsync(int id)
        {
            return Database.Table<ShoppingListItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<ShoppingListProduct> GetProductAsync(int id)
        {
            return Database.Table<ShoppingListProduct>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ShoppingListItem item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> SaveProductAsync(ShoppingListProduct product)
        {
            if (product.ID != 0)
            {
                return Database.UpdateAsync(product);
            }
            else
            {
                return Database.InsertAsync(product);
            }
        }

        public Task<int> DeleteItemAsync(ShoppingListItem item)
        {
            return Database.DeleteAsync(item);
        }

        public Task<int> DeleteProductAsync(ShoppingListProduct product)
        {
            return Database.DeleteAsync(product);
        }
    }
}

