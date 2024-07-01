using AutoMapper;
using WebApi.DTOs.CargoDtos;
using WebApi.DTOs.CustomerDtos;
using WebApi.DTOs.WaypointDto;
using WebApi.Models;

namespace WebApi
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddCargoDto, Cargo>(); 
            CreateMap<Cargo, GetCargoDto > ();

            CreateMap<AddCustomerDto, Customer>();
            CreateMap<Customer, GetCustomerDto>();

            CreateMap<AddWaypointDto, Waypoint>();
            CreateMap<Waypoint, GetWaypointDto>();
        }
    }
}
