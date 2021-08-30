namespace SpaceStation.Factories.Contracts
{
    using SpaceStation.Models.Astronauts.Contracts;

    public interface IAstronautFactory
    {
        IAstronaut CreateAstronaut(string type, string astronautName);
    }
}
