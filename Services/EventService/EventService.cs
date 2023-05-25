using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDevBackend.Models;

namespace WebDevBackend.Services.EventService
{
    public class EventService : IEventService
    {
        private static List<Event> events = new List<Event>{
            new Event(),
            new Event{Id = 1}
        };
        public async Task<ServiceResponse<List<Event>>> AddEvent(Event newEvent)
        {
            var serviceResponse = new ServiceResponse<List<Event>>();
            events.Add(newEvent);
            serviceResponse.Data = events;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Event>>> GetAllEvents()
        {
            var serviceResponse = new ServiceResponse<List<Event>>();
            serviceResponse.Data = events;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Event>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<Event>();
            var e = events.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = e;
            return serviceResponse;
        }
    }
}