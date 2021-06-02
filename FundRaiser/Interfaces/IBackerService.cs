using FundRaiser.Models;
using FundRaiser.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundRaiser.Interfaces
{
    public interface IBackerService
    {
        Task<List<Backer>> GetBackersAsync();

        Task<Backer> GetBackerByIdAsync(int id);

        Task <Backer> CreateBackerAsync(BackerOptions options);

        Task<int> DeleteBackerByIdAsync(int id);

       //Task<Reward> FundReward(int id);

    }
}
