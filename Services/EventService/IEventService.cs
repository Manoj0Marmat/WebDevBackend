using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDevBackend.Dtos.Event;
using WebDevBackend.Models;

namespace WebDevBackend.Services.EventService
{
    public interface IEventService
    {
        Task<ServiceResponse<List<GetEventDto>>> GetAllEvent();
        Task<ServiceResponse<GetEventDto>> GetEventById(int id);
        Task<ServiceResponse<List<GetEventDto>>> AddEvent(AddEventDto newEvent);
        Task<ServiceResponse<GetEventDto>> UpdateEvent(UpdateEventDto updateEvent);
        Task<ServiceResponse<List<GetEventDto>>> DeleteEvent(int id);
    }
}