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
        public IActionResult Index()
        {
            throw new NotImplementedException();
        }

        public IActionResult Create(Project project)
        {
            this.persistenceService.AddProject(project);
            throw new NotImplementedException();
        }
    }
}