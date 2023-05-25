using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDevBackend.Dtos.Event;
using WebDevBackend.Models;

namespace WebDevBackend.Controllers
{
    [ApiController]
    [Route("api/v3/app/events")]
    public class EventController : ControllerBase
    {
        private static List<Event> events = new List<Event>{
            new Event(),
            new Event{Id = 1}
        };

        [HttpGet("{id}")]
        public IActionResult GetEventById(int id)
        {
            return Ok(events.FirstOrDefault(c => c.Id == id));
        }

        [HttpGet]
        public IActionResult GetLatestEvents(string type, int limit, int page)
        {
            return Ok(events);
        }

        [HttpPost]
        public ActionResult<List<Event>> AddEvent([FromForm]Event newEvent)
        {
            events.Add(newEvent);
            return Ok(events);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvent(UpdateEventDto updateEventDto)
        {
            return Ok($"Event with ID: {updateEventDto.Id} updated successfully");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            return Ok($"Event with ID: {id} deleted successfully");
        }
    }
}