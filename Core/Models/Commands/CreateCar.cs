namespace Core.Models.Commands
{
    public class CreateCar
    {
        public CreateCar(Vehicle car)
        {
            Car = car;
        }

        public Vehicle Car { get; set; }
    }
}
