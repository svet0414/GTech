using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GTechAPI.DTO.MemberDTO;
using GTechAPI.Entities;
using GTechAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTechAPI.Controllers
{
    [ApiController]
    public class MemberController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IMemberRepository _memberRepository;


        public MemberController(IMapper mapper, IMemberRepository memberRepository)
        {
            _mapper = mapper;
            _memberRepository = memberRepository;
        }

        [HttpGet("{ssn}")]
        public async Task<ActionResult<MemberDTO>> GetMember(int ssn)
        {
            var member = await _memberRepository.GetMemberBySSNAsync(ssn);

            var memberToReturn = _mapper.Map<MemberDTO>(member);

            return Ok(memberToReturn);
        }


        [HttpPost]
        public async Task<ActionResult<MemberDTO>> CreateMember(MemberDTO mem) {
            var member = _mapper.Map<Member>(mem);

            await _memberRepository.CreateMember(member);
            var memberToReturn = _mapper.Map<MemberDTO>(member);
            return memberToReturn;
        
        
        
        }

        [HttpGet]
        public async Task<ActionResult<MemberDTO>> GetAllMember()
        {
            var member = await _memberRepository.GetMembersAsync();

            var memberToReturn = _mapper.Map<MemberDTO>(member);

            return Ok(memberToReturn);
        }

    }
}
