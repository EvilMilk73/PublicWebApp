using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.CustomerDtos;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services.CustomerService;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;


       public CustomerController(ICustomerService service) 
        {
            _service = service;
        }

        [HttpPost("AddCustomer")]
        public async Task<ActionResult<List<GetCustomerDto>>> AddCustomer (AddCustomerDto customer)
        {         
            return Ok(await _service.AddCustumer(customer));
        }

        [HttpGet]
        public async Task<ActionResult<List<GetCustomerDto>>> GetAllCustomers([FromQuery]CustomerQuery query)
        {
         
            return Ok(await _service.GetAllCustomers(query));
        }

        [HttpGet("{id}")]
        public ActionResult<GetCustomerDto> GetCustomerById(int id)
        {
            return Ok(_service.GetCustomerById(id));
        }

        [HttpPost("Delete{id}")]
        public async Task<ActionResult<List<GetCustomerDto>>> DeleteCustomer(int id)
        {
            try
            { 
            return Ok(await _service.DeleteCustomer(id));  
            } 
            catch(Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }

        [HttpPost("Update{id}")]
        public async Task<ActionResult<List<GetCustomerDto>>> UpdateCustomer(int id, AddCustomerDto customer)
        {
            return Ok(await _service.UpdateCustomer(id, customer));
        }
    }
}
