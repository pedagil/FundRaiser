using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FundRaiser.Models
{
    public class Reward
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 40000, ErrorMessage = "Please reconsider...")]
        public decimal RewardAmount { get; set; }

        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        public Project Project { get; set; }

        public string RewardStatus { get; set; }

    }
}
