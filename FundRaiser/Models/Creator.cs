using FundRaiser.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundRaiser.Models
{
    public class Creator
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        //public string Role { get; set; }
        public string Password { get; set; }
        
        //****************
        //Possible change to ProjId
        public Project Project { get; set; }
        //*********************************

        //public virtual List<FundProject> FundProject { get; set; }//id toy Project

    }
}
