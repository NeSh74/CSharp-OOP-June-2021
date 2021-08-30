namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Text;

    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;

        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
            Car = car;
        }

        //o If the username is null or whitespace, throw an ArgumentException with message: "Username cannot be null or empty."
        //o All usernames are unique

        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }

                username = value;
            }
        }

        //o If the racing behavior is null or whitespace, throw an ArgumentException with message: "Racing behavior cannot be null or empty."

        public string RacingBehavior
        {
            get => racingBehavior;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }

                racingBehavior = value;
            }
        }

        //o If the driving experience is below 0 or over 100, throw an ArgumentException with message: "Racer driving experience must be between 0 and 100."

        public int DrivingExperience
        {
            get => drivingExperience;
            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }

                drivingExperience = value;
            }
        }

        //o If the car is null, throw an ArgumentException with message:
        //"Car cannot be null or empty."

        public ICar Car
        {
            get => car;
            private set
            {
                if (value is null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }

                car = value;
            }
        }

        //When the Race() method is being called, the Racer's car is beign driven. Also everytime Racer is racing, his driving experience is being increased depending on the racer type. ProfessionalRacer increases his driving experience with 10 everytime he races and StreetRacer increases his driving experience with 5 every time he races. 
        public virtual void Race()
        {
            Car.Drive();
        }

        //Returns if the Racer is available for a race.Racer is available for a race only if his Car has enough fuel available for completing a race.

        public bool IsAvailable() => car.FuelAvailable >= car.FuelConsumptionPerRace;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{GetType().Name}: {Username}");
            sb.AppendLine($"--Driving behavior: {RacingBehavior}");
            sb.AppendLine($"--Driving experience: {DrivingExperience}");
            sb.AppendLine($"--Car: {car.Make} {car.Model} ({car.VIN})");

            return sb.ToString().TrimEnd();
        }
    }
}
