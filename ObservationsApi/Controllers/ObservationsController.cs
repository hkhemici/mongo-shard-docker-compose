using ObservationsApi.Models;
using ObservationsApi.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ObservationsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservationsController : ControllerBase
    {
        private readonly ObservationService _observationService;

        public ObservationsController(ObservationService observationService)
        {
            _observationService = observationService;
        }

        // GET api/observations
        [HttpGet]
        public ActionResult<List<Observation>> Get() =>
            _observationService.Get();

        // GET api/observations/5
        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Observation> Get(string id)
        {
            var observation = _observationService.Get(id);

            if (observation == null)
            {
                return NotFound();
            }

            return observation;
        }

        // POST api/observations
        [HttpPost]
        public ActionResult<Observation> Create(Observation observation)
        {
            _observationService.Create(observation);

            return CreatedAtRoute("GetBook", new { id = observation.Id.ToString() }, observation);
        }

        // PUT api/observations/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Observation observationIn)
        {
            var observation = _observationService.Get(id);

            if (observation == null)
            {
                return NotFound();
            }

            _observationService.Update(id, observationIn);

            return NoContent();
        }

        // DELETE api/observations/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var observation = _observationService.Get(id);

            if (observation == null)
            {
                return NotFound();
            }

            _observationService.Remove(observation.Id);

            return NoContent();
        }
    }
}
