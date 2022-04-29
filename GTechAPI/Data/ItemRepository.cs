using GTechAPI.Entities;
using GTechAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTechAPI.Data
{
    public class ItemRepository: IItemRepository
    {
        //private IQueryable<Item> Item;
        private readonly psu0221_1074251Context _context = new psu0221_1074251Context();
        /*public ItemRepository(psu0221_1074251Context context)
        {
            this._context = context;
        }*/
        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _context.Items.Where(x=>x.Id.Equals(id)).Include(x=>x.ItemMetadataNavigation).FirstOrDefaultAsync();
        }
        public async Task<Item> GetIsItemAvailableById(int id)
        {
            return await _context.Items.Where(x => x.Id.Equals(id)).Where(x => x.IsLoanable==true).Include(x => x.ItemMetadataNavigation).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<BaseMetadatum> GetMetadataByid(int id)
        {
            return await _context.BaseMetadata.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Map>> GetMapsAsync()
        {
            return await _context.Maps.ToListAsync();
        }
        public async Task<IQueryable<Item>> GetAvailableItemsAsync()
        {
            return _context.Items.Where(i =>i.IsLoanable.Equals(true)).Include(x=>x.ItemMetadataNavigation);
        }

        /*public async Task<Book> InsertBook(Book book,BaseMetadatum baseMetadatum)
        {
            book.Isbn13 = book.Isbn13;
            book.Ddcs = book.Ddcs;
            book.Publisher = book.Publisher;
            book.PageCount = book.PageCount;
            book.Language = book.Language;
            baseMetadatum.Book = book;
            baseMetadatum.Description = baseMetadatum.Description;
            baseMetadatum.NumberOfCopies = baseMetadatum.NumberOfCopies;
            baseMetadatum.Title = baseMetadatum.Title;
            baseMetadatum.Year = baseMetadatum.Year;
            baseMetadatum.Type = 1;

            _context.Books.Add(book);

            await _context.SaveChangesAsync();

            return book;
        }*/
        public async Task<Book> InsertBook(Book book)
        {


            //int bookID = intIdt + 1;

            var idofBase = _context.BaseMetadata.Find(book.Id);
            if (idofBase.Id == book.Id) {
                idofBase.Id=book.Id;
                book.Isbn13 = book.Isbn13;
                book.Ddcs = book.Ddcs;
                book.PublisherId = book.PublisherId;
                book.PageCount = book.PageCount;
                book.Language = book.Language;

                _context.Books.Add(book);
            }
            
            await _context.SaveChangesAsync();

            return book;
        }
    }
}
