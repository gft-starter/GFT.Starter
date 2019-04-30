namespace GFT.Starter.Core.Models
{
    public class Motorcycle : Vehicle
    {
        public void ChangeTire1()
        {
        }

        public void ChangeTire2()
        {
        }

        public override int PriceMultiplier { get; } = 1;

        public override void ChangeTires()
        {
            ChangeTire1();
            ChangeTire2();
        }
    }
}
