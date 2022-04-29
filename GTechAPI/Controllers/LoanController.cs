using System;
using System.Collections.Generic;
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
using GTechAPI.DTO.LoanDTO;

namespace GTechAPI.Controllers
{
    [ApiController]
    public class LoanController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ILoanRepository _loanRepository;

        public LoanController(IMapper mapper, ILoanRepository loanRepository)
        {
            _mapper = mapper;
            _loanRepository = loanRepository;
        }

        [HttpPost]
        public async Task<ActionResult<LoanDTO>> CreateLoan(LoanDTO loan)
        {
            var loanNew = _mapper.Map<Loan>(loan);
            //var memberToLoan = _mapper.Map<Member>(mem);
            await _loanRepository.CreateLoan(loanNew);
            var loanToReturn = _mapper.Map<LoanDTO>(loanNew);
            return loanToReturn;



        }
    }
}
