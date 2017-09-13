using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace RentalTrackers.Models
{
    public class MovieInfo
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Genre { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public int NumberInStock { get; set; }

}
}