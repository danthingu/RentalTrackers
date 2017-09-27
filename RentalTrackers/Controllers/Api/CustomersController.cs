using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers
                .Include(_ => _.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomers(int id)
        {
            var customer = _context.Customers.Single(_ => _.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
                _context.Customers.Add(customer);
                try
                {
                    _context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Console.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }
                customerDto.Id = customer.Id;
                return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
            }
            else
            {
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
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
                if (selectedCustomer == null) throw new HttpResponseException(HttpStatusCode.NotFound);

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
