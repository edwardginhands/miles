using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miles.Database;
using Miles.Object;
using System.Linq.Expressions;
using Miles.Interface;
using Microsoft.Data.Entity;
using System.Globalization;

namespace Miles.Repo
{
    public class JourneyLogRepo : IJourneyLogRepo
    {
        private MilesDb db = new MilesDb();

        public IEnumerable<IJourneyLog> All()
        {
            var items = db.Set<Dto.JourneyLog>()
                .Include(j => j.Journey)
                .Include(j => j.Journey.StartLocation)
                .Include(j => j.Journey.EndLocation);

            var list = new List<IJourneyLog>();
           
            foreach (var i in items)
            {
                var toAdd = MapFromDto(i);
                list.Add(toAdd);
            }

            return list;
        }

        public IJourneyLogList AllAsList()
        {
            IJourneyLogList toReturn = new JourneyLogList();
            var items = db.Set<Dto.JourneyLog>()
                .Include(j => j.Journey)
                .Include(j => j.Journey.StartLocation)
                .Include(j => j.Journey.EndLocation);

            var list = new List<IJourneyLog>();
            decimal totalDistance = 0;
            DateTime minDate;
            DateTime maxDate;
            foreach (var i in items)
            {
                var toAdd = MapFromDto(i);
                list.Add(toAdd);
                totalDistance += toAdd.Distance;
            }



            return toReturn;
        }


        public void Dispose()
        {
            db.Dispose();
        }

        public IJourneyLog Single(int Id)
        {
            return MapFromDto(db.JourneyLogs.Include(j => j.Journey).Single(s => s.Id == Id));
        }

        public void Add(IJourneyLog entity)
        {
            var dto = MapToDto(entity);
            db.JourneyLogs.Add(dto);
            db.SaveChanges();
        }


        public void Update(IJourneyLog entity)
        {
            var newValues = MapToDto(entity);
            var exiting = db.Journeys.Single(s => s.Id == newValues.Id);
            if (exiting != null)
            {
                db.JourneyLogs.Update(newValues);
                db.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            var exiting = db.JourneyLogs.Single(s => s.Id == Id);
            if (exiting != null)
            {
                db.JourneyLogs.Remove(exiting);
                db.SaveChanges();
            }
        }

        private Dto.JourneyLog MapToDto(IJourneyLog journeyLog)
        {
            var journey = db.Journeys.Single(s => s.Id == journeyLog.JourneyId);

            var dto = new Dto.JourneyLog
            {
                Id = journeyLog.Id,
                Journey = journey,
                Date = DateTime.ParseExact(journeyLog.Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)
            };

            return dto;
        }

        private IJourneyLog MapFromDto(Dto.JourneyLog dto)
        {
            return new JourneyLog
            {
                Id = dto.Id,
                JourneyId = dto.Journey.Id,
                Date = dto.Date.ToString("dd-MM-yyyy"),
                StartLocation = LocationRepo.MapFromDto(dto.Journey.StartLocation),
                EndLocation = LocationRepo.MapFromDto(dto.Journey.EndLocation),
                Distance = dto.Journey.Distance
            };
        }
    }
}
