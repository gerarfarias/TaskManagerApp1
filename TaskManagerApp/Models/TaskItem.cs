using System;

namespace TaskManagerApp.Models
{
    public class TaskItem
    {
       public int Id { get; set; } //PK
       public string Title { get; set; } //task title
       public string Description{ get; set; } //details
       public DateTime DueDate{ get; set; } //deadline
       public bool IsCompleted { get; set; } //status
    }
}
