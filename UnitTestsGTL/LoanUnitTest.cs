using GTechAPI.Data;

using NUnit.Framework;

using Moq;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure;
using GTechAPI;
using System;
using GTechAPI.Entities;
using System.Collections.Generic;
using GTechAPI.Interfaces;
using System.Linq;

namespace UnitTestsGTL
{
    class LoanUnitTest
    {
        private ILoanRepository MockLoanRepository;
        [SetUp]

        public void Setup()

        {
            int ID = 1;
            IList<Loan> loans = new List<Loan>(){
            new Loan
            {
                Id=ID++,
                ItemId=10,
                MemberSnn=1000000001
            },
            new Loan
            {
                Id=ID++,
                ItemId=100,
                MemberSnn=1000000011
            },
            new Loan
            {
                Id=ID++,
                ItemId=1000,
                MemberSnn=1000000111
            }
        };

            IQueryable<Loan> queryableEntity = loans.AsQueryable();


            Mock<ILoanRepository> mockLoanRepository = new Mock<ILoanRepository>();

            mockLoanRepository.Setup(mr => mr.CreateLoan(It.IsAny<Loan>())).ReturnsAsync(
                 (Loan target) =>
                 {
                     DateTime now = DateTime.Now;

                     if (target.Id.Equals(default(int)))
                     {

                         target.Id = queryableEntity.Count() + 1;
                         loans.Add(target);
                     }
                     else
                     {
                         var original = queryableEntity.Where(
                             q => q.Id == target.Id).Single();

                         if (original == null)
                         {
                             return null;
                         }
                         original.Id = ID++;
                         original.ItemId = target.ItemId;
                         original.MemberSnn = target.MemberSnn;
                         
                     }

                     return target;


                 });
            mockLoanRepository.Setup(mr =>

                    mr.GetLoanByIDSSNAsync(It.IsAny<int>()))

                .ReturnsAsync((int i) => queryableEntity.Where(x => x.Id.Equals(i)).FirstOrDefault());
            mockLoanRepository.Setup(mr => mr.GetActiveLoans()).ReturnsAsync(queryableEntity);


            mockLoanRepository.Setup(mr =>

                    mr.GetMemberLoansAsync(It.IsAny<int>()))

                .ReturnsAsync((int i) => queryableEntity.Where(x => x.MemberSnn.Equals(i)).AsQueryable());
            mockLoanRepository.Setup(mr => mr.GetActiveLoans()).ReturnsAsync(queryableEntity);


            

            this.MockLoanRepository = mockLoanRepository.Object;

        }
        [Test]
        public async Task CreateLoan()
        {
            Loan newLoan = new Loan
            {                
                MemberSnn = 1234567890,
                ItemId=123
            };
            await this.MockLoanRepository.CreateLoan(newLoan);
            Loan testLoan = await this.MockLoanRepository.GetLoanByIDSSNAsync(4);
            Assert.IsNotNull(testLoan); // Test if null
            Assert.AreEqual(4,testLoan.Id);
        }
    }
}
