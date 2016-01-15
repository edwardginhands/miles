namespace Miles.Interface
{
    public interface IJourney
    {
        decimal Distance { get; set; }
        ILocation EndLocation { get; set; }
        int Id { get; set; }
        ILocation StartLocation { get; set; }
    }
}