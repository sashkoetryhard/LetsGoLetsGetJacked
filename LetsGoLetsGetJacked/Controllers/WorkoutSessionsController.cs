using Microsoft.AspNetCore.Mvc;
using LetsGoLetsGetJacked.Data;
using LetsGoLetsGetJacked.Models;
using Microsoft.EntityFrameworkCore;
namespace LetsGoLetsGetJacked.Controllers
{
    public class WorkoutSessionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public WorkoutSessionsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var workouts = await _context.WorkoutSessions.OrderByDescending(d => d.Date).ToListAsync();
            return View(workouts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkoutSession workoutSession)
        {
            if (ModelState.IsValid)
            {
                _context.WorkoutSessions.Add(workoutSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workoutSession);
        }
    }
}
