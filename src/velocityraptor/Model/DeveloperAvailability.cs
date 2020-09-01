namespace velocityraptor.Model
{
    public class DeveloperAvailability
    {
        /// <summary>
        /// Gets or sets the id of the developer for which the <see cref="Availability"/> is described.
        /// </summary>
        /// <value>
        /// The id of the developer.
        /// </value>
        public string  DeveloperId { get; set; }
        
        /// <summary>
        /// Gets or sets the availability in days.
        /// </summary>
        /// <value>
        /// The availability in days for a given <see cref="Developer"/>.
        /// </value>
        public float Availability { get; set; }
    }
}