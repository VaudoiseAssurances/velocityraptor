using System.Linq;
using velocityraptor.Model;

namespace velocityraptor.Services
{
    public class CapacityCalculator : ICapacityCalculator
    {
        public float CalculateSprintCapacity(Product product, float daysAvailableInSprint)
        {
            var completedSprints = product.Sprints
                .Where(o => o.AchievedPoints != null)
                .ToArray();
            float velocityAccumulator = 0;
            foreach (var sprint in completedSprints)
            {
                var availability = sprint.SprintAvailabilities.Sum(o => o.Availability);
                velocityAccumulator += sprint.AchievedPoints.Value / availability;
            }

            float capacity = (velocityAccumulator / completedSprints.Length) * daysAvailableInSprint;

            return capacity;
        }
    }
}