using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using TaskManagerApp.Models;

namespace TaskManagerApp.Data
{
    public class TaskRepository
    {
        private static List<TaskItem> _tasks = new List<TaskItem>()
        {
            new TaskItem
            {
                Id = 1,
                Title = "Create project",
                Description = "Do my ASP.NET assignment",
                DueDate = System.DateTime.Now.AddDays(1),
                IsCompleted = false
            },
            new TaskItem
            {
                Id = 2,
                Title = "Buy Groceries",
                Description = "Milk, eggs, bread",
                DueDate = System.DateTime.Now.AddDays(1),
                IsCompleted = true
            },
            new TaskItem
            {
                Id = 3,
                Title = "Laundry",
                Description = "Wash and dry clothes",
                DueDate = System.DateTime.Now.AddDays(2),
                IsCompleted = false
            }
        };

        public static List<TaskItem> GetAll() => _tasks;

        public static TaskItem GetById(int Id) => _tasks.FirstOrDefault(t => t.Id == Id);

        public static void Add(TaskItem task)
        {
            task.Id = _tasks.Max(t => t.Id) + 1;
            _tasks.Add(task);
        }

        public static void Update(TaskItem task)
        {
            var existing = GetById(task.Id);
            if (existing != null)
            {
                 existing.Title = task.Title;
                 existing.Description = task.Description;
                 existing.DueDate = task.DueDate;
                 existing.IsCompleted = task.IsCompleted;
            }

        }

        public static void Delete(int Id)
        {
            var task = GetById(Id);
            if (task != null) _tasks.Remove(task);

        }
        
    }
}
