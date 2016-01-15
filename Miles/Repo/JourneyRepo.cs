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
    public class JourneyRepo : IJourneyRepo
    {
        private MilesDb db = new MilesDb();

        public IEnumerable<IJourney> All()
        {
            return db.Set<Dto.Journey>().Select(item => MapFromDto(item));
        }


        public void Dispose()
        {
            db.Dispose();
        }

        public IJourney Single(int Id)
        {
           return MapFromDto(db.Journeys.Single(s => s.Id == Id));
        }

        public void Add(IJourney entity)
        {
            var dto = MapToDto(entity);
            db.Journeys.Add(dto);
            db.SaveChanges();
        }


        public void Update(IJourney entity)
        {
            var newValues = MapToDto(entity);
            var exiting = db.Journeys.Single(s => s.Id == newValues.Id);
            if (exiting != null)
            {
                db.Journeys.Update(newValues);
                db.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            var exiting = db.Journeys.Single(s => s.Id == Id);
            if (exiting != null)
            {
                db.Journeys.Remove(exiting);
                db.SaveChanges();
            }
        }

        public static Dto.Journey MapToDto(IJourney journey)
        {
            var dto = new Dto.Journey
            {
                Id = journey.Id,
                Distance = journey.Distance,
                StartLocation = LocationRepo.MapToDto(journey.StartLocation),
                EndLocation = LocationRepo.MapToDto(journey.EndLocation)
            };

            return dto;
        }

        public static IJourney MapFromDto(Dto.Journey dto)
        {
            return new Journey
            {
                Id = dto.Id,
                Distance = dto.Distance,
                StartLocation = LocationRepo.MapFromDto(dto.StartLocation),
                EndLocation = LocationRepo.MapFromDto(dto.EndLocation)
            };
        }
    }
}
