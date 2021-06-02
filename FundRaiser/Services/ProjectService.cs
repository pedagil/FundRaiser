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
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;
        

        public ProjectService(ApplicationDbContext context)
        {
            _context = context;

            
        }
        public async Task<List<Project>> GetProjects()
        {
           
            return await _context.Project.ToListAsync();


        }
        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var project = await _context.Project.SingleOrDefaultAsync(pro => pro.Id == id);
            return project;
        }

        public async Task<Project> CreateProjectAsync(ProjectOptions projectOptions)
        {
            var newProject = new Project { Description = projectOptions.Description,
                                            Title=projectOptions.Title,
                                            Status=projectOptions.Status,
                                            //TotalAmount=projectOptions.TotalAmount,
                                            ExpireDate=projectOptions.ExpireDate,
                                             Photo=projectOptions.Photo,
                                             StartDate=projectOptions.StartDate,
                                             Video=projectOptions.Video
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
                Description = projectOptions.Description,
                Title = projectOptions.Title,
                Status = projectOptions.Status,
                //TotalAmount=projectOptions.TotalAmount,
                ExpireDate = projectOptions.ExpireDate,
                Photo = projectOptions.Photo,
                StartDate = projectOptions.StartDate,
                Video = projectOptions.Video
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
            var projectToDelete  = await GetProjectByIdAsync(id);


            
            _context.Project.Remove(projectToDelete);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
