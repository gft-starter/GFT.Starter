using GFT.Starter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFT.Starter.API.Observer
{
    public class Disposer : IDisposable
    {

        public List<IObserver<Car>> Cars;

        public IObserver<Car> Observer;

        public Disposer (List<IObserver<Car>> cars, IObserver<Car> observer)
        {
            Cars = cars;
            Observer = observer;
        }
        public void Dispose()
        {
            if (Cars.Contains(Observer))
            {
                Cars.Remove(Observer);
            }
        }
    }
}
