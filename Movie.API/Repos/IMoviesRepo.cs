using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.API.Repos {
    public interface IMoviesRepo {
        Task<IEnumerable<Models_Data.Movie>> GetAll();
        Task<Models_Data.Movie> GetById(int id);
        Task<int> Add(Models_Data.Movie movie);
    }
}
