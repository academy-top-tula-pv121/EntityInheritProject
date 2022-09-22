using System;

namespace EntityInheritProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (UserContext userContext = new UserContext())
            {
                userContext.Database.EnsureDeleted();
                userContext.Database.EnsureCreated();

                Person person1 = new() { Name = "Tim" };
                Person person2 = new() { Name = "Sam" };
                userContext.Persons.AddRange(person1, person2);

                User user1 = new() { Name = "Bob", Code = 100 };
                User user2 = new() { Name = "Joe", Code = 200 };
                userContext.Users.AddRange(user1, user2);

                Admin admin1 = new() { Name = "Tom", Login = "tom admin" };
                Admin admin2 = new() { Name = "Jim", Login = "jim admin" };
                userContext.Admins.AddRange(admin1, admin2);

                userContext.SaveChanges();
            }

            using (UserContext userContext = new UserContext())
            {
                var persons = userContext.Persons.ToList();
                Console.WriteLine("Persons");
                foreach (var person in persons)
                    Console.WriteLine(person.Name);

                var users = userContext.Users.ToList();
                Console.WriteLine("\nUsers");
                foreach (var user in users)
                    Console.WriteLine($"{user.Name} {user.Code}");

                var admins = userContext.Admins.ToList();
                Console.WriteLine("\nAdmins");
                foreach (var admin in admins)
                    Console.WriteLine($"{admin.Name} {admin.Login}");
            }
        }
    }
}