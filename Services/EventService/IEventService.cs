using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDevBackend.Models;

namespace WebDevBackend.Services.EventService
{
    public interface IEventService
    {
        Task<List<Event>> GetAllEvents();
        Task<Event> GetById(int id);
        Task<List<Event>> AddEvent(Event newEvent);
    }
}