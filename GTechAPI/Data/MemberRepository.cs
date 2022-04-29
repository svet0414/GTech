using GTechAPI.Entities;
using GTechAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTechAPI.Data
{

    public class MemberRepository: IMemberRepository
    {
        
        private readonly psu0221_1074251Context _context = new psu0221_1074251Context();
       /* public MemberRepository(psu0221_1074251Context context)
        {
            this._context = context;
        }*/
        public async Task<Member> GetMemberBySSNAsync(int ssn)
        {
            return await _context.Members.Where(x => x.Ssn.Equals(ssn)).Include(p => p.MemberTypeNavigation).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Member>> GetMembersAsync()
        {
            return await  _context.Members.Include(x=>x.MemberTypeNavigation).ToListAsync();
        }

        public async Task<Member> CreateMember(Member member)
        {
            member.Ssn = member.Ssn;
            member.FName = member.FName;
            member.LName = member.LName;
            member.Phone = member.Phone;
            member.Email = member.Email;
            member.CampusAddress = member.CampusAddress;
            member.HomeAddress = member.HomeAddress;
            member.MemberType = member.MemberType;
            _context.Members.Add(member);

            await _context.SaveChangesAsync();

            return member;
        }

    }
}

