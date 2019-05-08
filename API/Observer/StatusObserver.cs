using GFT.Starter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFT.Starter.API.Observer
{
    public class StatusObserver : IObservable<Car>
    {
        public List<IObserver<Car>> Cars;

        public Car Car;

        public CarStatus status;

        public StatusObserver(Car Car)
        {
            Cars = new List<IObserver<Car>>();
            this.Car = Car;
        }

        public IDisposable Subscribe(IObserver<Car> observer)
        {
            foreach(IObserver<Car> car in Cars)
            {
                Car.SetStatus(status);
                car.OnNext(Car);
            }

            return new Disposer(Cars, observer);
        }
    }
}
