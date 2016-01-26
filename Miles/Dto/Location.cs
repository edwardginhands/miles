

using System.Collections.Generic;

namespace Miles.Dto
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Journey> StartJourneys { get; set; }
        public List<Journey> EndJourneys { get; set; }
    }
}