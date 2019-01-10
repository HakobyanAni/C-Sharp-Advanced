using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public enum Planets
    {
        Mercury = 1,
        Venus,
        Earth,
        Mars,
        Jupiter,
        Saturn,
        Uranus,
        Neptune
    }

    public class SolarSystem
    {
        private Planets PlanetName { get; set; }
        private int PlaceInGalaxy { get; set; }

        private SolarSystem(Planets planetName, int placeInGalaxy)
        {
            PlanetName = planetName;
            PlaceInGalaxy = placeInGalaxy;
        }

        public SolarSystem()
        {

        }
        private void RotatePlanet(Planets planetName)
        {
            Console.WriteLine($"{planetName} rotates around the sun.");
        }
    }
}
