using FundRaiser.Models;

namespace FundRaiser.Options
{
    public class RewardOptions
    {
        public decimal RewardAmount { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectIdentity { get; set; }
        public string RewardStatus { get; set; }

    }
}
