using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DTOs.VehicleDto;
using System.Linq.Dynamic.Core;
using WebApi.DTOs.WaypointDto;
using WebApi.Helpers;
using WebApi.Models;
using System.Collections;

namespace WebApi.Services.WaypointService
{
    public class WaypointService : IWaypointService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public WaypointService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetWaypointDto>> AddWaypoint(AddWaypointDto waypoint)
        {
            _context.Waypoints.Add(_mapper.Map<Waypoint>(waypoint));
            _context.SaveChanges();
            return await GetWaypointDtoList();
        }

        public async Task<List<GetWaypointDto>> DeleteWaypoint(int id)
        {
            List<Waypoint> waypoints = _context.Waypoints.ToList();
            Waypoint waypoint = waypoints.FirstOrDefault(w => w.Id == id);
            if (waypoint != null)
            {
                _context.Waypoints.Remove(waypoint);
                _context.SaveChanges();
                return await GetWaypointDtoList();
            }
            throw new Exception("Waypoint with id:" + id + " not found");
        }

        public async Task<List<GetWaypointDto>> GetAllWaypoints(WaypointQuery query)
        {
            IQueryable<Waypoint> queryable = _context.Waypoints.AsQueryable();
            if (!string.IsNullOrEmpty(query.SearchQuery))
            {
                // queryable = queryable.Where(c =>
                //     c.Waypoint.Customer.Name.Contains(query.SearchQuery) ||
                //     c.Waypoint.Name.Contains(query.SearchQuery));
            }
            if (!string.IsNullOrEmpty(query.CustomersIds))
            {
                List<int> Ids = query.CustomersIds.Split(',').Select(item =>  int.Parse(item)).ToList();

                
                queryable = queryable.Where(c => Ids.Contains(c.CustomerId.Value));
            }
             queryable = queryable
                .Include(w => w.Customer)
                .OrderBy(query.OrderBy + " " + query.OrderDirection)
                .AsQueryable();
          
            /*if(query.Paginate)
            {
                queryable = queryable.Skip(query.PageNumber * query.PageSize).Take(query.PageSize);
            }*/

            var cargosList = await queryable.ToListAsync();
            return _mapper.Map<List<GetWaypointDto>>(cargosList);


            //return await GetWaypointDtoList();
        }

        public GetWaypointDto GetWaypointById(int id)
        {
            List<Waypoint> waypoints = _context.Waypoints.ToList();
            Waypoint waypoint = waypoints.FirstOrDefault(w => w.Id == id);

            if (waypoint != null)
            {
                return _mapper.Map<GetWaypointDto>(waypoint);
            }
            throw new Exception("Waypoint with id:" + id + " not found");
        }

        public async Task<List<GetWaypointDto>> UpdateWaypoint(int id, AddWaypointDto waypoint)
        {
            
            Waypoint updateWaypoint = _context.Waypoints.Where(w => w.Id == id).FirstOrDefault();

            if (updateWaypoint != null)
            {
                _context.Entry(updateWaypoint).CurrentValues.SetValues(waypoint);
                _context.SaveChanges();
                return await GetWaypointDtoList();
            }
            throw new Exception("Waypoint with id:" + id + " not found");
        }
        private async Task<List<GetWaypointDto>> GetWaypointDtoList()
        {
            var waypoints = await _context.Waypoints
                .Include(c=> c.Customer)
                .Include(c => c.Cargos)
                .ToListAsync();
            return _mapper.Map<List<GetWaypointDto>>(waypoints);
        }
    }

}
