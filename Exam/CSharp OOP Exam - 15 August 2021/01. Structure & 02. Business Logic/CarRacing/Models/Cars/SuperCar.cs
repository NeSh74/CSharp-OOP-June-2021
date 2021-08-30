namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double fuelAvailableSuperCar = 80;
        private const double fuelConsumptionPerRaceSuperCar = 10;

        //Constructor should take string make, string model, string VIN and int horsePower upon initialization.
        //    SuperCar always starts with 80 liters available fuel and 10 liters fuel consumption per race.

        public SuperCar(string make, string model, string vIN, int horsePower)
            : base(make, model, vIN, horsePower, fuelAvailableSuperCar, fuelConsumptionPerRaceSuperCar)
        {
        }
    }
}
