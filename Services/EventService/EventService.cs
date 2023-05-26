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

        public async Task<ServiceResponse<List<GetEventDto>>> DeleteEvent(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetEventDto>>();
            try{
            var eve = events.FirstOrDefault(c => c.Id == id);
            if(eve is null)
                throw new Exception($"Event With Id '{id}' Not Found.");

            events.Remove(eve);
            
            serviceResponse.Data = events.Select(c => _mapper.Map<GetEventDto>(c)).ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
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

        public async Task<ServiceResponse<GetEventDto>> UpdateEvent(UpdateEventDto updateEvent)
        {
            var serviceResponse = new ServiceResponse<GetEventDto>();
            try{
            var eve = events.FirstOrDefault(c => c.Id == updateEvent.Id);
            if(eve is null)
                throw new Exception($"Event With Id '{updateEvent.Id}' Not Found.");

            eve.Name = updateEvent.Name;
            eve.Tagline = updateEvent.Tagline;
            eve.Schedule = updateEvent.Schedule;
            eve.Description = updateEvent.Description;
            eve.Image = updateEvent.Image;
            eve.Moderator = updateEvent.Moderator;
            eve.Category = updateEvent.Category;
            eve.SubCategory = updateEvent.SubCategory;
            eve.RigorRank = updateEvent.RigorRank;
            eve.Attendees = updateEvent.Attendees;
            
            serviceResponse.Data = _mapper.Map<GetEventDto>(eve);
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
} 