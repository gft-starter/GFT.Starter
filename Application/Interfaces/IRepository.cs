using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    interface IRepository<T>
    {
        T find(Guid id);
        IEnumerable<T> Get();
        void Add(T x);
        T Remove(T x);
        T Update(T x);

    }
}
