using velocityraptor.Model;

namespace velocityraptor.Services
{
    public interface ICapacityCalculator
    {
        public float CalculateSprintCapacity(Product product, float daysAvailableInSprint);
    }
}