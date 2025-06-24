using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Program
    {
        //Q5
        static void Main(string[] args)
        {
            int choice = 0;
            while (true)
            {
                //menu message
                Console.Write("Menu:\n" +
                    "(1) - Reducing Number\n" +
                    "(2) - Peg Number\n" +
                    "(3) - Ascending Array\n" +
                    "(4) - Sentence Encryption\n" +
                    "(5) - Exit\n\n" +
                    "Please enter your choice: ");

                choice = int.Parse(Console.ReadLine()); //getting user's choice
                switch (choice)
                {
                    case 1: //if 1 was selected
                        Console.Write("Please enter a number: ");
                        uint num = uint.Parse(Console.ReadLine()); // getting the number from the user
                        Console.WriteLine($"The new reduced number is: {Reducing_number(num)}\n"); // print the new number
                        break;

                    case 2: // if 2 was selected
                        uint[] arr = new uint[5]; // create an array of uint with 5 
                        Console.WriteLine("Please Enter 5 number: ");
                        // get number for the array
                        for (int i = 0; i < arr.Length; i++)
                        {
                            arr[i] = uint.Parse(Console.ReadLine());
                        }
                        Console.WriteLine("Enter a number to check: ");
                        uint num_to_check = uint.Parse(Console.ReadLine()); // get the number to check

                        //check and print accordingly
                        if (Peg_number(arr, num_to_check) == true)
                        {
                            Console.WriteLine($"The number {num_to_check} is Peg\n");
                        }
                        else
                        {
                            Console.WriteLine($"The number {num_to_check} is NOT a Peg\n");
                        }
                        break;

                    case 3: // if 3 was selected
                        float[,] arr_float = new float[3, 2]; // create a float array of 3 rows and 2 cols  
                        Console.WriteLine("enter 6 number for the array {3,2}: ");
                        // getting the numbers from the user to the array
                        for (int i = 0; i < arr_float.GetLength(0); i++) // rows
                        {
                            for (int j = 0; j < arr_float.GetLength(1); j++) // cols
                            {
                                arr_float[i, j] = float.Parse(Console.ReadLine());
                            }
                        }
                        //check and print accordingly
                        if (Ascending_array(arr_float) == true)
                        {
                            Console.WriteLine("Array is ascending\n");
                        }
                        else
                        {
                            Console.WriteLine("Array is NOT ascending\n");
                        }
                        break;

                    case 4: // if 4 was selected
                        string str = "SO HAPPY TO FINISH THIS HOME WORK";
                        Console.WriteLine(Sentence_encryption(str) + "\n");
                        break;

                    case 5: // if 5 was selected
                        Console.WriteLine("goodbye :)");
                        return; // exit the program

                    // if user didn't select number from 1-5
                    default:
                        Console.WriteLine("Invalid number. Please try again\n");
                        break;
                }
            }
        }
        //Q1
        static uint Reducing_number(uint num)
        {
            if (num < 10) { return num; } //checking if it's already reduced number
            uint right_digit = num % 10; //getting the right digit
            while (num >= 10)
            {
                num = num / 10; //removing the right digit
            }
            uint left_digit = num * 10; //getting the left digit

            return right_digit + left_digit; //return the reduced number
        }

        //Q2
        static bool Peg_number(uint[] A, uint x)
        {
            if (A.Length != 0 && Array.IndexOf(A, x) != -1) //checking that the array isn't empty and contain x
            {
                uint[] A_cloned = (uint[])A.Clone(); //cloning the array
                Array.Sort(A_cloned); //sorting the cloned array

                if (Array.IndexOf(A, x) == Array.IndexOf(A_cloned, x)) //compering indexes of x in both arrays
                {
                    return true; //return true if the number is "a peg"
                }
            }
            return false;
        }

        //Q3
        static bool Ascending_array(float[,] arr)
        {
            float current_sum = 0, previous_sum = 0;

            for (int i = 0; i < arr.GetLength(0); i++) //rows
            {
                for (int j = 0; j < arr.GetLength(1); j++) //columns
                {
                    current_sum += arr[i, j]; //computing current row's sum
                }
                //checking if ascending array so far and return false if isn't
                if (current_sum < previous_sum) { return false; }
                //resetting sums
                previous_sum = current_sum;
                current_sum = 0;
            }
            return true; //return true if checked all the rows in the array
        }

        //Q4
        static string Sentence_encryption(string str)
        {
            char[] new_string = new char[str.Length]; // creating array of chars

            for (int i = 0; i < str.Length; i++) // going through each char
            {
                switch (str[i]) // checking if its a spacial char and change accordingly
                {
                    case 'A':
                        new_string[i] = '*';
                        break;

                    case 'U':
                        new_string[i] = '%';
                        break;

                    case 'E':
                        new_string[i] = '#';
                        break;

                    case 'I':
                        new_string[i] = '&';
                        break;

                    case 'O':
                        new_string[i] = '$';
                        break;

                    default:
                        new_string[i] = str[i];
                        break;
                }
            }

            return new string(new_string); // return the encrypted array of char as a string
        }
    }
}
