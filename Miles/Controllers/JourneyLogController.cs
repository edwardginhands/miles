using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Miles.Interface;
using Miles.Object;
using Miles.Repo;

namespace Miles.Controllers
{
    [Route("api/journeylogs")]
    public class JourneyLogController : Controller
    {
        private IJourneyLogRepo _repo;

        public JourneyLogController(IJourneyLogRepo repo)
        {
            _repo = repo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<IJourneyLog> Get()
        {
            var items = _repo.All();
            return items;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IJourneyLog Get(int id)
        {
            return _repo.Single(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] JourneyLog journeyLog)
        {
            _repo.Add(journeyLog);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]JourneyLog journeyLog)
        {
            _repo.Update(journeyLog);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
