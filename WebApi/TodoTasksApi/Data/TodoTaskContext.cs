using CBC.TaskManagement.WebApi.TodoTasksApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace CBC.TaskManagement.WebApi.TodoTasksApi.Data
{
    public class TodoTaskContext : DbContext
    {
        public TodoTaskContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<TodoTask> TodoTasks { get; set; }
    }
}
