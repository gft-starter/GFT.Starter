using System;

namespace Helpers.Domain
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}
