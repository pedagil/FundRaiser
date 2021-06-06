using FundRaiser.Models;
using FundRaiser.Options;
using FundRaiser.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundRaiser.Interfaces
{
    public interface IProjectService 
    {
        public Task<List<Project>> GetProjects();


        public Task<ProjectRewardsViewModel> GetProjectByIdAsync(int id );

        public Task<Project> CreateProjectAsync(ProjectOptions projectoptions);

        public Task<Project> EditProjectAsync(int id);

        public Task<Project> EditProjectByIdAsync(ProjectOptions projectoptions);

        public bool ProjectExists(int id);

        public Task<Project> DeleteProjectByIdAsync(int id);

    }
}
