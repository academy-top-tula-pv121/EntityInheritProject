using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityInheritProject
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { set; get; }
    }

    //[Table("Users")]
    public class User : Person
    {
        public int Code { set; get; }
    }

    //[Table("Admins")]
    public class Admin : Person
    {
        public string? Login { set; get; }
    }

    public class UserContext : DbContext
    {
        public DbSet<Person> Persons { set; get; } = null!;
        public DbSet<Admin> Admins { set; get; } = null!;
        public DbSet<User> Users { set; get; } = null!; 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=UsersDb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Admin>().ToTable("Admins");
        }
    }

}
