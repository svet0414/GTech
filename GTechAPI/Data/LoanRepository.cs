using GTechAPI.Entities;
using GTechAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTechAPI.Data
{
    public class LoanRepository:ILoanRepository
    {
        private readonly psu0221_1074251Context _context = new psu0221_1074251Context();
        /*public LoanRepository(psu0221_1074251Context context)
        {
            this._context = context;
        }*/
        public async Task<Loan> GetLoanByIDSSNAsync(int id)
        {
            return await _context.Loans.Where(x => x.Id.Equals(id)).Include(p => p.Item.Id).FirstOrDefaultAsync();
        }
        public async Task<IQueryable<Loan>> GetMemberLoansAsync(int ssn)
        {
            return  _context.Loans.Where(x=>x.MemberSnn.Equals(ssn)).Include(x => x.Item.Id);
        }


        public async Task<IEnumerable<Loan>> GetActiveLoans()
        {
            return _context.Loans.Where(i => i.IsActive.Equals(true)).Include(x => x.ItemId);
        }

        public async Task<Loan> CreateLoan(Loan loan)
        {
            loan.IsActive = true;
            loan.ItemId = loan.ItemId;
            loan.MemberSnn = loan.MemberSnn;
            loan.DateLoaned = DateTime.Now;

            var mem = _context.Members.Where(x => x.Ssn.Equals(loan.MemberSnn)).FirstOrDefault();

            if (mem.MemberType == 1)
            {
                loan.DateDue = loan.DateLoaned.AddDays(21);
            }
            else if (mem.MemberType == 2)
            {
                loan.DateDue = loan.DateLoaned.AddDays(90);
            }
            _context.Loans.Add(loan);

            await _context.SaveChangesAsync();

            return loan;
        }
    }
}
