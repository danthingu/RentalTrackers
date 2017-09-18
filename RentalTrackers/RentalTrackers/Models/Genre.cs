using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace RentalTrackers.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

    }
}