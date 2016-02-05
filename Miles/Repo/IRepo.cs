using System;
using System.Collections.Generic;
using Miles.Interface;

namespace Miles.Repo
{
    public interface IRepo<T> : IDisposable where T : class
    {
        void Add(T entity);
        IEnumerable<T> All();
        T Single(int Id);
        void Update(T entity);
        void Delete(int Id);
    }

    public interface ILocationRepo : IRepo<ILocation>
    {
        void SetProfile(int locationId, bool IsHome);
    }

    public interface IJourneyRepo : IRepo<IJourney>
    {

    }

    public interface IJourneyLogRepo : IRepo<IJourneyLog>
    {
        IJourneyLogList AllAsList();
    }
}
