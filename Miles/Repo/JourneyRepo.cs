using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miles.Database;
using Miles.Object;
using System.Linq.Expressions;
using Miles.Interface;
using Microsoft.Data.Entity;

namespace Miles.Repo
{
    public class JourneyRepo : IJourneyRepo
    {
        // private MilesDb db = new MilesDb();

        public IEnumerable<IJourney> All()
        {
            using (MilesDb db = new MilesDb())
            {
                /*
                var items = db.Journeys.Include(l => l.StartLocation).Include(l => l.EndLocation);

                var s = items.ToString();
                foreach (var i in items)
                {
                    var x = MapFromDto(i);
                }
                return null;
                */

                var list = new List<IJourney>();

                var items= db.Journeys.Include(l => l.StartLocation).Include(l => l.EndLocation);

                foreach (var i in items)
                {
                    var toAdd = MapFromDto(i);
                    list.Add(toAdd);
                }

                return list;
            }
        }


        public void Dispose()
        {
            using (MilesDb db = new MilesDb())
            {
                db.Dispose();
            }
        }

        public IJourney Single(int Id)
        {
            using (MilesDb db = new MilesDb())
            {
                return MapFromDto(db.Journeys.Single(s => s.Id == Id));
            }
        }

        public void Add(IJourney entity)
        {
            using (MilesDb db = new MilesDb())
            {
                var dto = MapToDto(entity);
                db.Journeys.Add(dto);
                db.SaveChanges();
                //db.Entry(dto).State = EntityState.Detached;
            }

        }


        public void Update(IJourney entity)
        {
            using (MilesDb db = new MilesDb())
            {
                var newValues = MapToDto(entity);
                var exiting = db.Journeys.Single(s => s.Id == newValues.Id);
                if (exiting != null)
                {
                    db.Journeys.Update(newValues);
                    db.SaveChanges();
                }
            }
        }

        public void Delete(int Id)
        {
            using (MilesDb db = new MilesDb())
            {
                var exiting = db.Journeys.Single(s => s.Id == Id);
                if (exiting != null)
                {
                    db.Journeys.Remove(exiting);
                    db.SaveChanges();
                }
            }
        }

        public Dto.Journey MapToDto(IJourney journey)
        {
            using (MilesDb db = new MilesDb())
            {
                var dto = new Dto.Journey
                {
                    Id = journey.Id,
                    Distance = journey.Distance,
                   // StartLocation = LocationRepo.MapToDto(journey.StartLocation),
                  //  EndLocation = LocationRepo.MapToDto(journey.EndLocation)
                };

                return dto;
            }
        }

        public static IJourney MapFromDto(Dto.Journey dto)
        {
   
            return new Journey
            {
                Id = dto.Id,
                Distance = dto.Distance,
                StartLocation = (Location) LocationRepo.MapFromDto(dto.StartLocation),
                EndLocation = (Location) LocationRepo.MapFromDto(dto.EndLocation)
            };

        }
    }
}
