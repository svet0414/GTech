/*using Bogus;
using CsvHelper;
using GTechAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GTechAPI.Data
{
    public class DataCreatingBogus
    {
        public static void GenerateData()
        {
            Random rnd = new Random();
            long isbn = 1000000000000;

            var languages = new List<string> { "english", "danish", "bulgarian", "hungarian" };
            int index = rnd.Next(languages.Count);
            var language = languages[index];
            languages.RemoveAt(index);



            var id = 1;
            var _ssn = 2000000000;
            *//*
                        using (var context = new psu0221_1074251Context())
                        {
                            var bgLang = new Language()
                            {
                                Language1 = "Bulgarian"

                            };

                            context.Languages.Add(bgLang);
                            context.SaveChanges();

                            var engLang = new Language()
                            {
                                Language1 = "English"

                            };

                            context.Languages.Add(engLang);
                            context.SaveChanges();

                            var dkLang = new Language()
                            {
                                Language1 = "Danish"

                            };

                            context.Languages.Add(dkLang);
                            context.SaveChanges();

                            var huLang = new Language()
                            {
                                Language1 = "Hungarian"

                            };

                            context.Languages.Add(huLang);
                            context.SaveChanges();

                            var testPublisher = new Faker<Publisher>()
                                //.RuleFor(u=>u.Id,f=>id++)
                                .RuleFor(u => u.Name, f => f.Person.FullName);
                            var publisher = testPublisher.Generate(160);
                            context.Publishers.AddRangeAsync(publisher);
                            context.SaveChanges();
                            var testAuthor = new Faker<Author>()
                                //.RuleFor(u=>u.Id,f=>id++)
                                .RuleFor(u => u.FName, f => f.Name.FirstName())
                                .RuleFor(u => u.LName, f => f.Name.LastName());
                            var author = testAuthor.Generate(1600);
                            context.Authors.AddRangeAsync(author);
                            context.SaveChanges();
                            var testItemTypeBook = new ItemType()
                            {
                                Name = "Book"

                            };
                            context.ItemTypes.Add(testItemTypeBook);
                            context.SaveChanges();

                            var testItemTypeMap = new ItemType()
                            {
                                Name = "Map"

                            };
                            context.ItemTypes.Add(testItemTypeMap);
                            context.SaveChanges();


                            var studentType = new MemberType()
                            {
                                //Id = 1,
                                NameOfMemberType = "Student",
                                MaximumLoans = 5,
                                LoanPeriod = 21,
                                GracePeriod = 7

                            };
                            context.MemberTypes.Add(studentType);
                            context.SaveChanges();
                            var proffesorType = new MemberType()
                            {
                                //Id = 2,
                                NameOfMemberType = "Proffesor",
                                MaximumLoans = 10,
                                LoanPeriod = 90,
                                GracePeriod = 14

                            };
                            context.MemberTypes.Add(proffesorType);
                            context.SaveChanges();




                            var testUsers = new Faker<Member>()
                                //.CustomInstantiator(f => new Member(Ssn++, f.Random.Replace("######-####")))
                                .RuleFor(u => u.Ssn, f => _ssn++)
                                .RuleFor(u => u.FName, f => f.Name.FirstName())
                                .RuleFor(u => u.LName, f => f.Name.LastName())
                                .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber("(+45)########"))
                                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FName, u.LName))
                                .RuleFor(u => u.HomeAddress, f => f.Address.StreetAddress())
                                .RuleFor(u => u.CampusAddress, f => f.Address.SecondaryAddress())
                                .RuleFor(u => u.MemberType, f => rnd.Next(1, 3));
                            //RuleFor(u => u.Cards, f => f = new Faker<Card>());


                            var user = testUsers.Generate(16000);
                            context.Members.AddRangeAsync(user);
                            context.SaveChanges();


                            var testCards = new Faker<Card>()
                                //.RuleFor(u => u.CardNumber, f => rnd.Next(100000, 999999))
                                .RuleFor(u => u.DateIssued, f => f.Date.Recent(10))
                                .RuleFor(u => u.DateExpire, f => f.Date.Future(4))
                                .RuleFor(u => u.MemberSsn, f => f.PickRandom(user).Ssn);

                            var cards = testCards.Generate(16000);
                            context.Cards.AddRangeAsync(cards);
                            context.SaveChanges();


                            context.SaveChanges();
            */
            /*using (var context = new psu0221_1074251Context())
            {
                int code = 2;
                var book_id = 1;
                var ddc = context.Ddcs.Find(rnd.Next(1,999));
                foreach (BaseMetadatum book in context.BaseMetadata)
                {

                    var testBooks = new Faker<Book>()
                        .RuleFor(u => u.Id, f => book.Id)
                        .RuleFor(u => u.Isbn13, f => isbn++.ToString())
                        .RuleFor(u => u.Ddcs, f =>ddc.DdcsCode)
                        .RuleFor(u => u.PublisherId, f => rnd.Next(1, 160))
                        .RuleFor(u => u.PageCount, f => rnd.Next(300, 1000))
                        .RuleFor(u => u.Language, f => rnd.Next(1, 5));
                    var books = testBooks.Generate(1);
                    context.Books.AddRange(books);

                    code++;

                }
                context.SaveChanges();


            }*/


            /*using (var context = new psu0221_1074251Context())
            {
                //int code = 2;
               // var book_id = 1;
               // var ddc = context.Ddcs.Find(rnd.Next(1, 999));
                foreach (BaseMetadatum book in context.BaseMetadata)
                {
                    var campus = rnd.Next(1, 5);
                    var testItems = new Faker<Item>()
                        .RuleFor(i => i.IsLoanable, f => f.Random.Bool())
                        .RuleFor(i=>i.Condition, f=> "Good")
                        .RuleFor(i=>i.Location, f=> $"Georgia Tech Campus {campus}")
                        .RuleFor(i=>i.ItemMetadata,f=> book.Id);
                    var books = testItems.Generate(1);
                    context.Items.AddRange(books);

                }
                context.SaveChanges();


            }*//*


            using (var context = new psu0221_1074251Context())
            {
                //int code = 2;
                // var book_id = 1;
                // var ddc = context.Ddcs.Find(rnd.Next(1, 999));

                //var campus = rnd.Next(1, 5);
                var testLoans = new Faker<Loan>()
                    .RuleFor(i => i.IsActive, f => f.Random.Bool())
                    .RuleFor(i => i.ItemId, f => rnd.Next(1, 1000))
                    .RuleFor(i => i.MemberSnn, f => rnd.Next(1000000000, 1000001000))
                    .RuleFor(i => i.DateLoaned, f => f.Date.Recent(4))
                    .RuleFor(i => i.DateDue, f => f.Date.Soon(90));
                    //.RuleFor(i=>i.DateFinished,f=>f.Date.Soon(120));
                    var books = testLoans.Generate(1000);
                    context.Loans.AddRange(books);
                
                
                context.SaveChanges();


            }
        }

    }
}

*/