using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundRaiser.Models
{
    public class Backer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public DateTime RegisterDate { get; set; }
        //public virtual List<FundProject> FundProject { get; set; }
    }
}
