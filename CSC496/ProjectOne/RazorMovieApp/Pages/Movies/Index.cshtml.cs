using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorMovieApp.Models;

namespace RazorMovieApp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorMovieApp.Models.RazorMovieAppContext _context;

        public IndexModel(RazorMovieApp.Models.RazorMovieAppContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
