
using System.ComponentModel.DataAnnotations;
using System.Web.Razor;

namespace RentalTrackers.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public MovieInfo MovieInfo { get; set; }
        public byte MovieInfoId { get; set; }
    }
}