namespace SpaceStation.Factories.Contracts
{
    using SpaceStation.Models.Planets.Contracts;

    public interface IPlanetFactory
    {
        IPlanet CreatePlanet(string planetName, params string[] items);
    }
}
