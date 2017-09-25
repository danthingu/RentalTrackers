using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentalTrackers.Models;

namespace RentalTrackers.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public Manga Manga { get; set; }
        public List<Customer> Customers { get; set; }
    }
}