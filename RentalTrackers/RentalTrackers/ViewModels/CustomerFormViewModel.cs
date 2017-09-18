using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentalTrackers.Models;

namespace RentalTrackers.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Manga Mangas { get; set; }
    }
}