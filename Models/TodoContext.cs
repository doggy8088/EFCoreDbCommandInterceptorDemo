using Microsoft.EntityFrameworkCore;

namespace efdemo1.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext() { }
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 加入自訂的 DbCommandInterceptor 實作
            optionsBuilder.AddInterceptors(new CreateDatabaseCollationInterceptor("Chinese_Taiwan_Stroke_CI_AS"));

            // 設定預設連接字串
            optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=Todo1;User Id=sa;Password=Ver7CompleXPW");
        }

        public virtual DbSet<Todo> Todos { get; set; }
    }
}