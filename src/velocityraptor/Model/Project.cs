using Microsoft.Extensions.Caching.Memory;

namespace velocityraptor.Model
{
    public class Project
    {
        public string Name { get; set; }
        public Developer[] Developers { get; set; }
        public Sprint[] Sprints { get; set; }
    }
}
