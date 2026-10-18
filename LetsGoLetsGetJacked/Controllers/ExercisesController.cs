using Microsoft.AspNetCore.Mvc;
using LetsGoLetsGetJacked.Data;
using Microsoft.EntityFrameworkCore;
namespace LetsGoLetsGetJacked.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ExercisesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var exercises = await _context.Exercises.ToListAsync();
            return View(exercises);
        }
    }
}
