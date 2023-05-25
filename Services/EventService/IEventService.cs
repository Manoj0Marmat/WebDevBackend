using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDevBackend.Models;

namespace WebDevBackend.Services.EventService
{
    public interface IEventService
    {
        Task<ServiceResponse<List<Event>>> GetAllEvents();
        Task<ServiceResponse<Event>> GetById(int id);
        Task<ServiceResponse<List<Event>>> AddEvent(Event newEvent);
    }
}