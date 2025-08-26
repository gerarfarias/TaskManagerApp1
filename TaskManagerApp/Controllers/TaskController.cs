using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.Models;
using TaskManagerApp.Data;
using Microsoft.Extensions.Logging;

namespace TaskManagerApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;

        public TaskController(ILogger<TaskController> logger)
        {
            _logger = logger;
        }

        // READ - List all tasks
        public IActionResult Index()
        {
            _logger.LogInformation("Fetching all tasks");
            var tasks = TaskRepository.GetAll();
            return View(tasks);
        }

        // GET: Task/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(); // show the create form
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                TaskRepository.Add(task);
                _logger.LogInformation($"Task '{task.Title}' created with ID {task.Id}");
                return RedirectToAction(nameof(Index));
            }
            return View(task); // show form again if validation fails
        }

        // GET: Task/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = TaskRepository.GetById(id);
            if (task == null) return NotFound();
            return View(task);
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                TaskRepository.Update(task);
                _logger.LogInformation($"Task '{task.Title}' with ID {task.Id} updated");
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: Task/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = TaskRepository.GetById(id);
            if (task == null) return NotFound();
            return View(task); // show confirmation page
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            TaskRepository.Delete(id);
            _logger.LogInformation($"Task with ID {id} deleted");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

