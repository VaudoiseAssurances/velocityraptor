using velocityraptor.Model;

namespace velocityraptor.Services
{
    internal interface ICapacityCalculator
    {
        public float CalculateSprintCapacity(Product product, float daysAvailableInSprint);
    }
}