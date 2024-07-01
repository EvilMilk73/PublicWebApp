
using WebApi.DTOs.CargoDtos;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Services.CargoService
{
    public interface ICargoService
    {
        Task<List<GetCargoDto>> GetAllCargoes(CargoQuery query);
        GetCargoDto GetCargoById(int id);
        Task<List<GetCargoDto>> AddCargo(AddCargoDto cargo);
        Task<List<GetCargoDto>> UpdateCargo(int id, AddCargoDto cargo);
        Task<List<GetCargoDto>> DeleteCargo(int id);
    }
}
