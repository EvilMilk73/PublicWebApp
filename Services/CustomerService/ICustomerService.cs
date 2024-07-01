using WebApi.DTOs.CustomerDtos;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Services.CustomerService
{
    public interface ICustomerService
    {
         Task<List<GetCustomerDto>> GetAllCustomers(CustomerQuery query);
         GetCustomerDto GetCustomerById(int id);
         Task<List<GetCustomerDto>> AddCustumer(AddCustomerDto customer);
         Task<List<GetCustomerDto>> UpdateCustomer(int id, AddCustomerDto customer);
         Task<List<GetCustomerDto>> DeleteCustomer(int id);
    }
}
