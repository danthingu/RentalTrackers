using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentalTrackers.Models;

namespace RentalTrackers.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public string Title { get; set; }
    }
}