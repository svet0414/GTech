using GTechAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTechAPI.Interfaces
{
    public interface IItemRepository
    {
        Task<Item> GetItemByIdAsync(int id);
        Task<Item> GetIsItemAvailableById(int id);
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<IEnumerable<Map>> GetMapsAsync();
        Task<IQueryable<Item>> GetAvailableItemsAsync();
        Task<Book> InsertBook(Book book);
    }
}
