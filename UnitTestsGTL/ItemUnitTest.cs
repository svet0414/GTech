using System.Collections.Generic;

using System.Linq;

using GTechAPI.Entities;

using GTechAPI.Interfaces;
using GTechAPI.Data;

using NUnit.Framework;

using Moq;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure;
using GTechAPI;

namespace UnitTestsGTL

{

    public class ItemUnitTest

    {

        private IItemRepository MockItemRepository;


        [SetUp]

        public void Setup()

        {
            //Create Items
            var items = new List<Item>
            {
                new Item { Id = 1,IsLoanable=true },
                new Item { Id = 2,IsLoanable=false },
                new Item { Id = 3,IsLoanable=true },
                new Item { Id = 4,IsLoanable=true },
                new Item { Id = 5,IsLoanable=false },
                new Item { Id = 6,IsLoanable=true },
                new Item { Id = 7,IsLoanable=true },
                new Item { Id = 8,IsLoanable=true },
            };

            // Mock the Item Repository using Moq

            Mock<IItemRepository> mockItemRepository = new Mock<IItemRepository>();

            mockItemRepository.Setup(mr =>
                    mr.GetItemByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int i) => items.Where(x => x.Id.Equals(i)).FirstOrDefault());
            this.MockItemRepository = mockItemRepository.Object;

            mockItemRepository.Setup(mr =>
                    mr.GetIsItemAvailableById(It.IsAny<int>()))
                .ReturnsAsync((int i) => items.Where(x => x.Id.Equals(i)).FirstOrDefault());
            this.MockItemRepository = mockItemRepository.Object;
        }



        [Test]

        public void GetItemByIdTest()

        {

            Item testItem = this.MockItemRepository.GetItemByIdAsync(1).Result;

            Assert.AreEqual(testItem.Id, 1);

        }


        [Test]

        public void GetItemByNegativeIdTest()

        {

            Item testItem = this.MockItemRepository.GetItemByIdAsync(-1).Result;

            Assert.Null(testItem);

        }
        [Test]

        public void GetIsItemAvailableByIdTest()

        {

            Item testItem = this.MockItemRepository.GetIsItemAvailableById(3).Result;

            Assert.AreEqual(testItem.IsLoanable,true);

        }


        [Test]
        public async Task GetAllItemsAvailable()
        {

            var data = new List<Item>
            {
                new Item { Id = 1,IsLoanable=true },
                new Item { Id = 2,IsLoanable=false },
                new Item { Id = 3,IsLoanable=true },
                new Item { Id = 4,IsLoanable=true },
                new Item { Id = 5,IsLoanable=false },
                new Item { Id = 6,IsLoanable=true },
                new Item { Id = 7,IsLoanable=true },
                new Item { Id = 8,IsLoanable=true },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Item>>();
            mockSet.As<IDbAsyncEnumerable<Item>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Item>(data.GetEnumerator()));

            mockSet.As<IQueryable<Item>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Item>(data.Provider));

            mockSet.As<IQueryable<Item>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Item>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Item>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<psu0221_1074251Context>();
            mockContext.Setup(c => c.Items).Returns(mockSet.Object);

            var service = new ItemRepository(mockContext.Object);
            IQueryable<Item> items = await service.GetAvailableItemsAsync();

            Assert.That(items.Count(p => p.IsLoanable), Is.EqualTo(6));
        }

        [Test]
        public async Task GetAllItemsAvailableIfAny()
        {

            var data = new List<Item>
            {
                new Item { Id = 1,IsLoanable=false },
                new Item { Id = 2,IsLoanable=false },
                new Item { Id = 3,IsLoanable=false },
                new Item { Id = 4,IsLoanable=false },
                new Item { Id = 5,IsLoanable=false },
                new Item { Id = 6,IsLoanable=false },
                new Item { Id = 7,IsLoanable=false },
                new Item { Id = 8,IsLoanable=false },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Item>>();
            mockSet.As<IDbAsyncEnumerable<Item>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Item>(data.GetEnumerator()));

            mockSet.As<IQueryable<Item>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Item>(data.Provider));

            mockSet.As<IQueryable<Item>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Item>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Item>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<psu0221_1074251Context>();
            mockContext.Setup(c => c.Items).Returns(mockSet.Object);

            var service = new ItemRepository(mockContext.Object);
            IQueryable<Item> items = await service.GetAvailableItemsAsync();

            Assert.That(items.Count(p => p.IsLoanable), Is.EqualTo(0));
        }



        /*[Test]
        public async Task GetAllBooks()
        {

            var data = new List<Book>
            {
                new Book { Id = 1,Isbn13="1234567890" },
                new Book { Id = 2,Isbn13="12345678900" },
                new Book { Id = 3,Isbn13="123456789000" },
                new Book { Id = 4,Isbn13="1234567890000" },
                new Book { Id = 5,Isbn13="1234567891" },
                new Book { Id = 6,Isbn13="12345678911" },
                new Book { Id = 7,Isbn13="123456789111" },
                new Book { Id = 8,Isbn13="1234567891111" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IDbAsyncEnumerable<Book>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Book>(data.GetEnumerator()));

            mockSet.As<IQueryable<Book>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Book>(data.Provider));

            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<psu0221_1074251Context>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            var service = new ItemRepository(mockContext.Object);
            IEnumerable<Book> books = await service.GetBooksAsync();

            Assert.That(books.Count(), Is.EqualTo(8));
        }*/

        //A QA engineer walks into a bar. 

        //    Orders a beer. Orders 0 beers. 

        //    Orders 99999999999 beers.

        //    Orders a lizard. Orders -1 beers.

        //    Orders a ueicbksjdhd. 

        // First real customer walks in and asks where the bathroom is. 

        // The bar bursts into flames, killing everyone.

        [Test]

        public void WhereIsTheToilet()

        {

            Assert.True(true);

        }

    }

}