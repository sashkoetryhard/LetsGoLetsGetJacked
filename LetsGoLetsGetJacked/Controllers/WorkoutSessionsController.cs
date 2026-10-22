using Microsoft.AspNetCore.Mvc;
using LetsGoLetsGetJacked.Data;
using LetsGoLetsGetJacked.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var workout = await _context.WorkoutSessions.Include(s => s.Sets).ThenInclude(e => e.Exercise).FirstOrDefaultAsync(i => i.Id == id);
            if (workout == null)
            {
                return NotFound();
            }
            return View(workout);
        }
        public async Task<IActionResult> AddSet(int id)
        {
            var workout = await _context.WorkoutSessions.Include(s => s.Sets).FirstOrDefaultAsync(i => i.Id == id);
            if (workout == null)
            {
                return NotFound();
            }
            ViewData["Exercises"] = new SelectList(await _context.Exercises.OrderBy(n => n.Name).ToListAsync(), "Id", "Name");
            var workoutSet = new WorkoutSet
            {
                WorkoutSessionId = workout.Id,
                SetNumber = workout.Sets.Count + 1
            };
            ViewData["WorkoutName"] = workout.Name;
            return View(workoutSet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSet(WorkoutSet workoutSet)
        {
            var workout = await _context.WorkoutSessions.FirstOrDefaultAsync(i => i.Id == workoutSet.WorkoutSessionId);
            if (workout == null)
            {
                return NotFound();
            }
            if(!await _context.Exercises.AnyAsync(i => i.Id == workoutSet.ExerciseId))
            {
                ModelState.AddModelError(nameof(workoutSet.ExerciseId), "Please enter a valid exercise.");
            }
            if (ModelState.IsValid)
            {
                workoutSet.Id = 0;
                _context.WorkoutSets.Add(workoutSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = workoutSet.WorkoutSessionId });
            }
            ViewData["Exercises"] = new SelectList(await _context.Exercises.OrderBy(n => n.Name).ToListAsync(), "Id", "Name", workoutSet.ExerciseId); ;
            ViewData["WorkoutName"] = workout.Name;
            return View(workoutSet);
        }
    }
}
