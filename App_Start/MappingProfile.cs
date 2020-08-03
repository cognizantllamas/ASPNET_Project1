using AutoMapper;
using Project1.Dtos;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
        }
        
    }
}