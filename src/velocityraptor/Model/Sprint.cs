using System;

namespace velocityraptor.Model
{
    public class Sprint
    {
        public string Name { get; set; }
        public Guid? Id { get; set; }
        public DeveloperAvailability[] DeveloperAvailabilities { get; set; }

        public int? AchievedPoints { get; set; }
        public float Capacity { get; set; }
    }
}