using FundRaiser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundRaiser.Interfaces
{
    public interface IProjectService 
    {
        public Task<List<Project>> GetProject();

    

    }
}
