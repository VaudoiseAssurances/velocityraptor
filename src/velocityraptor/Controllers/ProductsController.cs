using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using velocityraptor.Model;
using velocityraptor.Services;

namespace velocityraptor.Controllers
{
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IPersistenceService persistenceService;

        public ProductsController(IPersistenceService persistenceService)
        {
            this.persistenceService = persistenceService;
        }

        // GET
        [Route("{productId}")]
        public IActionResult Index(Guid productId)
        {
            if (productId == Guid.Empty)
            {
                return NotFound();
            }

            return Ok(this.persistenceService.GetProduct(productId));
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.Id = Guid.NewGuid();
            this.persistenceService.AddProduct(product);
            return CreatedAtAction("Index", product.Id);
        }

        [HttpPost]
        [Route("{productId}/developers")]
        public void AddDeveloper(Guid productId, Developer developer)
        {
            developer.Id = Guid.NewGuid();
            var product = this.persistenceService.GetProduct(productId);
            product.Developers.Add(developer);
            this.persistenceService.UpdateProject(product);
        }

        [HttpPost]
        [Route("{productId}/developers/{developerId}")]
        public StatusCodeResult RemoveDeveloper(Guid productId, Guid developerId)
        {
            var product = this.persistenceService.GetProduct(productId);
            var developerToRemove = product.Developers.SingleOrDefault(o => o.Id == developerId);
            if (developerToRemove == null)
            {
                return NotFound();
            }
            product.Developers.Remove(developerToRemove);
            this.persistenceService.UpdateProject(product);
            return StatusCode(201);
        }
    }
}