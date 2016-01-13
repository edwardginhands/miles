using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miles.Database;
using Miles.Object;
using System.Linq.Expressions;
using Miles.Interface;


namespace Miles.Repo
{
    public class LocationRepo : IRepo<ILocation>
    {
        private MilesDb db = new MilesDb();

        public IEnumerable<ILocation> All()
        {
            return db.Set<Dto.Location>().Select(item => MapFromDto(item));
        }


        public void Dispose()
        {
            db.Dispose();
        }

        public ILocation Single(int Id)
        {
           return MapFromDto(db.Locations.Single(s => s.Id == Id));
        }

        public void Add(ILocation entity)
        {
            var dto = MapToDto(entity);
            db.Locations.Add(dto);
            db.SaveChanges();
        }


        public void Update(ILocation entity)
        {
            var newValues = MapToDto(entity);
            var exiting = db.Locations.Single(s => s.Id == newValues.Id);
            if (exiting != null)
            {
                db.Locations.Update(newValues);
                db.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            var exiting = db.Locations.Single(s => s.Id == Id);
            if (exiting != null)
            {
                db.Locations.Remove(exiting);
                db.SaveChanges();
            }
        }

        private Dto.Location MapToDto(ILocation location)
        {
            var dto = new Dto.Location
            {
                Id = location.Id,
                Name = location.Name
            };

            return dto;
        }

        private ILocation MapFromDto(Dto.Location dto)
        {
            return new Location
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}
