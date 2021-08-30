namespace CarRacing.Models.Cars
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Utilities.Messages;
    using System;

    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;

        protected Car(string make, string model, string vIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            Make = make;
            Model = model;
            VIN = vIN;
            HorsePower = horsePower;
            FuelAvailable = fuelAvailable;
            FuelConsumptionPerRace = fuelConsumptionPerRace;
        }
        //•	Make – string
        //    o   If the make is null or whitespace, throw an ArgumentException with message: "Car make cannot be null or empty."

        public string Make
        {
            get => make;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                }

                make = value;
            }
        }
        //•	Model – string
        //    o   If the model is null or whitespace, throw an ArgumentException with message: "Car model cannot be null or empty."

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                }
                model = value;
            }
        }

        //•	VIN – string
        //    o   If the VIN is not exactly 17 characters long, throw an ArgumentException with message: "Car VIN must be exactly 17 characters long."
        //o All VINs will be unique

        public string VIN
        {
            get => vin;
            private set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                }

                vin = value;
            }
        }

        //•	HorsePower – int
        //    o   If the horse power is below 0, throw an ArgumentException with message: "Horse power cannot be below 0."

        public int HorsePower
        {
            get => horsePower;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                }

                horsePower = value;
            }
        }

        //•	FuelAvailable – double
        //    o   If the fuel available drops below 0, just set it to 0

        public double FuelAvailable
        {
            get => fuelAvailable;
            private set
            {
                if (value < 0)
                {
                    fuelAvailable = 0;
                }

                fuelAvailable = value;
            }
        }

        //•	FuelConsumtpionPerRace – double
        //    o   If the fuel consumption per race is below 0, throw an ArgumentException with message: "Fuel consumption cannot be below 0."

        public double FuelConsumptionPerRace
        {
            get => fuelConsumptionPerRace;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                }

                fuelConsumptionPerRace = value;
            }
        }

        //The Drive() method should reduce the fuel available by the fuel consumption per race.Also when driving TunedCar reduces its horse power by 3% every time because of engine wear.  Horse power should be rounded to the closest integer number.
        public virtual void Drive()
        {
            FuelAvailable -= fuelConsumptionPerRace;
        }
    }
}
