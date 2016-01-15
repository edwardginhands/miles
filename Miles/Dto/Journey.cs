

namespace Miles.Dto
{
    public class Journey
    {
        public int Id { get; set; }
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
        public decimal Distance { get; set; }
    }
}
