using Miles.Object;
using System;

namespace Miles.Interface
{
    public interface IJourneyLog
    {
        int Id { get; set; }
        int JourneyId { get; set; }
        string Date { get; set; }
        ILocation StartLocation { get; set; }
        ILocation EndLocation { get; set; }
        decimal Distance { get; set; }
    }
}