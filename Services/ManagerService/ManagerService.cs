using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DTOs.DriverDtos;
using WebApi.DTOs.ManagerDto;
using WebApi.Models;

namespace WebApi.Services.ManagerService
{
    public class ManagerService : IManagerService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ManagerService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetManagerDto>> AddManager(AddManagerDto manager)
        {
            _context.Managers.Add(_mapper.Map<Manager>(manager));
            _context.SaveChanges();
            return await GetMangerDtoList();
        }

        public async Task<List<GetManagerDto>> DeleteManager(int id)
        {
            List<Manager> managers = _context.Managers.ToList();
            Manager manager = managers.FirstOrDefault(m => m.Id == id);
            if (manager != null)
            {
                _context.Managers.Remove(manager);
                _context.SaveChanges();
                return await GetMangerDtoList();
            }
            throw new Exception("Manager with id:" + id + " not found");
        }

        public async Task<List<GetManagerDto>> GetAllManagers()
        {
             return await GetMangerDtoList();
        }

        public GetManagerDto GetManagerById(int id)
        {
            List<Manager> managers = _context.Managers.ToList();
            Manager manager = managers.FirstOrDefault(m => m.Id == id);

            if (manager != null)
            {
                return _mapper.Map<GetManagerDto>(manager);
            }
            throw new Exception("Manager with id:" + id + " not found");
        }

        public async Task<List<GetManagerDto>> UpdateManager(int id, AddManagerDto manager)
        {
            List<Manager> managers = _context.Managers.ToList();
            Manager updateManager = managers.Where(m => m.Id == id).FirstOrDefault();

            if (updateManager != null)
            {
                _context.Entry(updateManager).CurrentValues.SetValues(manager);
                _context.SaveChanges();
                return await GetMangerDtoList();
            }
            throw new Exception("Manager with id:" + id + " not found");
        }

        private async Task<List<GetManagerDto>> GetMangerDtoList()
        {
            var managers = await _context.Managers.ToListAsync();
            return _mapper.Map<List<GetManagerDto>>(managers);
        }
    }

}
