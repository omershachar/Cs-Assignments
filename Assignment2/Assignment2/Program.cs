using System;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Unique ID counter starting from 1000
            uint id_counter = 1000;

            // Counter to keep track of how many clothing items have been added
            int number_of_cloth = 0;

            // Variable to store user menu choice
            char choice;

            // Array to store clothing items (max 100)
            ClothingItem[] items = new ClothingItem[100];

            // Infinite loop to show menu until user chooses to exit
            while (true)
            {
                // Display menu options to the user
                Console.WriteLine("manu options:\n(a) - add cloth\n(b) - watch all cloths\n(c) - logout");
                choice = char.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 'a':
                        // Check if array is full
                        if (number_of_cloth == 100)
                        {
                            Console.WriteLine("there are no more room for cloth");
                            break;
                        }
                        else
                        {
                            // Variables to hold clothing item details
                            uint id;
                            string name;
                            string color_code;
                            bool summer;
                            bool autumn;
                            bool winter;
                            bool spring;
                            string size;
                            uint price;
                            bool favorite;
                            uint status;
                            string type;
                            string brand;

                            // Input item name
                            Console.WriteLine("Please enter cloth name: ");
                            name = Console.ReadLine();

                            // Input color code (RGB)
                            Console.WriteLine("Please enter color code (RGB): ");
                            color_code = Console.ReadLine();

                            // Assign and increment unique ID
                            id = id_counter++;

                            // Input size
                            Console.WriteLine("Please enter size of cloth (S/M/L/X/XXL/OS): ");
                            size = Console.ReadLine();

                            // Input type
                            Console.WriteLine("Please enter type of cloth: ");
                            type = Console.ReadLine();

                            // Input brand
                            Console.WriteLine("Please enter cloth brand: ");
                            brand = Console.ReadLine();

                            // Loop until at least one season is selected
                            while (true)
                            {
                                summer = seasons("summer");
                                autumn = seasons("autumn");
                                winter = seasons("winter");
                                spring = seasons("spring");

                                if (summer || autumn || winter || spring)
                                    break;

                                Console.WriteLine("At least one season must be selected");
                            }

                            // Input whether item is a favorite
                            Console.WriteLine("Enter yes if the cloth is favorite: ");
                            string temp = Console.ReadLine();
                            if (temp == "yes")
                                favorite = true;
                            else
                                favorite = false;

                            // Input usage status
                            Console.WriteLine("Please enter cloth status (1 not in use, 2 low usage, 3 high usage): ");
                            status = uint.Parse(Console.ReadLine());

                            // Input price
                            Console.WriteLine("Enter cloth price: ");
                            price = uint.Parse(Console.ReadLine());

                            // Create new clothing item and add to array
                            items[number_of_cloth++] = new ClothingItem(id, name, color_code, summer, autumn, winter, spring, size, price, favorite, status, type, brand);
                            break;
                        }

                    case 'b':
                        // If no items to show
                        if (number_of_cloth == 0)
                        {
                            Console.WriteLine("There are no cloth to show");
                            break;
                        }
                        else
                        {
                            // Print all clothing items
                            for (int i = 0; i < number_of_cloth; i++)
                            {
                                items[i].print();
                            }
                            break;
                        }

                    case 'c':
                        // Exit the program
                        Console.WriteLine("Goodbye :)");
                        return;

                    default:
                        // Handle invalid input
                        Console.WriteLine("choice must be a/b/c");
                        break;
                }
            }
        }

        // Helper function to ask if item is good for a given season
        static bool seasons(string season)
        {
            Console.WriteLine($"Please enter yes if the cloth is good for the {season}");
            string temp = Console.ReadLine();
            if (temp == "yes")
                return true;
            return false;
        }
    }
}
