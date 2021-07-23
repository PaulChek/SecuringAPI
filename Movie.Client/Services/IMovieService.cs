using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.Client.Services {
    public interface IMovieService {
        Task<IEnumerable<Models.MovieModel>> GetAllMoviesAsync();
        Task<Models.MovieModel> GetById(int id);
        Task Add(Models.MovieModel movie);
    }
}
