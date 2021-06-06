using FundRaiser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundRaiser.ViewModels
{
    public class ProjectRewardsViewModel
    {
        public Project Project { get; set; }

        public List<Reward> ListOfRewards { get; set; }
    }
}
