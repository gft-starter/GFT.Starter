using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
    }
}
