namespace GFT.Starter.Core.Models
{
    public class Car : Vehicle
    {
        public override int PriceMultiplier { get; } = 2;
        public override void ChangeFourTires() { }
    }
}
