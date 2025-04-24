using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Models
{
    public enum Size {S, M, X, XXL, OS}
    public enum Status {NotInUse = 1, LowUsage = 2,HighUsage = 3}
    [Flags]
    public enum Seasons
    {
        None = 0,
        Summer = 1,
        Autumn = 2,
        Winter = 4,
        Spring = 8
    }
    class ClothingItem
    {
        public static uint id_counter = 1;

        //Clothing item's fields
        uint id;
        string user_id;
        string name;
        string color_code;
        Seasons seasons;
        Size size;
        uint price;
        bool favorite;
        Status status;
        string type;
        string brand;

        //Properties
        public static uint Id_counter {get; set;}
        public uint Id { get; set; }
        public string User_id { get; set; }
        public string Name { get; set; }
        public string Color_code { get; set; }
        public Seasons Seasons { get; set; }
        public Size Size { get; set; }
        public uint Price { get; set; }
        public bool Favorite { get; set; }
        public Status Status { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }

        //Constructors
        public ClothingItem() { } // Default constructor
        public ClothingItem(string user_id, string name, string color_code, Seasons seasons, Size size, uint price, bool favorite, Status status, string type, string brand)
        {
            User_id = user_id;
            Id = id_counter++;
            Name = name;
            Color_code = color_code;
            Seasons = seasons;
            Size = size;
            Price = price;
            Favorite = favorite;
            Status = status;
            Type = type;
            Brand = brand;
        }

        public void print()
        {
            Console.WriteLine($"\nCloth ID: {Id}");
            Console.WriteLine($"User ID: {User_id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Color (RGB): {Color_code}");

            if (Seasons.HasFlag(Seasons.Summer))
                Console.WriteLine("The cloth is good for summer.");
            if (Seasons.HasFlag(Seasons.Autumn))
                Console.WriteLine("The cloth is good for autumn.");
            if (Seasons.HasFlag(Seasons.Winter))
                Console.WriteLine("The cloth is good for winter.");
            if (Seasons.HasFlag(Seasons.Spring))
                Console.WriteLine("The cloth is good for spring.");

            Console.WriteLine($"Size: {Size}");
            Console.WriteLine($"Price: {Price}");

            if (Favorite)
                Console.WriteLine("This cloth is marked as favorite.");

            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Brand: {Brand}\n");
        }
    }

}