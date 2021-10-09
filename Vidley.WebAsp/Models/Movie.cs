using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vidley.WebAsp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Release date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name="Number In Stock")]
        public int NumberInStock { get; set; }

        public Genre Genre { get; set; }

        [Display(Name="Genre")]
        public byte GenreId { get; set; }
    }

}