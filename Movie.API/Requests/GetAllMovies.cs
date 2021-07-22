using MediatR;
using Movie.API.Repos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Movie.API.Requests {
    public static class GetAllMovies {
        public record Query() : IRequest<Response>;
        public record Response(IEnumerable<Models_Data.Movie> Movies);

        public class Handler : IRequestHandler<Query, Response> {
            private readonly IMoviesRepo _moviesRepo;

            public Handler(Repos.IMoviesRepo moviesRepo) {
                _moviesRepo = moviesRepo;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken) {
                return new Response(await _moviesRepo.GetAll());
            }
        }
    }
}
