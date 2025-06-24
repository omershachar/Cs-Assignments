using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment5.Utilities;

namespace Assignment5
{
    //Global Enums
    public enum Size { S, M, X, XXL, OS }
    public enum Status { NotInUse = 1, LowUsage = 2, HighUsage = 3 }
    [Flags]
    public enum Seasons
    {
        None = 0,
        Summer = 1,
        Autumn = 2,
        Winter = 4,
        Spring = 8
    }
    public class ClothingItem
    {
        public static uint id_counter = 1;

        //Attributes
        uint id;
        string name;
        string color_code;
        Size size;
        Status status;
        Seasons seasons;

        //Properties
        public uint Id {
            get => id;
            set {id = (value > 0) ? value : throw new ArgumentException("Invalid clothing item ID.");}
        }
        public string Name { 
            get => name;
            set {name = (!string.IsNullOrWhiteSpace(value)) ? value : throw new ArgumentException("Invalid clothing item name.");}
        }
        public string Color_code
        {
            get => color_code;
            set {color_code = (Validator.IsColorCodeValid(value)) ? value : throw new ArgumentException("Invalid color code.");}
        }
        public Size Size
        {
            get => size;
            set {size = (Enum.IsDefined(typeof(Size), value)) ? value : throw new ArgumentException("Invalid size.");}
        }
        public Status Status
        {
            get => status;
            set {status = (Enum.IsDefined(typeof(Status), value)) ? value : throw new ArgumentException("Invalid status.");}
        }
        public Seasons Seasons
        {
            get => seasons;
            set {seasons = (Enum.IsDefined(typeof(Seasons), value)) ? value : throw new ArgumentException("Invalid season.");}
        }

        //Constructor
        public ClothingItem() { } // Default constructor
        public ClothingItem(string name, string color_code, Seasons seasons, Size size, Status status)
        {
            Id = id_counter++;
            Name = name;
            Color_code = color_code;
            Seasons = seasons;
            Size = size;
            Status = status;
        }

        public virtual void Print()
        {
            Console.WriteLine($"\nCloth ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Color (RGB): {Color_code}");
            Console.WriteLine($"Size: {Size}");
            Console.WriteLine($"Status: {Status}");

            if (Seasons.HasFlag(Seasons.Summer))
                Console.WriteLine("The cloth is good for summer.");
            if (Seasons.HasFlag(Seasons.Autumn))
                Console.WriteLine("The cloth is good for autumn.");
            if (Seasons.HasFlag(Seasons.Winter))
                Console.WriteLine("The cloth is good for winter.");
            if (Seasons.HasFlag(Seasons.Spring))
                Console.WriteLine("The cloth is good for spring.");
        }
    }
}
