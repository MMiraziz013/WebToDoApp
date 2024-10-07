using Microsoft.AspNetCore.Mvc;
using WebToDoApp.Models;
using WebToDoApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace WebToDoApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Tasks/Index
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaskItems.ToListAsync()); // Fetches all tasks from the database
        }

        // GET: /Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                if (task.DueDate >= DateTime.Today)
                {
                    _context.Add(task);  // Adds the task to the database context
                    await _context.SaveChangesAsync();  // Saves changes to the database
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("DueDate", "Selected date is in the past");
                }
            }
            return View(task);
        }

        // GET: /Tasks/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);  // Find task by ID in the database
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: /Tasks/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskItem updatedTask)
        {
            if (ModelState.IsValid)
            {
                var task = await _context.TaskItems.FindAsync(id);  // Find task by ID in the database
                if (task != null)
                {
                    task.Name = updatedTask.Name;
                    task.IsComplete = updatedTask.IsComplete;
                    task.Description = updatedTask.Description;
                    if (updatedTask.DueDate >= DateTime.Today)
                    {
                        task.DueDate = updatedTask.DueDate;
                    }
                    else
                    {
                        ModelState.AddModelError("DueDate", "New date is in the past");
                    }
                    await _context.SaveChangesAsync();  // Save changes to the database
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            return View(updatedTask);
        }

        // GET: /Tasks/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);  // Find task by ID in the database
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: /Tasks/DeleteConfirmed/{id}
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);  // Find task by ID in the database
            if (task != null)
            {
                _context.TaskItems.Remove(task);  // Removes task from the database
                await _context.SaveChangesAsync();  // Save changes to the database
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: /Tasks/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);  // Find task by ID in the database
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: /Tasks/MarkComplete/{id}
        public async Task<IActionResult> MarkComplete(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);  // Find task by ID in the database
            if (task != null)
            {
                task.IsComplete = true;  // Mark task as complete
                await _context.SaveChangesAsync();  // Save changes to the database
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
