using Microsoft.AspNetCore.Mvc;
using LetsGoLetsGetJacked.Data;
using Microsoft.EntityFrameworkCore;
using LetsGoLetsGetJacked.Models;
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Exercise exercise)
        {
            if(ModelState.IsValid)
            {
                _context.Add(exercise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exercise);
        }
    }
}
