using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using velocityraptor.Model;
using velocityraptor.Services;

namespace velocityraptor.Controllers
{
    [Route("{productId}/sprints")]
    public class SprintsController : ControllerBase
    {
        private readonly IPersistenceService persistenceService;
        private ICapacityCalculator capacityCalculator;

        public SprintsController(IPersistenceService persistenceService)
        {
            this.persistenceService = persistenceService;
        }

        [Route("sprintId")]
        public Sprint Index(Guid sprintId, Guid productId)
        {
            var product = this.persistenceService.GetProduct(productId);
            var sprint = product.Sprints.Single(o => o.Id == sprintId);

            var daysAvailabilityInSprint = sprint.SprintAvailabilities.Sum(o => o.Availability);
            sprint.Capacity = this.capacityCalculator.CalculateSprintCapacity(product, daysAvailabilityInSprint);

            return sprint;
        }

        [HttpPost]
        [Route("sprintId/achieved-points")]
        public IActionResult Index(Guid sprintId, Guid productId, [FromBody]int achievedPoints)
        {
            var product = this.persistenceService.GetProduct(productId);
            var sprint = product.Sprints.Single(o => o.Id == sprintId);

            sprint.AchievedPoints = achievedPoints; 

            this.persistenceService.UpdateProject(product);

            return StatusCode(201);
        }



        [Route("sprintId")]
        public IActionResult Create(Guid sprintId, Product product)
        {
            product.Id = Guid.NewGuid();
            this.persistenceService.AddProduct(product);
            return CreatedAtAction("Index", sprintId, product.Id);
        }
    }
}