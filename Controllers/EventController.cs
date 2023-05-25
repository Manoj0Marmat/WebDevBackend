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
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEventById(int id)
        {
            return Ok(await _eventService.GetById(id));
        }

        [HttpGet]
        public async Task<ActionResult> GetLatestEvents(string type, int limit, int page)
        {
            return Ok(await _eventService.GetAllEvents());
        }

        [HttpPost]
        public async Task<ActionResult<List<Event>>> AddEvent([FromForm]Event newEvent)
        {
            return Ok(await _eventService.AddEvent(newEvent));
        }

        // [HttpPut("{id}")]
        // public IActionResult UpdateEvent(UpdateEventDto updateEventDto)
        // {
        //     return Ok($"Event with ID: {updateEventDto.Id} updated successfully");
        // }


        // [HttpDelete("{id}")]
        // public IActionResult DeleteEvent(int id)
        // {
        //     return Ok($"Event with ID: {id} deleted successfully");
        // }
    }
}