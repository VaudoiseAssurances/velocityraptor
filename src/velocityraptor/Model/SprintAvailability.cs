namespace velocityraptor.Model
{
    public class SprintAvailability
    {
        /// <summary>
        /// Gets or sets the developer for which the <see cref="Availability"/> is described.
        /// </summary>
        /// <value>
        /// The developer.
        /// </value>
        public Developer Developer { get; set; }
        
        /// <summary>
        /// Gets or sets the availability in days.
        /// </summary>
        /// <value>
        /// The availability in days for a given <see cref="Developer"/>.
        /// </value>
        public float Availability { get; set; }
    }
}