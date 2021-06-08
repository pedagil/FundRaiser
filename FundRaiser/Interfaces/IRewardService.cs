using FundRaiser.Models;
using FundRaiser.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundRaiser.Interfaces
{
    public interface IRewardService
    {
        public Task<List<Reward>> GetRewards();


        public Task<Reward> GetRewardByIdAsync(int id);

        public Task<Reward> CreateRewardAsync(RewardOptions rewardoptions);

        public Task<Reward> EditRewardAsync(int id);

        public Task<Reward> EditRewardByIdAsync(RewardOptions rewardoptions);

        public bool RewardExists(int id);

        public Task<Reward> DeleteRewardByIdAsync(int id);
        
        public Task<Reward> UpdateRewardStatusByIdAsync(int id);


    }
}
