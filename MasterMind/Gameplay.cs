using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    internal class Gameplay
    {
        public static void Play()
        {
            Console.Clear();

            Console.WriteLine("Enter your guess");

            Random rnd = new Random();  //makes the random number with 3 digits
            int[] target = new int[3];
            while (target.Distinct().Count() != 3) 
            {
                for (int x = 0; x < 3; x++)
                {
                    target[x] = rnd.Next(10);
                }
            }

            int attempts = 0;
            while (true)
            {
                string innput = Console.ReadLine();
                while (innput.Length != 3) //makes sure that users enters the right lenght
                {
                    Console.WriteLine("The entered number must be 3 digits long");
                    innput = Console.ReadLine();
                }
                attempts++;
                int[] enteredNumber = innput.Select(v => v - '0').ToArray(); //converts input to array
                int rihgtNumber = 0;
                int rightPosition = 0;
                for (int c = 0; c < 3; c++)  //compares the input with target, one digit after another
                {
                    if (target.Contains(enteredNumber[c]))
                    {
                        rihgtNumber++; //if the 'target' contains 1 number from the input, the 'rihgtNumber' coutner adds 1
                    }
                    if (target[c] == enteredNumber[c])
                    {
                        rightPosition++; //if the 'target' contains 1 number on the right position, the 'rightPosition' coutner adds 1
                    }
                }
                if (rightPosition == 3) //the game is over when the 'right position' value reaches 3, which means the user had guessed the 'target'
                {
                    Console.WriteLine("Yay, you got it! Number of attempts: {0}. Press any key to return to the main menu.", attempts);
                    Console.ReadKey();
                    break;
                }
                Console.Write(rihgtNumber + " of the entered digits are in the number, of which ");
                Console.WriteLine(rightPosition + " of them are on the right position. Enter your next guess:");
            }
        }
    }
}
