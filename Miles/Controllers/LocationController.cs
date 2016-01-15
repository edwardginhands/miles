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
    [Route("api/locations")]
    public class LocationController : Controller
    {
        private ILocationRepo _repo;

        public LocationController(ILocationRepo repo)
        {
            _repo = repo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<ILocation>Get()
        {
            var items = _repo.All();
            return items;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ILocation Get(int id)
        {
            return _repo.Single(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Location location)
        {
            _repo.Add(location);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]Location location)
        {
            _repo.Update(location);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        // POST api/values
        [HttpPost("~/home/{id}")]
        public void SetHome(int id)
        {
            _repo.SetProfile(id, true);
        }

        [HttpPost("~/work/{id}")]
        public void SetWork(int id)
        {
            _repo.SetProfile(id, false);
        }
    }
}
