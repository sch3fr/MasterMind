using MasterMind;

Score.Make();  //Generates the score file
Menu.Show();   //Shows the main menu

char menuKey;   //saves the key used for navigation in menu
bool menuExit = false;  //menu switch

do
{
    menuKey = char.ToLower(Console.ReadKey().KeyChar);   //user imput
    switch (menuKey)
    {
        case 'n':   //New game
            Gameplay.Play();
            Menu.Show();
            break;

        case 'h':   //Help
            Menu.Help();
            Menu.Show();
            break;

        case 's': //Scoreboard
            Score.Import();
            Menu.Show();
            break;

        case 'e':  //Exit
            menuExit = true; //sets the bool to true, ends the do-while loop and the program ends
            break;

        default:
            Console.WriteLine("\nPlease select one of the available choices.");
            break;
    }
} while (menuExit == false); //menu keeps reappearing until the user chooses to exit