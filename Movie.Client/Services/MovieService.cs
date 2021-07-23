using Movie.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Movie.Client.Services {
    public class MovieService : IMovieService {
        private readonly HttpClient _client;

        public MovieService(HttpClient client) {
            _client = client;
        }

        public Task Add(MovieModel movie) {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MovieModel>> GetAllMoviesAsync() {
          return await _client.GetFromJsonAsync<IEnumerable<MovieModel>>("Movie");
        }

        public Task<MovieModel> GetById(int id) {
            throw new NotImplementedException();
        }
    }
}
