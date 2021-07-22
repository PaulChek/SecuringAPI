using MediatR;
using Movie.API.Repos;
using System.Threading;
using System.Threading.Tasks;

namespace Movie.API.Requests {
    public static class AddNewMovie {
        public record Command(Models_Data.Movie Movie) : IRequest<Response>;
        public record Response(int Id);
        public class Handler : IRequestHandler<Command, Response> {
            private readonly IMoviesRepo _moviesRepo;

            public Handler(Repos.IMoviesRepo moviesRepo) {
                _moviesRepo = moviesRepo;
            }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken) {
                return new Response(await _moviesRepo.Add(request.Movie));
            }
        }
    }
}
