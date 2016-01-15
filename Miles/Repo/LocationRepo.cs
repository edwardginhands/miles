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
    public class LocationRepo : ILocationRepo
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


        public void SetProfile(int locationId, bool IsHome) //1 home, 0 work
        {
            var location = db.Locations.Single(s => s.Id == locationId);
            if (location != null)
            {
                if (db.Profiles.Count() > 0)
                {
                    var profile = db.Profiles.OrderBy(i => i.Id).First();
                    profile.HomeLocation = IsHome ? location : profile.HomeLocation;
                    profile.WorkLocation = !IsHome ? location : profile.WorkLocation;
                    db.Profiles.Update(profile);
                }
                else
                {
                    db.Profiles.Add(new Dto.Profile {
                        HomeLocation = IsHome ? location : null,
                        WorkLocation = !IsHome ? location : null
                    });
                }
                db.SaveChanges();
            }

        }


        private Dto.Location GetLocation(int Id)
        {
            return db.Locations.Single(s => s.Id == Id);
        }


        public static Dto.Location MapToDto(ILocation location)
        {
            var dto = new Dto.Location
            {
                Id = location.Id,
                Name = location.Name
            };

            return dto;
        }

        public static ILocation MapFromDto(Dto.Location dto)
        {
            return new Location
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}
