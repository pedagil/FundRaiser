using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FundRaiser.Models;
using FundRaiser.Interfaces;
using FundRaiser.Options;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace FundRaiser.Controllers
{
    public class ProjectsController : Controller
    {

        private readonly IProjectService _projectService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProjectsController(IProjectService service, IWebHostEnvironment hostEnvironment)
        {
            _projectService = service;
            
            _hostEnvironment = hostEnvironment;


        }

        // GET: Projects
        public async Task<IActionResult> IndexCreator()
        {
            var allProjects = await _projectService.GetProjects();
            return View(allProjects);
        }

        public async Task<IActionResult> IndexBacker()
        {
            var allProjects = await _projectService.GetProjects();
            return View(allProjects);
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {


            var projectDetails = await _projectService.GetProjectByIdAsync(id.Value);


            return View(projectDetails);
        }
        public async Task<IActionResult> DetailsBacker(int? id)
        {


            var projectDetails = await _projectService.GetProjectByIdAsync(id.Value);
            

            return View(projectDetails);
        }



        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,ImageFile,Video,Status,ExpireDate,StartDate,TotalAmount")] ProjectOptions projectOptions)
        {
            if (ModelState.IsValid)
            {

                Project temp_project = await _projectService.CreateProjectAsync(new ProjectOptions
                {
                    Description = projectOptions.Description,
                    Title = projectOptions.Title,
                    Status = projectOptions.Status,
                    TotalAmount=0,
                    ExpireDate = projectOptions.ExpireDate,
                    //Photo = project.Photo, exoume ImageFile
                    ImageFile= projectOptions.ImageFile,
                    StartDate = DateTime.Now
                    //Video = project.Video
                });
                    
                 /*   _context.Add(project);
                await _context.SaveChangesAsync();*/
                return RedirectToAction(nameof(Create), "Rewards", new { Id = temp_project.Id});
            }
            return View(projectOptions);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Console.WriteLine($"id in edit from project controller {id}");
            var project = await _projectService.EditProjectAsync(id.Value);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

       // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Photo,Video,Status,ExpireDate,StartDate,TotalAmount")] Project project)
        {

            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /* _context.Update(project);
                     await _context.SaveChangesAsync();*/
                    await _projectService.EditProjectByIdAsync(
                     new ProjectOptions
                    {
                         Id=project.Id,
                        Description = project.Description,
                        Title = project.Title,
                        //Status = project.Status,
                        //TotalAmount=projectOptions.TotalAmount,
                        ExpireDate = project.ExpireDate,
                        Photo = project.Photo,
                        //StartDate = project.StartDate,
                        //Video = project.Video
                    });

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_projectService.ProjectExists(project.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexCreator));
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _projectService.GetProjectByIdAsync(id.Value);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            await _projectService.DeleteProjectByIdAsync(id);
            return RedirectToAction(nameof(IndexCreator));
        }
        
       

            /* private bool ProjectExists(int id)
             {
                 return _context.Project.Any(e => e.Id == id);
             }*/
        }
}

