using WebApi.Models;
using System.Threading.Tasks;
using WebApi.DTOs.DriverDtos;
namespace WebApi.Services.DriverService
{
    public interface IDriverService
    {
        Task<List<GetDriverDto>> GetAllDrivers();
        Driver GetDriverById(int id);
        Task<List<GetDriverDto>> AddDriver(AddDriverDto driver);
        Task<List<GetDriverDto>> UpdateDriver(int id, AddDriverDto driver);
        Task<List<GetDriverDto>> DeleteDriver(int id);
    }
}
