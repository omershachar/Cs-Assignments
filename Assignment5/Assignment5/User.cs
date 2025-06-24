using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment5.Utilities;

namespace Assignment5
{
    public class User
    {
        //Attributes
        string userId, first_name, last_name, nick_name, phone_number;
        DateTime birth_date;
        List<ClothingItem> clothing_items = new List<ClothingItem>();

        //Properties
        public string First_name { get { return first_name; } }
        public string Last_name { get { return last_name; } }
        public string User_id { get { return userId; } }

        //Constructors
        protected User()
        {
            this.userId = "0000";
            this.first_name = "Default";
            this.last_name = "User";
            this.nick_name = "Defaulty";
            this.phone_number = "0000000000";
            this.birth_date = new DateTime(2000, 1, 1);
        }

        public User(string userId, string firstName, string lastName, string nickName, string phoneNumber, DateTime birthDate)
        {
            this.userId = (Validator.IsNumberValid(userId)) ? userId : throw new ArgumentException("Invalid user id.");
            this.first_name = (Validator.IsStringValid(firstName)) ? firstName : throw new ArgumentException("Invalid first name.");
            this.last_name = (Validator.IsStringValid(lastName)) ? lastName : throw new ArgumentException("Invalid last name.");
            this.nick_name = (Validator.IsStringValid(nickName)) ? nickName : throw new ArgumentException("Invalid nick name.");
            this.phone_number = (!string.IsNullOrWhiteSpace(phoneNumber)) ? phoneNumber : throw new ArgumentException("Invalid phone number.");
            this.birth_date = (Validator.IsDateValid(birthDate)) ? birthDate : throw new ArgumentException("Invalid date.");
        }

        //Methods
        public void AddClothingItem(ClothingItem item)
        {
            if (item != null)
            {
                clothing_items.Add(item);
            }
            else
            {
                throw new ArgumentNullException("Clothing item cannot be null.");
            }
        }
        public void RemoveClothingItem(ClothingItem item)
        {
            if (clothing_items.Contains(item))
            {
                clothing_items.Remove(item);
            }
            else
            {
                throw new ArgumentException("Clothing item not found in the user's collection.");
            }
        }

        public virtual void Print()
        {
            Console.WriteLine($"User id: {userId}");
            Console.WriteLine($"Name: {first_name} {last_name}");
            Console.WriteLine($"nickName: {nick_name}\nPhone: {phone_number}\nBirth date: {birth_date}");
            if (clothing_items.Count > 0)
            {
                Console.WriteLine($"\n- {First_name}'s Closet: -");
                foreach (var item in clothing_items)
                {
                    item.Print();
                }
                Console.WriteLine("------------");
            }
            else
            {
                Console.WriteLine("No clothing items found.\n");
            }
        }
    }
}
