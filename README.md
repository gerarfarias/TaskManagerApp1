# TaskManagerApp

This is a simple Task Manager application built with **ASP.NET Core MVC**.  
It allows you to create, edit, delete, search, filter, and list tasks using an in-memory repository

This project was built as part of an ASP.NET Core MVC assignment.

## Requirements
- [.NET 8 SDK](https://dotnet.microsoft.com/download) (or compatible)  
- A code editor (Visual Studio, Rider, or VS Code with C# extension)  

### Dependency Injection (DI)
- Services are registered in `Program.cs` using `builder.Services.AddScoped<ITimeProvider, SystemTimeProvider>()`.
- ASP.NET Core automatically injects them into controllers (constructor injection).
- This makes the app easier to test (e.g., replace `SystemTimeProvider` with a mock in unit tests).

## Route Map (with Attribute Routing)

The `TaskController` uses **attribute routing** so each action has a clear, REST-like URL.

### Routes

- **GET /tasks** → Show all tasks (Index)
- **GET /tasks/create** → Show form to create a new task
- **POST /tasks/create** → Submit a new task
- **GET /tasks/edit/{id}** → Show form to edit task with given Id
- **POST /tasks/edit/{id}** → Submit updates to task
- **GET /tasks/delete/{id}** → Show confirmation page to delete task
- **POST /tasks/delete/{id}** → Confirm deletion of task
- **GET /tasks/privacy** → Show privacy page
- **GET /tasks/error** → Show error page

### Example URLs

- `https://localhost:7223/tasks` → Shows task list  
- `https://localhost:7223/tasks/create` → Add new task  
- `https://localhost:7223/tasks/edit/1` → Edit task with Id = 1  
- `https://localhost:7223/tasks/delete/2` → Delete task with Id = 2  
- `https://localhost:7223/tasks/privacy` → Privacy page  

