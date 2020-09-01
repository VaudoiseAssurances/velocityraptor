using System;

namespace velocityraptor.Model
{
    public class Sprint
    {
        public Guid Id { get; set; }
        public SprintAvailability[] SprintAvailabilities { get; set; }

        public int? AchievedPoints { get; set; }
        public float Capacity { get; set; }
    }
}