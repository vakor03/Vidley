using System.Collections.Generic;
using Vidley.WebAsp.Models;

namespace Vidley.WebAsp.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}