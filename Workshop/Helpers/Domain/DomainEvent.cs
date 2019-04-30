using System;
using System.Collections.Generic;

namespace Helpers.Domain
{
    public abstract class DomainEvent
    {
        public string Type => GetType().Name;

        public DateTime Created { get; private set; }

        public Dictionary<string, Object> Args { get; private set; }

        public string CorrelationId { get; set; }

        public DomainEvent()
        {
            Created = DateTime.Now;
            Args = new Dictionary<string, Object>();
        }

        public abstract void Flatten();
    }
}
