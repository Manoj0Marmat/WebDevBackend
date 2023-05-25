using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebDevBackend.Dtos.Event;
using WebDevBackend.Models;

namespace WebDevBackend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Event, GetEventDto>();
            CreateMap<AddEventDto, Event>();
        }
    }
}