using System;
using System.Collections.Generic;

namespace velocityraptor.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Sprint> Sprints { get; set; }
    }
}
