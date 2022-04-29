using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTechAPI.DTO.MemberDTO
{
    public class MemberDTO
    {
        public int SSN { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CampusAddress { get; set; }
        public string HomeAddress { get; set; }
        public int? MemberType { get; set; }


    }
}
