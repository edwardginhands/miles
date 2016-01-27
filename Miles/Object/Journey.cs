using Miles.Interface;

namespace Miles.Object
{
    public class Journey : IJourney
    {
        public int Id { get; set; }
        public Location EndLocation { get; set; }
        public Location StartLocation { get; set; }
        public decimal Distance { get; set; }
    }
}
