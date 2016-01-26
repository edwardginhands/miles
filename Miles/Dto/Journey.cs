

namespace Miles.Dto
{
    public class Journey
    {
        public int Id { get; set; }
        public virtual Location StartLocation { get; set; }
        public virtual Location EndLocation { get; set; }
        public decimal Distance { get; set; }
    }
}
