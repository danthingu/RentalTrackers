using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RentalTrackers.Dtos;
using RentalTrackers.Models;
using AutoMapper;

namespace RentalTrackers.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        // GET /api/customers/1
        public CustomerDto GetCustomers(int id)
        {
            var customer = _context.Customers.Single(_=>_.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        // POST /api/customers
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto) 
        {
            if (ModelState.IsValid)
            {
                var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
                _context.Customers.Add(customer);
                _context.SaveChanges();
                customerDto.Id = customer.Id;
                return customerDto;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        // PUT /api/customers
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                var selectedCustomer = _context.Customers.Single(_ => _.Id == id);
                if (selectedCustomer == null) throw new HttpResponseException(HttpStatusCode.NotFound);

                Mapper.Map<CustomerDto, Customer>(customerDto, selectedCustomer);
            
                _context.SaveChanges();
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
        
        // DELETE /api/customers
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            if (ModelState.IsValid)
            {
                var selectedCustomer = _context.Customers.Single(_ => _.Id == id);
                if (selectedCustomer == null)   throw new HttpResponseException(HttpStatusCode.NotFound);

                _context.Customers.Remove(selectedCustomer);
                _context.SaveChanges();
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }
}
