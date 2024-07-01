using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApi.DTOs.CustomerDtos;
using WebApi.Models;
using System;
using WebApi.Helpers;

namespace WebApi.Services.CustomerService
{

    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CustomerService(DataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetCustomerDto>> AddCustumer(DTOs.CustomerDtos.AddCustomerDto customer)
        {
            _context.Customers.Add(_mapper.Map<Customer>(customer));
            _context.SaveChanges();
            return await GetCustomerDtoList();
        }

        public async Task<List<GetCustomerDto>> DeleteCustomer(int id)
        {
            List<Customer> customers = _context.Customers.ToList();
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if(customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return await GetCustomerDtoList();
            }
            throw new Exception("Customer with id:"+id+"not found");
        }

        public async Task<List<GetCustomerDto>> GetAllCustomers(CustomerQuery query)
        {
             IQueryable<Customer> queryable = _context.Customers.AsQueryable();
            if (!string.IsNullOrEmpty(query.SearchQuery))
            {
                queryable = queryable.Where(c =>
                    c.Name.Contains(query.SearchQuery));
                 
            }
             
          
          //pagination

            var customersList = await queryable.ToListAsync();
            return _mapper.Map<List<GetCustomerDto>>(customersList);
            //return await GetCustomerDtoList();
        }

        public GetCustomerDto GetCustomerById(int id)
        {
            List<Customer> customers = _context.Customers.ToList();
            Customer customer = customers.FirstOrDefault(c => c.Id == id);

            if(customer != null)
            {
                return _mapper.Map<GetCustomerDto>(customer);
            }
            throw new Exception("Customer with id:" + id + "not found");
        }

        public async Task<List<GetCustomerDto>> UpdateCustomer(int id, DTOs.CustomerDtos.AddCustomerDto customer)
        {
            List<Customer> customers = _context.Customers.ToList();
            Customer updateCustomer = customers.Where(c => c.Id == id).FirstOrDefault();
            
            if(updateCustomer != null)
            {
                _context.Entry(updateCustomer).CurrentValues.SetValues(customer);
                _context.SaveChanges();
                return await GetCustomerDtoList();
            }
            throw new Exception("Customer with id:" + id + "not found");
        }
        private async Task<List<GetCustomerDto>> GetCustomerDtoList()
        {
            var customers = await _context.Customers.Include(c=> c.Waypoints).ToListAsync();
            return _mapper.Map<List<GetCustomerDto>>(customers);
        }
    }
}
