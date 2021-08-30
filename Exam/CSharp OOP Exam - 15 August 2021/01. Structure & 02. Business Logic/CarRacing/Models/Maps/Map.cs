namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;

    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.RaceCannotBeCompleted);
            }

            if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

            if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            double racingOneBehaviorMultiplier = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            double chanceOfWinningRacerOnePoints =
                racerOne.Car.HorsePower * racerOne.DrivingExperience * racingOneBehaviorMultiplier;
            double racingTwoBehaviorMultiplier = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;
            double chanceOfWinningRacerTwoPoints =
                racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingTwoBehaviorMultiplier;
            racerOne.Race();
            racerTwo.Race();

            string winner = chanceOfWinningRacerOnePoints > chanceOfWinningRacerTwoPoints ? racerOne.Username : racerTwo.Username;

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner);
        }
    }
}
