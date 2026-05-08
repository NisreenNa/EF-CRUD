using App5;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using (var db = new ApplicationDbContext())
        {
            
            var user1 = new User { Name = "Ali", Price = 100 };
            var user2 = new User { Name = "Sara", Price = 200 };
            var user3 = new User { Name = "Ameer", Price = 100 };
            var user4 = new User { Name = "Fatima", Price = 200 };

            db.Users.Add(user1);
            db.Users.Add(user2);
            db.Users.Add(user3);
            db.Users.Add(user4);

            db.SaveChanges();
            Console.WriteLine("Users Added!");

             
            var users = db.Users.ToList();
            Console.WriteLine("\nAll Users:");
            foreach (var u in users)
            {
                Console.WriteLine($"{u.Id} - {u.Name} - {u.Price}");
            }

            
            var userToUpdate = db.Users.FirstOrDefault();
            if (userToUpdate != null)
            {
                userToUpdate.Price = 999;
                db.SaveChanges();
                Console.WriteLine("\nUser Updated!");
            }

            
            var userToDelete = db.Users.FirstOrDefault();
            if (userToDelete != null)
            {
                db.Users.Remove(userToDelete);
                db.SaveChanges();
                Console.WriteLine("\nUser Deleted!");
            }
        }
    }
}