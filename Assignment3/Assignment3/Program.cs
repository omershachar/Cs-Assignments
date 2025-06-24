using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] users = new User[]
            {
                new User("123456789", "user1@example.com", "Pass123", "John",
                "Doe", "Johnny", "123-456-7890", new DateTime(1990, 5, 12)),
                new User("987654321", "user2@example.com", "Secure456", "Jane",
                "Smith", "Janie", "987-654-3210", new DateTime(1985, 8, 25)),
                new User("951753852", "user3@example.com", "Strong789", "Alex",
                "Brown", "AI", "555-666-7777", new DateTime(1998, 12, 3))
            }; //Users array
            ClothingItem[] items = new ClothingItem[100]; //array to store clothing items (max 100)
            int number_of_cloth = 0; //counter for how many clothing items been added and to who

            string user_id = LogIn(users); //log-in verification
            //infinite loop for the menu
            while (true)
            {
                //displaying the menu options
                Console.Write("menu options:\n(1) - add cloth\n(2) - watch your cloths\n(3) - logout\nEnter your choice: ");
                char choice = Console.ReadKey().KeyChar; //variable for storing user's choice in the menu
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        if (number_of_cloth == 100) //check if array is full
                            Console.WriteLine("there is no more room for clothes.\n");
                        else
                            CreateCloth(user_id, items, users, ref number_of_cloth);
                        break;

                    case '2':
                        if (number_of_cloth == 0) //no items to show
                            Console.WriteLine("there are no clothes to show.\n");
                        else
                            for (int i = 0; i < number_of_cloth; i++)
                                items[i].print(); //printing all clothing items
                        break;

                    case '3':
                        Console.WriteLine("\nGoodbye :)"); //exit the program
                        return;

                    default:
                        Console.WriteLine("choice must be 1/2/3\n"); //invalid input
                        break;
                }
            } //end of menu
        } //end of Main

        //helpers functions
        static string LogIn(User[] users) //log-in vertification function
        {
            string user_email, user_pass;
            int i = -1;
            while (i == -1)
            {
                Console.Write("Please enter your email: ");
                user_email = Console.ReadLine();

                Console.Write("Please enter your password: ");
                user_pass = Console.ReadLine();

                i = LogIn(user_email, user_pass, users);

                if (i == -1)
                    Console.WriteLine("ERROR! password or email are not correct. try again..."); //print error message
            }
            Console.WriteLine($"Welcome {users[i].First_name}\n");
            return users[i].User_id;
        }
        static int LogIn(string user_email, string user_pass, User[] users)
        {
            for (int i = 0; i < users.Length; i++)
            {
                if (user_email == users[i].Email && user_pass == users[i].Password)
                    return i; //return user index
            }
            return -1; //wrong password/email
        }

        static void CreateCloth(string user_id, ClothingItem[] items, User[] users, ref int count)
        {
            Console.Write("Enter cloth name: ");
            string name = Console.ReadLine();

            string color_code = GetColorCodeFromUser();

            Size size = GetSizeFromUser();

            Console.Write("Enter cloth type: ");
            string type = Console.ReadLine();

            Console.Write("Enter cloth brand: ");
            string brand = Console.ReadLine();

            Seasons seasons = GetSeasonsFromUser();

            Console.Write("Is this cloth a favorite? (y/n): ");
            bool favorite = Console.ReadLine().ToLower() == "y";

            Status status = GetStatusFromUser();

            uint price = GetPriceFromUser();

            items[count++] = new ClothingItem(user_id, name, color_code, seasons, size, price, favorite, status, type, brand);

            Console.WriteLine("*** new cloth added ***\n");
        }

        static string GetColorCodeFromUser()
        {
            string color_code;
            while (true)
            {
                Console.Write("Enter color code (RGB): ");
                color_code = Console.ReadLine();
                if (is_color_valid(color_code)) //check if color code is in correct RGB format (#XXXXXX)
                    break;
                Console.WriteLine("Color must be RGB format (#XXXXXX).");
            }
            return color_code;
        }
        static bool is_color_valid(string color_code)
        {
            if (color_code == "" || color_code[0] != '#' || color_code.Length != 7)
                return false;

            for (int i = 1; i < color_code.Length; i++)
            {
                if (!((color_code[i] >= '0' && color_code[i] <= '9') || (color_code[i] >= 'a' && color_code[i] <= 'f')))
                    return false;
            }
            return true;
        }

        static Size GetSizeFromUser()
        {
            while (true)
            {
                Console.Write("Enter size (S/M/X/XXL/OS): ");
                string input = Console.ReadLine();

                switch (input.ToUpper())
                {
                    case "S": return Size.S;
                    case "M": return Size.M;
                    case "X": return Size.X;
                    case "XXL": return Size.XXL;
                    case "OS": return Size.OS;
                    default:
                        Console.WriteLine("Invalid size. Please try again.");
                        break;
                }
            }
        }

        static Seasons GetSeasonsFromUser()
            {
                Seasons selected;
                do
                {
                    selected = Seasons.None;

                    Console.Write("Is this cloth good for summer? (y/n) ");
                    if (Console.ReadLine().ToLower() == "y")
                        selected |= Seasons.Summer;

                    Console.Write("Is this cloth good for autumn? (y/n) ");
                    if (Console.ReadLine().ToLower() == "y")
                        selected |= Seasons.Autumn;

                    Console.Write("Is this cloth good for winter? (y/n) ");
                    if (Console.ReadLine().ToLower() == "y")
                        selected |= Seasons.Winter;

                    Console.Write("Is this cloth good for spring? (y/n) ");
                    if (Console.ReadLine().ToLower() == "y")
                        selected |= Seasons.Spring;

                    if (selected == Seasons.None)
                        Console.WriteLine("You must select at least one season.");

                } while (selected == Seasons.None);

                return selected;

            }

        static Status GetStatusFromUser()
        {
            Status status;
            while(true)
            {
                Console.Write("Enter status (1=NotInUse, 2=LowUsage, 3=HighUsage): ");
                if (int.TryParse(Console.ReadLine(), out int s) && Enum.IsDefined(typeof(Status), s))
                {
                    status = (Status)s;
                    break;
                }
                Console.WriteLine("Invalid status. Please enter 1, 2, or 3.");
            }
            return status;
        }

        static uint GetPriceFromUser()
        {
            uint price;
            while (true)
            {
                Console.Write("Enter price: ");
                if (uint.TryParse(Console.ReadLine(), out uint p))
                {
                    price = p;
                    break;
                }
                Console.WriteLine("Price must be a non-negative number.");
            }
            return price;
        }

    } //end of Class Program
} //end of namespace Assignment3