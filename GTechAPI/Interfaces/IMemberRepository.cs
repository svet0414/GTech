using GTechAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTechAPI.Interfaces
{
    public interface IMemberRepository
    {
        Task<Member> GetMemberBySSNAsync(int ssn);
        Task<IEnumerable<Member>> GetMembersAsync();
        Task<Member> CreateMember(Member member);
    }
}
