using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using ORM;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new BlogModel())
            {
                //    User user1 = new User
                //    {
                //        Login = "First",
                //        Password = "qwerty",
                //        Email = "first@gmail.com",
                //        RegistrationDate = DateTime.Now,
                //        Blocked = false
                //    };
                //    db.Users.Add(user1);
                //var user1 = db.Users.First();
                //Console.WriteLine(user1);
                foreach (User item in db.Users)
                {
                    Console.WriteLine(item.Login);
                }
                db.SaveChanges();
            }
            
        }
    }
}
