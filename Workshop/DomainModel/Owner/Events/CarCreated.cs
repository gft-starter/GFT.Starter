using Helpers.Domain;

namespace DomainModel.Owner.Events
{
    public class CarCreated : DomainEvent
    {
        public Car Car { get; set; }

        public override void Flatten()
        {
            Args.Add(nameof(Car.Id), Car.Id);
            Args.Add(nameof(Car.Brand), Car.Brand);
            Args.Add(nameof(Car.Model), Car.Model);
            Args.Add(nameof(Car.Year), Car.Year);
            Args.Add(nameof(Car.Plate), Car.Plate);
            Args.Add(nameof(Car.Owner.Name), Car.Owner.Name);
        }
    }
}
