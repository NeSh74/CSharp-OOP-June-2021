namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double BusAirConditionModifier = 1.4;

        public Bus(double fuel, double fuelConsumption, double tankCapacity)
            : base(fuel, fuelConsumption, tankCapacity, BusAirConditionModifier)
        {
        }

        public void TurnOnAirConditiner()
        {
            this.AirConditionerModifier = BusAirConditionModifier;
        }

        public void TurnOffAirConditiner()
        {
            this.AirConditionerModifier = 0;
        }
    }
}