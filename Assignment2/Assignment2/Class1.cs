using System;

namespace Assignment2
{
    internal class ClothingItem
    {
        // Fields to represent the clothing item's properties
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

        // Constructors
        public ClothingItem() { } // Default constructor

        // Parameterized constructor with input validation via setter methods
        public ClothingItem(uint id, string name, string color_code, bool summer, bool autumn, bool winter, bool spring, string size, uint price, bool favorite, uint status, string type, string brand)
        {
            this.id = id;
            this.name = name;
            setColorCode(color_code); // Validate and assign color
            this.summer = summer;
            this.autumn = autumn;
            this.winter = winter;
            this.spring = spring;
            set_size(size);           // Validate and assign size
            set_price(price);         // Assign price (no validation needed)
            this.favorite = favorite;
            set_status(status);       // Validate and assign status
            this.type = type;
            this.brand = brand;
        }

        // Setter for color code with validation loop
        public void setColorCode(string color_code)
        {
            while (!is_color_valid(color_code))
            {
                Console.WriteLine("color most be RGB format (#XXXXXX). please enter again:");
                color_code = Console.ReadLine();
            }
            this.color_code = color_code;
        }

        // Setter for size with validation loop
        public void set_size(string size)
        {
            while (!is_size_valid(size))
            {
                Console.WriteLine("size most be - S/M/X/XXL/OS. please enter again");
                size = Console.ReadLine();
            }
            this.size = size;
        }

        // Setter for price (no validation needed as it's uint)
        public void set_price(uint price)
        {
            this.price = price;
        }

        // Setter for status with validation loop
        public void set_status(uint status)
        {
            while (!is_status_valid(status))
            {
                Console.WriteLine("status most be between 1-3 (1 not in use, 2 low usage, 3 high usage). please enter again: ");
                status = uint.Parse(Console.ReadLine());
            }
            this.status = status;
        }

        // Method to print all details of the clothing item
        public void print()
        {
            Console.WriteLine("id: {0}", id);
            Console.WriteLine("name: {0}", name);
            Console.WriteLine("color in RBG: {0}", color_code);

            if (summer)
                Console.WriteLine("the cloth is good for the summer");
            if (autumn)
                Console.WriteLine("the cloth is good for the autumn");
            if (winter)
                Console.WriteLine("the cloth is good for the winter");
            if (spring)
                Console.WriteLine("the cloth is good for the spring");

            Console.WriteLine("size: {0}", size);
            Console.WriteLine("price: {0}", price);

            if (favorite)
                Console.WriteLine("cloth is favorite");

            Console.WriteLine("status: {0}", status);
            Console.WriteLine("type: {0}", type);
            Console.WriteLine("brand: {0}", brand);
        }

        // Validation: checks if color code is in correct RGB format (#XXXXXX)
        private bool is_color_valid(string color_code)
        {
            if (color_code[0] != '#' || color_code.Length != 7)
                return false;

            for (int i = 1; i < color_code.Length; i++)
            {
                if (!((color_code[i] >= '0' && color_code[i] <= '9') || (color_code[i] >= 'a' && color_code[i] <= 'f')))
                    return false;
            }
            return true;
        }

        // Validation: checks if size is one of the accepted values
        private bool is_size_valid(string size)
        {
            if (size == "S" || size == "M" || size == "X" || size == "XXL" || size == "OS")
                return true;
            return false;
        }

        // Validation: checks if status is between 1 and 3
        private bool is_status_valid(uint status)
        {
            if (status >= 1 && status <= 3)
                return true;
            return false;
        }
    }
}
