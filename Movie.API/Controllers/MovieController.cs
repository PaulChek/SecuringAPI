using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase {
        private readonly IMediator _mediatorMovies;

        public MovieController(IMediator mediatorMovies) {
            _mediatorMovies = mediatorMovies;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models_Data.Movie>>> GetAsync() {
            var res = (await _mediatorMovies.Send(new Requests.GetAllMovies.Query())).Movies;
            return Ok(res);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Models_Data.Movie>> GetAsync(int id) {
            var res = (await _mediatorMovies.Send(new Requests.GetMovieById.Query(id))).Movie;
            return res == null ? NotFound() : Ok(res);
        }
        [HttpPost]
        [Authorize(Policy = "ClientPolicy")]
        public async Task<ActionResult<int>> Post(Models_Data.Movie movie) {
            var res = (await _mediatorMovies.Send(new Requests.AddNewMovie.Command(movie))).Id;
            return Ok(res);
        }
    }
}
