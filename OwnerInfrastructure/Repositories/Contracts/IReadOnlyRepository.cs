﻿using System;
using System.Collections.Generic;

namespace OwnerInfrastructure.Repositories.Contracts
{
    public interface IReadOnlyRepository<T>
    {
        T Find(Guid id);
        IEnumerable<T> Get();
    }
}
