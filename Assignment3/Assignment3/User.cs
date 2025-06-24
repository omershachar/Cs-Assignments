using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class User
    {
        string user_id, email, password, first_name, last_name, nick_name, phone_number;
        DateTime birth_date;

        public User(string userId, string email, string password,
                    string firstName, string lastName, string nickName,
                    string phoneNumber, DateTime birthDate)
        {
            this.user_id = userId;
            this.email = email;
            this.password = password;
            this.first_name = firstName;
            this.last_name = lastName;
            this.nick_name = nickName;
            this.phone_number = phoneNumber;
            this.birth_date = birthDate;
        }

        public string Email { get { return email; } }
        public string Password { get { return password; } }
        public string First_name { get { return first_name; } }
        public string Last_name { get { return last_name; } }
        public string User_id { get { return user_id; } }

        public void Print()
        {
            Console.WriteLine($"Details User ({first_name}) ({last_name}) - ({user_id}):");
            Console.WriteLine($"nickName: ({nick_name})\nPhone: ({phone_number})\nBirth date: ({birth_date})");
        }
    }


}
