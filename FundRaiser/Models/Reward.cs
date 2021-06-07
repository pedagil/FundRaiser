using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        //public Project Project { get; set; }
        
        public int ProjectId { get; set; }
        public string RewardStatus { get; set; }

        //[ForeignKey("ProjectId")]
        //public virtual Project Project { get; set; }

    }
}
