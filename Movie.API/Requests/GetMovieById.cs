using MediatR;
using Movie.API.Repos;
using System.Threading;
using System.Threading.Tasks;

namespace Movie.API.Requests {
    public static class GetMovieById {
        public record Query(int id) : IRequest<Response>;
        public record Response(Models_Data.Movie Movie);
        public class Handler : IRequestHandler<Query, Response> {
            private readonly IMoviesRepo _moviesRepo;

            public Handler(Repos.IMoviesRepo moviesRepo) {
                _moviesRepo = moviesRepo;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken) {
                return new Response(await _moviesRepo.GetById(request.id));
            }
        }

    }
}
