using FundRaiser.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundRaiser.Models
{
    public class FundProject
    {
        public int Id { get; set; }
        public Project Project { get; set; }
        public Backer Backer { get; set; }
        //rewards
        //price
        
    }
}
