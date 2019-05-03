using GFT.Starter.Core.Models;
using GFT.Starter.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.Starter.Infrastructure.Repositories
{
    public class FacadeRepository
    {
        private IWriteRepository<Owner> OwnerWrite { get;}
        private IReadOnlyRepository<Owner> OwnerRead { get;}
        //private IWriteRepository<ServiceOrder> ServiceOrderWrite{ get; }
        //private IReadOnlyRepository<ServiceOrder> ServiceOrderRead { get; }
        //private IWriteRepository<Car> CarWrite{ get; }
        //private IReadOnlyRepository<Car> CarRead { get; }

        public void Read(Car car)
        {
            //something
        }

        public IEnumerable<Owner> ReadAll(OwnerController owner)
        {
            return OwnerRead.Get();
        }
    }
}
