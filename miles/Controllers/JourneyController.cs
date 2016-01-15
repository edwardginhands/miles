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
    [Route("api/journeys")]
    public class JourneyController : Controller
    {
        private IJourneyRepo _repo;

        public JourneyController(IJourneyRepo repo)
        {
            _repo = repo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<IJourney> Get()
        {
            var items = _repo.All();
            return items;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IJourney Get(int id)
        {
            return _repo.Single(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Journey journey)
        {
            _repo.Add(journey);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]Journey journey)
        {
            _repo.Update(journey);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
