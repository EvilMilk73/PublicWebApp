using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using System.Linq;
using System.Linq.Dynamic.Core;
using AutoMapper;
using WebApi.Services.CargoService;
using WebApi.DTOs.CargoDtos;
using WebApi.Helpers;

namespace WebApi.Services.CargoService
{
    public class CargoService : ICargoService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CargoService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetCargoDto>> AddCargo(AddCargoDto addCargoDto)
        {
            var cargo = _mapper.Map<Cargo>(addCargoDto);
            _context.Cargoes.Add(cargo);
            _context.SaveChanges();
            return await GetCargoDtoList();
        }

        public async Task<List<GetCargoDto>> DeleteCargo(int id)
        {
            var cargo = _context.Cargoes.FirstOrDefault(c => c.Id == id);
            if (cargo != null)
            {
                _context.Cargoes.Remove(cargo);
                _context.SaveChanges();
                return await GetCargoDtoList();
            }
            throw new Exception($"Cargo with id: {id} not found");
        }

        public async Task<List<GetCargoDto>> GetAllCargoes(CargoQuery query)
        {
            IQueryable<Cargo> queryable = _context.Cargoes.AsQueryable();
            if (!string.IsNullOrEmpty(query.SearchQuery))
            {
                queryable = queryable.Where(c =>
                    c.Waypoint.Customer.Name.Contains(query.SearchQuery) ||
                    c.Waypoint.Name.Contains(query.SearchQuery));
            }
             queryable = queryable
                .Include(c => c.Waypoint)
                    .ThenInclude(waypoint => waypoint.Customer)
                .OrderBy(query.OrderBy + " " + query.OrderDirection)
                .AsQueryable();
          
            /*if(query.Paginate)
            {
                queryable = queryable.Skip(query.PageNumber * query.PageSize).Take(query.PageSize);
            }*/

            var cargosList = await queryable.ToListAsync();
            return _mapper.Map<List<GetCargoDto>>(cargosList);
        }

        public GetCargoDto GetCargoById(int id)
        {
            var cargo = _context.Cargoes.FirstOrDefault(c => c.Id == id);
            if (cargo != null)
            {
                return _mapper.Map<GetCargoDto>(cargo);
            }
            throw new Exception($"Cargo with id: {id} not found");
        }

        public Task<List<GetCargoDto>> UpdateCargo(int id, AddCargoDto addCargoDto)
        {
            var updateCargo = _context.Cargoes.FirstOrDefault(c => c.Id == id);         
            if (updateCargo != null)
            {
                _context.Entry(updateCargo).CurrentValues.SetValues(addCargoDto);
                _context.SaveChanges();
                return GetCargoDtoList();
            }

            throw new Exception($"Cargo with id: {id} not found");
        }

        private async Task<List<GetCargoDto>> GetCargoDtoList()
        {
            var cargos = await _context.Cargoes
                .Include(c=> c.Waypoint)
                    .ThenInclude(waypoint => waypoint.Customer)
                    .ThenInclude(customer => customer.Waypoints)
                .ToListAsync();
            return _mapper.Map<List<GetCargoDto>>(cargos);
        }
    }


}
