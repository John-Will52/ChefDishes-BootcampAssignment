    using Microsoft.EntityFrameworkCore; 
    namespace ChefsDishes.Models
    {
        public class MyContext : DbContext
        {
            public MyContext(DbContextOptions options) : base(options) { }
            
            // "users" table is represented by this DbSet "Users"
            public DbSet<Chef> Chefs {get;set;}
            public DbSet<Dish> Dishes {get;set;}
        }
    }