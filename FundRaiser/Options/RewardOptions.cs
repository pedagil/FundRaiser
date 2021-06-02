﻿using FundRaiser.Models;

namespace FundRaiser.Options
{
    public class RewardOptions
    {
        public decimal RewardAmount { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Project Project { get; set; }
    }
}
