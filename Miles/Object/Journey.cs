using Miles.Interface;

namespace Miles.Object
{
    public class Journey : IJourney
    {
        public int Id { get; set; }
        public ILocation StartLocation { get; set; }
        public ILocation EndLocation { get; set; }
        public decimal Distance { get; set; }
    }
}
