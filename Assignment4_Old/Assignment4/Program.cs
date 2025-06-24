using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment4.Models;

namespace Assignment4
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            User[] users = new User[]
            {
                new User("123456789", "user1@example.com", "Pass123", "John", "Doe", "Johnny", "123-456-7890", new DateTime(1990, 5, 12)),
                new User("987654321", "user2@example.com", "Secure456", "Jane", "Smith", "Janie", "987-654-3210", new DateTime(1985, 8, 25)),
                new User("951753852", "user3@example.com", "Strong789", "Alex", "Brown", "AI", "555-666-7777", new DateTime(1998, 12, 3))
            };
            Application.Run(new LoginForm(users));
        }
    }
}
