namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;

    public class StreetRacer : Racer
    {
        //  StreetRacer always starts with 10 driving experience and always have "aggressive" racing behavior.

        private const int drivingExperienceStreetRacer = 10;
        private const string racingBehaviorStreetRacer = "aggressive";

        public StreetRacer(string username, ICar car) : base(username, racingBehaviorStreetRacer, drivingExperienceStreetRacer, car)
        {
        }
        // and StreetRacer increases his driving experience with 5 every time he races
        public override void Race()
        {
            base.Race();
            DrivingExperience += 5;
        }
    }
}
