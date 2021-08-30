namespace CarRacing.Models.Cars
{
    using System;

    public class TunedCar : Car
    {
        private const double fuelAvailableTunedCar = 65;
        private const double fuelConsumptionPerRaceTunedCar = 7.5;

        //Constructor should take string make, string model, string VIN and int horsePower upon initialization.
        //    TunedCar always starts with 65 liters available fuel and 7.5 liters fuel consumption per race.

        public TunedCar(string make, string model, string vIN, int horsePower)
            : base(make, model, vIN, horsePower, fuelAvailableTunedCar, fuelConsumptionPerRaceTunedCar)
        {
        }

        //Also when driving TunedCar reduces its horse power by 3% every time because of engine wear.Horse power should be rounded to the closest integer number.
        public override void Drive()
        {
            base.Drive();
            HorsePower = (int)Math.Round(HorsePower * 0.97);
        }
    }
}
