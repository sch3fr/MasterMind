using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    public class Menu
    {
        public static void Show() //shows the main menu
        {
            Console.Clear();
            Console.WriteLine("Welcome to MasterMind v2");
            Console.WriteLine();
            Console.WriteLine("Press 'N' for new game\nPress 'H' for help\nPress 'S' for scoreboard\nPress 'E' to exit the game");
        }

        public static void Help() //shows help screen
        {
            Console.Clear();
            Console.WriteLine("Rules: \nThe computer generates random three digits number.\nYour task is to guess what number it is.\nAt the beginning, you enter your first guess.\nYou'll get immediate feedback on how many of the entered digits exist in the number\nand a how many of them are on the right position.\nThe game has no limit, but the fewer guesses you take the better :)");
            Console.WriteLine();
            Console.WriteLine("Press the 'Y' key to generate the rules text file, press any other key to return to the main menu");

            char charHelp; //saves the key used for navigation
            charHelp = char.ToLower(Console.ReadKey().KeyChar); //input

            //the following exist purely for the sake of it existing. In the assignment I had to have data export and import.
            //But in a program like this (Master Mind was also assigned, not chosen) it is difficult to come up with a reason for import and export

            if (charHelp == 'y')
            //If user presses 'y' the program makes a text file with rules.
            //This could be used for example for printing the documentation, if the program was more complex.
            //This here is just to demonstrate that I am capable of making a text file.
            {
                using (StreamWriter rules = new StreamWriter(@"rules.txt"))
                {
                    rules.WriteLine("Rules:");
                    rules.WriteLine("he computer generates random three digits number.");
                    rules.WriteLine("Your task is to guess what number it is.");
                    rules.WriteLine("At the beginning, you enter your first guess.");
                    rules.WriteLine("You'll get immediate feedback on how many of the entered digits exist in the number");
                    rules.WriteLine("and a how many of them are on the right position.");
                    rules.WriteLine("The game has no limit, but the fewer guesses you take the better :)");
                    rules.Flush();
                    rules.Close();
                }
                Console.WriteLine("\nExport sucessful. Press any key to return to the main menu");
                Console.ReadKey();
            }
        }
    }
}