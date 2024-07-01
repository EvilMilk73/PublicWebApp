using WebApi.DTOs.VehicleDto;
using WebApi.Models;

namespace WebApi.Services.VehicleService
{
    public interface IVehicleService
    {
        Task<List<GetVehicleDto>> GetAllVehicles();
        GetVehicleDto GetVehicleById(int id);
        Task<List<GetVehicleDto>> AddVehicle(AddVehicleDto vehicle);
        Task<List<GetVehicleDto>> UpdateVehicle(int id, AddVehicleDto vehicle);
        Task<List<GetVehicleDto>> DeleteVehicle(int id);
    }
}
