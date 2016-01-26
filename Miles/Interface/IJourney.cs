namespace Miles.Interface
{
    public interface IJourney
    {
        int Id { get; set; }
        decimal Distance { get; set; }
        ILocation EndLocation { get; set; }
        ILocation StartLocation { get; set; }
    }
}