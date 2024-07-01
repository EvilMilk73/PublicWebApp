using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DTOs.DriverDtos;
using WebApi.DTOs.VehicleDto;
using WebApi.Models;

namespace WebApi.Services.VehicleService
{
    public class VehicleService : IVehicleService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public VehicleService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetVehicleDto>> AddVehicle(AddVehicleDto vehicle)
        {
            _context.Vehicles.Add(_mapper.Map<Vehicle>(vehicle));
            _context.SaveChanges();
            return await GetVehicleDtoList();
        }

        public async Task<List<GetVehicleDto>> DeleteVehicle(int id)
        {
            List<Vehicle> vehicles = _context.Vehicles.ToList();
            Vehicle vehicle = vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();
                return await GetVehicleDtoList();
            }
            throw new Exception("Vehicle with id:" + id + " not found");
        }

        public async Task<List<GetVehicleDto>> GetAllVehicles()
        {
            return await GetVehicleDtoList();
        }

        public GetVehicleDto GetVehicleById(int id)
        {
            List<Vehicle> vehicles = _context.Vehicles.ToList();
            Vehicle vehicle = vehicles.FirstOrDefault(v => v.Id == id);

            if (vehicle != null)
            {
                return _mapper.Map<GetVehicleDto>(vehicle);
            }
            throw new Exception("Vehicle with id:" + id + " not found");
        }

        public async Task<List<GetVehicleDto>> UpdateVehicle(int id, AddVehicleDto vehicle)
        {
            List<Vehicle> vehicles = _context.Vehicles.ToList();
            Vehicle updateVehicle = vehicles.Where(v => v.Id == id).FirstOrDefault();

            if (updateVehicle != null)
            {
                _context.Entry(updateVehicle).CurrentValues.SetValues(vehicle);
                _context.SaveChanges();
                return await GetVehicleDtoList();
            }
            throw new Exception("Vehicle with id:" + id + " not found");
        }
        private async Task<List<GetVehicleDto>> GetVehicleDtoList()
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            return _mapper.Map<List<GetVehicleDto>>(vehicles);
        }
    }

}
