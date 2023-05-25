using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebDevBackend.Dtos.Event;
using WebDevBackend.Models;

namespace WebDevBackend.Services.EventService
{
    public class EventService : IEventService
    {
        private static List<Event> events = new List<Event>{
            new Event(),
            new Event{Id = 1}
        };
        private readonly IMapper _mapper;

        public EventService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetEventDto>>> AddEvent(AddEventDto newEvent)
        {
            var serviceResponse = new ServiceResponse<List<GetEventDto>>();
            var eve = _mapper.Map<Event>(newEvent);
            eve.Id = events.Max(c => c.Id) + 1;
            events.Add(eve);
            serviceResponse.Data = events.Select(c => _mapper.Map<GetEventDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetEventDto>>> GetAllEvent()
        {
            var serviceResponse = new ServiceResponse<List<GetEventDto>>();
            serviceResponse.Data = events.Select(c => _mapper.Map<GetEventDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetEventDto>> GetEventById(int id)
        {
            var serviceResponse = new ServiceResponse<GetEventDto>();
            var eve = events.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetEventDto>(eve);
            return serviceResponse;
        }
    }
}