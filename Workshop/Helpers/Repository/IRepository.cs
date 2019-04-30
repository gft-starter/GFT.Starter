using System;
using System.Collections.Generic;

namespace Helpers.Repository
{
    public interface IRepository<T>
    {
        T Find(Guid id);
        IEnumerable<T> Get();
        void Add(T car);
        T Remove(T car);
        T Update(T car);
    }
}