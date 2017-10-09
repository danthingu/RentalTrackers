using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using RentalTrackers.Dtos;
using RentalTrackers.Models;

namespace RentalTrackers.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MembershipTypeDto, MembershipType>();
            Mapper.CreateMap<MovieDto, Movie>();
            Mapper.CreateMap<GenreDto, Genre>();

            // Dto to Domain
            //Mapper.CreateMap<CustomerDto, Customer>()
            //    .ForMember(c => c.Id, opt => opt.Ignore());

            //Mapper.CreateMap<MembershipTypeDto, MembershipType>()
            //    .ForMember(c => c.Id, opt => opt.Ignore());

            //Mapper.CreateMap<MovieDto, Movie>()
            //    .ForMember(c => c.Id, opt => opt.Ignore());

            //Mapper.CreateMap<GenreDto, Genre>()
            //    .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}