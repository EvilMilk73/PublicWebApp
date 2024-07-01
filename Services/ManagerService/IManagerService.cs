using WebApi.DTOs.ManagerDto;
using WebApi.Models;

namespace WebApi.Services.ManagerService
{
    public interface IManagerService
    {
        Task<List<GetManagerDto>> GetAllManagers();
        GetManagerDto GetManagerById(int id);
        Task<List<GetManagerDto>> AddManager(AddManagerDto manager);
        Task<List<GetManagerDto>> UpdateManager(int id, AddManagerDto manager);
        Task<List<GetManagerDto>> DeleteManager(int id);
    }
}
