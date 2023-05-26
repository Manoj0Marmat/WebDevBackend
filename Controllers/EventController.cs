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
        public async Task<ActionResult<ServiceResponse<GetEventDto>>> GetSingle(int id)
        {
            return Ok(await _eventService.GetEventById(id));
        }

        [HttpGet]
        // public async Task<ActionResult<ServiceResponse<List<Event>>>> GetLatestEvents(string type, int limit=1, int page=1)
        public async Task<ActionResult<ServiceResponse<List<GetEventDto>>>> GetLatestEvents()
        {
            return Ok(await _eventService.GetAllEvent());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetEventDto>>>> AddEvent([FromForm]AddEventDto newEvent)
        {
            return Ok(await _eventService.AddEvent(newEvent));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetEventDto>>>> UpdateEvent([FromForm]UpdateEventDto updateEvent)
        {
            var res = await _eventService.UpdateEvent(updateEvent);
            
            if(res.Data is null)
                return NotFound(res);

            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetEventDto>>> DeleteEvent(int id)
        {
            var res = await _eventService.DeleteEvent(id);
            
            if(res.Data is null)
                return NotFound(res);

            return Ok(res);
        }
    }
}