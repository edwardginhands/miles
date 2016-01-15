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
    public class JourneyLogRepo : IJourneyLogRepo
    {
        private MilesDb db = new MilesDb();

        public IEnumerable<IJourneyLog> All()
        {
            return db.Set<Dto.JourneyLog>().Select(item => MapFromDto(item));
        }


        public void Dispose()
        {
            db.Dispose();
        }

        public IJourneyLog Single(int Id)
        {
           return MapFromDto(db.JourneyLogs.Single(s => s.Id == Id));
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
            var dto = new Dto.JourneyLog
            {
                Id = journeyLog.Id,
                Journey = JourneyRepo.MapToDto(journeyLog.Journey),
                Date = journeyLog.Date
            };

            return dto;
        }

        private IJourneyLog MapFromDto(Dto.JourneyLog dto)
        {
            return new JourneyLog
            {
                Id = dto.Id,
                Journey = JourneyRepo.MapFromDto(dto.Journey),
                Date = dto.Date
            };
        }
    }
}
