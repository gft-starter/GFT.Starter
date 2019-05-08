using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.Contracts
{
    public interface IWriteRepository<T>
    {

        void Add(T write);
        T Remove(T write);
        T Update(T write);
    }
}
