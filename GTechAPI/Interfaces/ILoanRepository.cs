using GTechAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTechAPI.Interfaces
{
    public interface ILoanRepository
    {
        Task<Loan> GetLoanByIDSSNAsync(int id);

        Task<IQueryable<Loan>> GetMemberLoansAsync(int ssn);

        Task<Loan> CreateLoan(Loan loan);
        Task<IEnumerable<Loan>> GetActiveLoans();
    }
}
