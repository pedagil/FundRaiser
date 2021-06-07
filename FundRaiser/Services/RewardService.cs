using FundRaiser.Data;
using FundRaiser.Interfaces;
using FundRaiser.Models;
using FundRaiser.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundRaiser.Services
{
    public class RewardService : IRewardService
    {
        private readonly ApplicationDbContext _context;

        public RewardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reward>> GetRewards()
        {

            return await _context.Reward.ToListAsync();


        }
        public async Task<Reward> GetRewardByIdAsync(int id)
        {
            var reward = await _context.Reward.SingleOrDefaultAsync(rew => rew.Id == id);
            return reward;
        }

        public async Task<Reward> CreateRewardAsync(RewardOptions rewardOptions)
        {
            Console.WriteLine($"FROM REWARD SERVICE id in create from reward controller {rewardOptions.ProjectId}");
            var newReward = new Reward
            {
                Description = rewardOptions.Description,
                Title = rewardOptions.Title,
                RewardAmount = rewardOptions.RewardAmount,
                //ProjectId = rewardOptions.ProjectId
                //Project = rewardOptions.ProjectId
                ProjectId = rewardOptions.ProjectId
            };
            await _context.Reward.AddAsync(newReward);
            await _context.SaveChangesAsync();
            return newReward;
        }
        public async Task<Reward> EditRewardAsync(int id)
        {

            return await _context.Reward.FindAsync(id);

        }

        public async Task<Reward> EditRewardByIdAsync(RewardOptions rewardOptions)
        {
            var updateReward = new Reward
            {
                Description = rewardOptions.Description,
                Title = rewardOptions.Title,
                RewardAmount = rewardOptions.RewardAmount
            };

            _context.Reward.Update(updateReward);
            await _context.SaveChangesAsync();
            return updateReward;
        }
        public bool RewardExists(int id)
        {
            return _context.Project.Any(e => e.Id == id);
        }

        public async Task<Reward> DeleteRewardByIdAsync(int id)
        {
            var rewardToDelete = await GetRewardByIdAsync(id);



            _context.Reward.Remove(rewardToDelete);
            await _context.SaveChangesAsync();
            return null;
        }
        public async Task<Reward> UpdateRewardStatusByIdAsync(int id)
        {
            var updateReward = new Reward
            {
                Id = id,
                RewardStatus = "purchased"
            };
            _context.Reward.Update(updateReward);
            await _context.SaveChangesAsync();
            return updateReward;
        }
    }
}