using System;
using System.Collections.Generic;
using System.Text;

namespace OwnerInfrastructure.Repositories.Contracts
{
    interface IWriteRepository<T>
    {
        void Add(T car);
        T Remove(T car);
        T Update(T car);
    }
}
