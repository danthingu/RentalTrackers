using RentalTrackers.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using RentalTrackers.Dtos;

namespace RentalTrackers.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
       
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }
        [HttpPost]
        public IHttpActionResult GetMovies(NewRentalDto rentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = _context.Customers.Single(_ => _.Id == rentalDto.CustomerId);
            var movies = _context.Movies.Where(_ => rentalDto.MovieIds.Contains(_.Id));
            foreach (var movie in movies)
            {
                movie.NumberAvailable--;
                var newRental = new NewRental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.NewRentals.Add(newRental);
            }
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
            //rentalDto.CustomerId = rental.CustomerId;
            //return Created(new Uri(Request.RequestUri + "/" + rental.CustomerId), rentalDto);
            return Ok();
        }
    }
}
