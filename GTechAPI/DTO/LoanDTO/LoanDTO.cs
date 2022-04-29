using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTechAPI.DTO.LoanDTO
{
    public class LoanDTO
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int? ItemId { get; set; }
        public int? MemberSnn { get; set; }
        public DateTime DateLoaned { get; set; }
        public DateTime? DateFinished { get; set; }
    }
}
