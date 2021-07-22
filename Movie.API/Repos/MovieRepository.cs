using Microsoft.EntityFrameworkCore;
using Movie.API.Models_Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.API.Repos {
    public class MovieRepository : IMoviesRepo {
        private readonly MovieDbContext _movieDbContext;

        public MovieRepository(Models_Data.MovieDbContext movieDbContext) {
            _movieDbContext = movieDbContext;
        }

        public async Task<int> Add(Models_Data.Movie movie) {
            var res = await _movieDbContext.Movies.AddAsync(movie);
            _movieDbContext.SaveChanges();
            return res.Entity.Id;
        }

        public async Task<IEnumerable<Models_Data.Movie>> GetAll() {
            return await _movieDbContext.Movies.ToListAsync();
        }

        public async Task<Models_Data.Movie> GetById(int id) {
            return await _movieDbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
