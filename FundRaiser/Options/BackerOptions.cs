

using System;

namespace FundRaiser.Options
{
    public class BackerOptions
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get;  set; }
        public object DateTime { get; internal set; }
    }
    
}
