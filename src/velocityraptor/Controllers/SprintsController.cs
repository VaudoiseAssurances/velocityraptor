using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using velocityraptor.Model;
using velocityraptor.Services;

namespace velocityraptor.Controllers
{
    [Route("api/products/{productId}/sprints")]
    public class SprintsController : ControllerBase
    {
        private readonly IPersistenceService persistenceService;
        private readonly ICapacityCalculator capacityCalculator;

        public SprintsController(IPersistenceService persistenceService, ICapacityCalculator capacityCalculator)
        {
            this.persistenceService = persistenceService;
            this.capacityCalculator = capacityCalculator;
        }

        [Route("{sprintId}")]
        public Sprint Index(Guid sprintId, Guid productId)
        {
            var product = this.persistenceService.GetProduct(productId);
            var sprint = product.Sprints.Single(o => o.Id == sprintId);

            return sprint;
        }

        [HttpPost]
        [Route("{sprintId}/achieved-points")]
        public IActionResult Index(Guid sprintId, Guid productId, [FromBody]int achievedPoints)
        {
            var product = this.persistenceService.GetProduct(productId);
            var sprint = product.Sprints.Single(o => o.Id == sprintId);

            sprint.AchievedPoints = achievedPoints; 

            this.persistenceService.UpdateProject(product);

            return StatusCode(201);
        }



        [HttpPost]
        public IActionResult Create(Guid productId, [FromBody]Sprint sprint)
        {
            sprint.Id = Guid.NewGuid();
            var product = this.persistenceService.GetProduct(productId);
            product.Sprints.Add(sprint);

            var daysAvailabilityInSprint = sprint.DeveloperAvailabilities.Sum(o => o.Availability);
            var sprintCapacity = this.capacityCalculator.CalculateSprintCapacity(product, daysAvailabilityInSprint);
            if (!float.IsNaN(sprintCapacity))
            {
                sprint.Capacity = sprintCapacity;
            }

            this.persistenceService.UpdateProject(product);
            return CreatedAtAction("Index", sprint, product.Id);
        }
    }
}