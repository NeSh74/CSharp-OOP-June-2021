namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;

    public class ProfessionalRacer : Racer
    {
        //ProfessionalRacer always starts with 30 driving experience and always have "strict" racing behavior.

        private const int drivingExperienceProfessionalRacer = 30;
        private const string racingBehaviorProfessionalRacer = "strict";

        public ProfessionalRacer(string username, ICar car) 
            : base(username, racingBehaviorProfessionalRacer, drivingExperienceProfessionalRacer, car)
        {
        }
        // ProfessionalRacer increases his driving experience with 10 everytime he races
        public override void Race()
        {
            base.Race();
            DrivingExperience += 10;
        }
    }
}
