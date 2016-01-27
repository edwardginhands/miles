using Miles.Object;
namespace Miles.Interface
{
    public interface IJourney
    {
        int Id { get; set; }
        decimal Distance { get; set; }
        Location EndLocation { get; set; }
        Location StartLocation { get; set; }
    }
}