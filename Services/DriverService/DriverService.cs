using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DTOs.CustomerDtos;
using WebApi.DTOs.DriverDtos;
using WebApi.Models;

namespace WebApi.Services.DriverService
{
    public class DriverService : IDriverService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DriverService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetDriverDto>> AddDriver(AddDriverDto driver)
        {
            _context.Drivers.Add(_mapper.Map<Driver>(driver));
            _context.SaveChanges();
            return await GetDrvierDtoList();
        }

        public async Task<List<GetDriverDto>> DeleteDriver(int id)
        {
            List<Driver> drivers = _context.Drivers.ToList();
            Driver driver = drivers.FirstOrDefault(d => d.Id == id);
            if (driver != null)
            {
                _context.Drivers.Remove(driver);
                _context.SaveChanges();
                return await GetDrvierDtoList();
            }
            throw new Exception("Driver with id:" + id + " not found");
        }

        public async Task<List<GetDriverDto>> GetAllDrivers()
        {
            return await GetDrvierDtoList();
        }

        public Driver GetDriverById(int id)
        {
            List<Driver> drivers = _context.Drivers.ToList();
            Driver driver = drivers.FirstOrDefault(d => d.Id == id);

            if (driver != null)
            {
                return driver;
            }
            throw new Exception("Driver with id:" + id + " not found");
        }

        public async Task<List<GetDriverDto>> UpdateDriver(int id, AddDriverDto driver)
        {
            List<Driver> drivers = _context.Drivers.ToList();
            Driver updateDriver = drivers.Where(d => d.Id == id).FirstOrDefault();

            if (updateDriver != null)
            {              
                _context.Entry(updateDriver).CurrentValues.SetValues(driver);
                _context.SaveChanges();
                return await GetDrvierDtoList();
            }
            throw new Exception("Driver with id:" + id + " not found");
        }

        private async Task<List<GetDriverDto>> GetDrvierDtoList()
        {
            var drivers = await _context.Drivers.ToListAsync();
            return _mapper.Map<List<GetDriverDto>>(drivers);
        }
    }
    
}
