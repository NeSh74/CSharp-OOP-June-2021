namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly IList<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models
            => (IReadOnlyCollection<IPlanet>)this.planets;

        public void Add(IPlanet model)
            => this.planets.Add(model);

        public IPlanet FindByName(string name)
            => this.planets.FirstOrDefault(p => p.Name == name);

        public bool Remove(IPlanet model)
            => this.planets.Remove(model);
    }
}
