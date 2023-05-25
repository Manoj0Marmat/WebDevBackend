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
        public async Task<List<Event>> AddEvent(Event newEvent)
        {
            events.Add(newEvent);
            return events;
        }

        public async Task<List<Event>> GetAllEvents()
        {
            return events;
        }

        public async Task<Event> GetById(int id)
        {
            var e = events.FirstOrDefault(c => c.Id == id);
            if(e is not null)
                return e;
            
            throw new Exception("Event Not Found");
        }
    }
}