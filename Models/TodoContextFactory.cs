using Microsoft.EntityFrameworkCore.Design;

namespace efdemo1.Models
{
    public class TodoContextFactory : IDesignTimeDbContextFactory<TodoContext>
    {
        public TodoContext CreateDbContext(string[] args)
        {
            return new TodoContext();
        }
    }
}