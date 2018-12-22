using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }


        public async Task OnGetAsync()
        {
            var movies = from m in _context.Movie select m;
            //Uasage of LINQ to get list of Genres
            IQueryable<string> genreQuery = from m in _context.Movie orderby m.Genre select m.Genre;

            if (!String.IsNullOrEmpty(SearchString)) {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            //Updating OnGetAsync to trigger search by Genre
            if (!String.IsNullOrEmpty(MovieGenre)) {
                movies = movies.Where(x => x.Genre == MovieGenre);

            }

            //Query for Searching by Genre
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
