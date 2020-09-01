using System;
using Microsoft.AspNetCore.Mvc;
using velocityraptor.Model;
using velocityraptor.Services;

namespace velocityraptor.Controllers
{
    public class ProductsController : ControllerBase
    {
        private readonly IPersistenceService persistenceService;

        public ProductsController(IPersistenceService persistenceService)
        {
            this.persistenceService = persistenceService;
        }

        // GET
        public Project Index(Guid id)
        {
            return this.persistenceService.GetProject(id);
        }

        public IActionResult Create(Project project)
        {
            project.Id = new Guid();
            this.persistenceService.AddProject(project);
            return CreatedAtAction("Index", project.Id);
        }
    }
}