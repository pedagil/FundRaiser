using FundRaiser.Data;
using FundRaiser.Interfaces;
using FundRaiser.Models;
using FundRaiser.Options;
using FundRaiser.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FundRaiser.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ILogger<ProjectService> _logger;


        public ProjectService(ApplicationDbContext context, IWebHostEnvironment hostEnvironment,ILogger<ProjectService> logger)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _logger = logger;
            
        }
        public async Task<List<Project>> GetProjects()
        {
           
            return await _context.Project.ToListAsync();


        }
        public async Task<ProjectRewardsViewModel> GetProjectByIdAsync(int id)
        {
            var project = await _context.Project.SingleOrDefaultAsync(pro => pro.Id == id);

            var rewardPackages = _context.Reward.Where(a => a.Project.Id == id && a.RewardStatus==null);

            var projectDetails = new ProjectRewardsViewModel
            {
                Project = project,
                ListOfRewards = rewardPackages.ToList()
            };

            return projectDetails;
        }

        public async Task<Project> CreateProjectAsync(ProjectOptions projectOptions)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(projectOptions.ImageFile.FileName);
            string extension = Path.GetExtension(projectOptions.ImageFile.FileName);
            projectOptions.Photo = fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
            string path = Path.Combine(wwwRootPath + "/Image", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await projectOptions.ImageFile.CopyToAsync(fileStream);
            }


            if (string.IsNullOrWhiteSpace(projectOptions.Title))
            {
                _logger.LogError("Please give a title to your Project");
                return null;
            }



            var newProject = new Project {                Description = projectOptions.Description,
                                            Title=projectOptions.Title,
                                            Status=projectOptions.Status,
                                            TotalAmount=projectOptions.TotalAmount,
                                            ExpireDate=projectOptions.ExpireDate,
                                             Photo=projectOptions.Photo,
                                             StartDate=projectOptions.StartDate
                                             //Video=projectOptions.Video
            };
            await _context.Project.AddAsync(newProject);
            await _context.SaveChangesAsync();
            return newProject;
        }
        public async Task<Project> EditProjectAsync(int id) {
            
            return  await _context.Project.FindAsync(id);

        }
        
        public async Task<Project> EditProjectByIdAsync(ProjectOptions projectOptions)
            {
            var updateProject = new Project
            {
                Id=projectOptions.Id,
                Description = projectOptions.Description,
                Title = projectOptions.Title,
                //Status = projectOptions.Status,
                //TotalAmount=projectOptions.TotalAmount,
                ExpireDate = projectOptions.ExpireDate,
                Photo = projectOptions.Photo,
               // StartDate = projectOptions.StartDate,
                //Video = projectOptions.Video
            };
            
            _context.Project.Update(updateProject);
            await _context.SaveChangesAsync();
            return updateProject;
        }
        public bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.Id == id);
        }

        public async Task<Project> DeleteProjectByIdAsync(int id)
        {
            //_context.Reward.RemoveAll(p => p.ProjectId == id);
            //_context.Reward.RemoveAll(_context.Reward.Where(p => p.ProjectId == id).ToList() );
            List<Reward> rewards =
            _context.Reward.Where(r => r.Project.Id == id).ToList();
            rewards.ForEach(r => _context.Reward.Remove(r));
            _context.SaveChanges();
            /*Rewards.ForEach(p => _context.Reward.Remove(p.ProjectId));
            _context.Reward.Except();*/
            var projectToDelete = await GetProjectByIdAsync(id);
            
            
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", projectToDelete.Project.Photo);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);


            _context.Project.Remove(projectToDelete.Project);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
