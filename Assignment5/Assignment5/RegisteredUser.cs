using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment5.Utilities;

namespace Assignment5
{
    public class RegisteredUser : User
    {
        //Attributes
        string password, email;
        List<ClothingAd> clothingAds = new List<ClothingAd>();

        //Properties
        protected string Password
        {
            get => password;
            set => password = (!string.IsNullOrWhiteSpace(value)) ? value : throw new ArgumentException("Invalid password.");
        }
        public string Email
        {
            get => email;
            set => email = (Validator.IsEmailValid(value)) ? value : throw new ArgumentException("Invalid email.");
        }

        //Constructors
        public RegisteredUser() : base()
        {
            Email = "default@email.com";
            Password = "123";
        }
        public RegisteredUser(string userId, string email, string password, string firstName, string lastName, string nickName, string phoneNumber, DateTime birthDate)
            : base(userId, firstName, lastName, nickName, phoneNumber, birthDate)
        {
            Email = email;
            Password = password;
        }

        //Methods
        public bool CheckPassword(string password) => Password == password;
        public bool CheckEmail(string email) => Email == email;

        public void AddClothingAd(ClothingAd ad)
        {
            if (ad != null)
            {
                clothingAds.Add(ad);
            }
            else
            {
                throw new ArgumentNullException("Clothing ad cannot be null.");
            }
        }

        public void RemoveClothingAd(ClothingAd ad)
        {
            if (clothingAds.Contains(ad))
            {
                clothingAds.Remove(ad);
            }
            else
            {
                throw new ArgumentException("Clothing ad not found.");
            }
        }

        public void PrintClothingAds()
        {
            if (clothingAds.Count > 0)
            {
                Console.WriteLine("Clothing Ads:");
                foreach (var ad in clothingAds)
                {
                    ad.PrintAdDetails();
                }
            }
            else
            {
                Console.WriteLine("No clothing ads found.\n");
            }
        }

        public override void Print()
        {
            Console.WriteLine($"Email: {Email}");
            base.Print();
            PrintClothingAds();
        }
    }
}
