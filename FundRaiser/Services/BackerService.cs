using FundRaiser.Data;
using FundRaiser.Interfaces;
using FundRaiser.Models;
using FundRaiser.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace FundRaiser.Services
{
    public class BackerService : IBackerService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BackerService> _logger;

        public BackerService(ApplicationDbContext context, ILogger<BackerService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Backer> CreateBackerAsync(BackerOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.Address) ||
                string.IsNullOrWhiteSpace(options.Email) ||
                string.IsNullOrWhiteSpace(options.FirstName) ||
                string.IsNullOrWhiteSpace(options.LastName) ||
                string.IsNullOrWhiteSpace(options.Password)) 
            {
                _logger.LogError("Please insert all the parameters");
                return null;
            }

            var newBacker = new Backer
            {
                Address = options.Address,
                Email = options.Email,
                FirstName = options.FirstName,
                LastName = options.LastName,
                Password = options.Password,
                RegisterDate = (System.DateTime)options.RegisterDate

            };
            await _context.AddAsync(newBacker);
            await _context.SaveChangesAsync();
            return newBacker;
        }

        public async Task<int> DeleteBackerByIdAsync(int id)
        {
            var backerToDelete = await GetBackerByIdAsync(id);
            _context.Backer.Remove(backerToDelete);
            return await _context.SaveChangesAsync();
        }

        public async Task<Backer> GetBackerByIdAsync(int id)
        {
            var backer = await _context.
                Backer.
                SingleOrDefaultAsync(bac => bac.Id == id);
            if (backer == null)
            {
                return null;
            }
            return backer;
        }
        public async Task<List<Backer>> GetBackersAsync()
        {
            return await _context.Backer.ToListAsync();
        }


    }

}
