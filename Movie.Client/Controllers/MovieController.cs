using Microsoft.AspNetCore.Mvc;
using Movie.Client.Services;
using System.Threading.Tasks;

namespace Movie.Client.Controllers {
    public class MovieController : Controller {
        private readonly IService _movieService;

        public MovieController(IService movieService) {
            _movieService = movieService;
        }

        // GET: Movies
        public async Task<IActionResult> Index() {
            return View(await _movieService.GetAllMoviesAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int id) {

            var movie = await _movieService.GetById(id);

            if (movie == null) return NotFound();


            return View(movie);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,ReleaseData,Owner")] Models.MovieModel movie) {
            if (ModelState.IsValid) {
                await _movieService.Add(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }



    }
}
