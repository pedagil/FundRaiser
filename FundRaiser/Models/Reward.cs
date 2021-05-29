using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundRaiser.Models
{
    public class Reward
    {
        public int Id { get; set; }
        public decimal RewardAmount { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Project Project { get; set; }


    }
}
