using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    internal class Score
    {
        //the following exist purely for the sake of it existing. In the assignment I had to have data export and import.
        //But in a program like this (Master Mind was also assigned, not chosen) it is difficult to come up with a reason for import and export
        //This method is here just to prove my teacher that I can create a file and later load the values from it.
        public static void Make() //makes a text file with scores. 
        {
            StreamWriter score = new StreamWriter(@"scoreboard.txt");
            score.WriteLine("Fanda;3;");
            score.WriteLine("Máma;4;");
            score.WriteLine("Petr;5;");
            score.WriteLine("Paleček;6;");
            score.WriteLine("Ondra;7;");
            score.WriteLine("Matouš;9;");
            score.Flush();
            score.Close();
        }
        public static void Import()
        {
            Console.Clear();
            Console.WriteLine("Press the 'Y' key to import scores.\nThe scores file is a .txt file structured like [name];[attempts]; - e.g. Dominika;6;\nPress any other key to return to the main menu.");

            char charScore;  //saves the key used for navigation
            charScore = char.ToLower(Console.ReadKey().KeyChar);

            if (charScore == 'y') //if the user presses 'y' the program loads the scoreboard.txt file
            {
                string line;
                Console.WriteLine("{0, 10} {1, 5}", "Name", "Score"); //table heading

                StreamReader table = new StreamReader(@"skore.txt");
                while ((line = table.ReadLine()) != null)
                {
                    string[] linePart = line.Split(';');
                    Console.WriteLine("{0, 10} {1, 5}", linePart[0], linePart[1]);
                }
                table.Close();
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }
    }
}
