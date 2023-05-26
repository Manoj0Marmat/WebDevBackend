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
        //dummy data
        private static List<Event> events = new List<Event>{
            new Event
            {
                Id = 1,
                Name = "Event 1",
                Tagline = "Join us for Event 1",
                Schedule = DateTime.Now.AddDays(1),
                Description = "This is Event 1 description",
                Image = null,
                Moderator = "John Doe",
                Category = EventCategoryClass.EventCategoryOne,
                SubCategory = EventSubCategoryClass.EventSubCategoryThree,
                RigorRank = 3,
                Attendees = new int[] { 123, 456, 789 }
            },
            new Event
            {   
                Id = 2,
                Name = "Event 2",
                Tagline = "Join us for Event 2",
                Schedule = DateTime.Now.AddDays(2),
                Description = "This is Event 2 description",
                Image = null,
                Moderator = "Jane Smith",
                Category = EventCategoryClass.EventCategoryTwo,
                SubCategory = EventSubCategoryClass.EventSubCategoryTwo,
                RigorRank = 2,
                Attendees = new int[] { 456, 789 }
            },
            new Event
            {
                Id = 3,
                Name = "Event 3",
                Tagline = "Tagline 3",
                Schedule = DateTime.Now.AddDays(2),
                Description = "Description 3",
                Image = null,
                Moderator = "Moderator 3",
                Category = EventCategoryClass.EventCategoryTwo,
                SubCategory = EventSubCategoryClass.EventSubCategoryTwo,
                RigorRank = 3,
                Attendees = new int[] { 7, 8, 9 }
            },
            new Event
            {
                Id = 4,
                Name = "Event 4",
                Tagline = "Tagline 4",
                Schedule = DateTime.Now.AddDays(3),
                Description = "Description 4",
                Image = null,
                Moderator = "Moderator 4",
                Category = EventCategoryClass.EventCategoryTwo,
                SubCategory = EventSubCategoryClass.EventSubCategoryTwo,
                RigorRank = 4,
                Attendees = new int[] { 10, 11, 12 }
            },
            new Event
            {
                Id = 5,
                Name = "Event 5",
                Tagline = "Tagline 5",
                Schedule = DateTime.Now.AddDays(4),
                Description = "Description 5",
                Image = null,
                Moderator = "Moderator 5",
                Category = EventCategoryClass.EventCategoryOne,
                SubCategory = EventSubCategoryClass.EventSubCategoryTwo,
                RigorRank = 5,
                Attendees = new int[] { 13, 14, 15 }
            },
            new Event
            {
                Id = 6,
                Name = "Event 6",
                Tagline = "Tagline 6",
                Schedule = DateTime.Now.AddDays(5),
                Description = "Description 6",
                Image = null,
                Moderator = "Moderator 6",
                Category = EventCategoryClass.EventCategoryTwo,
                SubCategory = EventSubCategoryClass.EventSubCategoryTwo,
                RigorRank = 6,
                Attendees = new int[] { 16, 17, 18 }
            },
            new Event
            {
                Id = 7,
                Name = "Event 7",
                Tagline = "Tagline 7",
                Schedule = DateTime.Now.AddDays(6),
                Description = "Description 7",
                Image = null,
                Moderator = "Moderator 7",
                Category = EventCategoryClass.EventCategoryThree,
                SubCategory = EventSubCategoryClass.EventSubCategoryTwo,
                RigorRank = 7,
                Attendees = new int[] { 19, 20, 21 }
            }

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
            if (events.Any())
                eve.Id = events.Max(c => c.Id) + 1;
            else
                eve.Id = 1;
            events.Add(eve);
            serviceResponse.Data = events.Select(c => _mapper.Map<GetEventDto>(c)).ToList();
            return await Task.FromResult(serviceResponse);
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
            return await Task.FromResult(serviceResponse);
        }

        public async Task<ServiceResponse<List<GetEventDto>>> GetAllEvent()
        {
            var serviceResponse = new ServiceResponse<List<GetEventDto>>();
            serviceResponse.Data = events.Select(c => _mapper.Map<GetEventDto>(c)).ToList();
            return await Task.FromResult(serviceResponse);
        }

        public async Task<ServiceResponse<GetEventDto>> GetEventById(int id)
        {
            var serviceResponse = new ServiceResponse<GetEventDto>();
            var eve = events.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetEventDto>(eve);
            return await Task.FromResult(serviceResponse);
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
            return await Task.FromResult(serviceResponse);
        }
    }
} 