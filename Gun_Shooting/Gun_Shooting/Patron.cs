using System;

namespace Gun_Shooting
{
    public class Patron
    {
        public Calipers Caliper { get; set; }
        public int MaxDistance { get; set; }

        public Patron()
        {

        }

        public Patron(Calipers caliper, int maxDistance)
        {
            Caliper = caliper;
            MaxDistance = maxDistance;
        }
    }
}
