# TaskManagerApp

This is a simple Task Manager application built with **ASP.NET Core MVC**.  
It allows you to create, edit, delete, search, filter, and list tasks using an in-memory repository

This project was built as part of an ASP.NET Core MVC assignment.

## 🛠️ Requirements
- [.NET 8 SDK](https://dotnet.microsoft.com/download) (or compatible)  
- A code editor (Visual Studio, Rider, or VS Code with C# extension)  

### Dependency Injection (DI)
- Services are registered in `Program.cs` using `builder.Services.AddScoped<ITimeProvider, SystemTimeProvider>()`.
- ASP.NET Core automatically injects them into controllers (constructor injection).
- This makes the app easier to test (e.g., replace `SystemTimeProvider` with a mock in unit tests).
