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
using System;

namespace UnitTestsGTL
{
    class MemberUnitTest
    {
        private IMemberRepository MockMemberRepository;
        [SetUp]

        public void Setup()

        {
            IList<Member> members = new List<Member>(){
            new Member
            {
                Ssn = 1213145265,
                FName = "Svetlioooooo",
                LName = "Svetliooooo",
                Phone = "+45235",
                Email = "svetlio@gmail.commmm",
                CampusAddress = "somewhere123",
                HomeAddress = "there1234",
                MemberType = 1
            },
            new Member
            {
                Ssn = 1213145255,
                FName = "Svetlio123",
                LName = "Svetlio123",
                Phone = "+45235645",
                Email = "svetlio@gmail.com123",
                CampusAddress = "somewhere987",
                HomeAddress = "there987",
                MemberType = 1
            },
            new Member
            {
                Ssn = 1213145115,
                FName = "Svetlio987",
                LName = "Svetlio987",
                Phone = "+4523564987",
                Email = "svetlio@gmail.com456",
                CampusAddress = "somewhere456",
                HomeAddress = "there456",
                MemberType = 1
            }
        };


            

            Mock<IMemberRepository> mockMemberRepository = new Mock<IMemberRepository>();

            mockMemberRepository.Setup(mr => mr.CreateMember(It.IsAny<Member>())).ReturnsAsync(
                 (Member target) =>
                 {
                     if (target.Ssn.Equals(default(int)))
                     {                         
                         target.Ssn = members.Count() + 1;
                         members.Add(target);
                     }
                     else
                     {
                         var original = members.Where(
                             q => q.Ssn == target.Ssn).Single();

                         if (original == null)
                         {
                             return null;
                         }

                         original.Ssn = target.Ssn;
                         original.FName = target.FName;
                         original.LName = target.LName;
                         original.Phone = target.Phone;
                         original.Email = target.Email;
                         original.CampusAddress = target.CampusAddress;
                         original.HomeAddress = target.HomeAddress;
                         original.MemberType = target.MemberType;
                     }
                     return target;                                      
                 });
            mockMemberRepository.Setup(mr =>

                    mr.GetMemberBySSNAsync(It.IsAny<int>()))

                .ReturnsAsync((int i) => members.Where(x => x.Ssn.Equals(i)).FirstOrDefault());
            // Return all the products
            mockMemberRepository.Setup(mr => mr.GetMembersAsync()).ReturnsAsync(members);
            this.MockMemberRepository = mockMemberRepository.Object;

        }
        [Test]
        public async Task CreateMemberTest()
        {
            Member newMember = new Member
            { 
            Ssn = 1213145265,
            FName = "Svetlio",
            LName = "Svetlio",
            Phone = "+4523564578",
            Email = "svetlio@gmail.com",
            CampusAddress = "somewhere",
            HomeAddress = "there",
            MemberType = 1
            };           
            await this.MockMemberRepository.CreateMember(newMember);
            Member testMember = await this.MockMemberRepository.GetMemberBySSNAsync(1213145265);
            Assert.IsNotNull(testMember); // Test if null
            Assert.AreEqual(1213145265, testMember.Ssn);
        }

        [Test]

        public void GetSignleDigitSSN()

        {

            Member testMember = this.MockMemberRepository.GetMemberBySSNAsync(5).Result;

            Assert.Null(testMember);

        }

        
    }
}
