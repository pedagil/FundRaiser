using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FundRaiser.Models;
using FundRaiser.Interfaces;
using FundRaiser.Options;
using System;

namespace FundRaiser.Controllers
{
    public class RewardsController : Controller
    {
        private readonly IRewardService _rewardService;

        public RewardsController(IRewardService service)
        {
            _rewardService = service;
        }

        // GET: Rewards
        public async Task<IActionResult> Index()
        {
            var allRewards = await _rewardService.GetRewards();
            return View(allRewards);
        }

        // GET: Rewards/Details/5
        public async Task<IActionResult> Details(int? id)
        {


            var reward = await _rewardService.GetRewardByIdAsync(id.Value);


            return View(reward);
        }

        // GET: Rewards/Create
        public IActionResult Create(int? id)
        {
            Console.WriteLine($"GET id in create from reward controller {id}");
            return View();
        }

        // POST: Rewards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RewardAmount,Title,Description")] Reward reward, int? id)
        {
            Console.WriteLine($"POST id in create from reward controller {id}");
            if (ModelState.IsValid)
            {
                //_context.Add(reward);
                await _rewardService.CreateRewardAsync(new RewardOptions {
                    Description = reward.Description,
                    Title = reward.Title,
                    RewardAmount = reward.RewardAmount,
                    ProjectId = id.Value
                    
                    //reward.Project.Id
                });
                //projectId = ProjectIdFromLink
                return RedirectToAction(nameof(Index));
            }
            return View(reward);
        }

        // GET: Rewards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reward = await _rewardService.EditRewardAsync(id.Value);
            if (reward == null)
            {
                return NotFound();
            }
            return View(reward);
        }

        // POST: Rewards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RewardAmount,Title,Description")] Reward reward)
        {
            if (id != reward.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /* _context.Update(project);
                     await _context.SaveChangesAsync();*/
                    await _rewardService.EditRewardByIdAsync(
                     new RewardOptions
                     {
                         Description = reward.Description,
                         Title = reward.Title,
                         RewardAmount = reward.RewardAmount
                     });

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_rewardService.RewardExists(reward.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
                return View(reward);
            
        }
            // GET: Rewards/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var reward = await _rewardService.GetRewardByIdAsync(id.Value);

                if (reward == null)
                {
                    return NotFound();
                }

                return View(reward);
            }

            // POST: Rewards/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                await _rewardService.DeleteRewardByIdAsync(id);
                return RedirectToAction(nameof(Index));
            }
             public async Task<IActionResult> UpdateRewardStatus(int? id)
             {
            var reward = await _rewardService.UpdateRewardStatusByIdAsync(id.Value);
            //If you do return View("~/Views/Wherever/SomeDir/MyView.aspx") You can return any View you'd like.
            return View("../Views/Projects/Details");
             }

        /* private bool RewardExists(int id)
         {
             return _context.Reward.Any(e => e.Id == id);
         }*/
    }
    
}

