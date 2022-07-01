//This file is not used in the program whatsoever.
//It is the original source code I wrote back in early 2021 in Czech
//It is just a backup

using System;
using System.Linq;
using System.IO;

namespace MasterMind01
{
    class Program
    {
        public static void Menu() // Hlavní menu
        {
            Console.Clear();
            Console.WriteLine("Vítejte ve hře MasterMind v1");
            Console.WriteLine();
            Console.WriteLine("Stiskněte 'N' pro novou hru\nStiskněte 'H' pro nápovědu\nStiskněte 'S' pro skóre\nStiskněte 'E' pro konec");
        }

        public static void Napoveda() // Nápověda vysvětluje princip hry
        {
            Console.Clear();
            Console.WriteLine("Pravidla hry: \nPočítač vygeneruje náhodné trojciferné číslo. \nJe na vás, uhodnout jaké.\nNa začátku hry zadáte svůj odhad. Dostanete zpětnou vazbu - kolik ze zadaných cifer se nachází v čísle, a kolik z nich je na správné pozici.\nHra má neomezený počet pokusů, ale čím rychleji odhalíte odpověď, tím lépe.");
            Console.WriteLine();
            Console.WriteLine("Stiskem klávesy 'A' vygenerujete soubor s nápovědou, stiskem jakékoliv jiné klávesy se vrátíte zpět do menu");

            char klavesaNapoveda; //klávesa výběru
            klavesaNapoveda = char.ToLower(Console.ReadKey().KeyChar);

            if (klavesaNapoveda == 'a') //pokud je klávesa výběru 'a' program vygeneruje soubor s nápovědou. Využití by bylo třeba pro tisk, kdyby šlo o komplexnější program
            {                           //zde jen pro ukázku generování souboru
                using (StreamWriter pravidla = new StreamWriter(@"pravidla.txt"))
                {
                    pravidla.WriteLine("Pravidla hry:");
                    pravidla.WriteLine("Počítač vygeneruje náhodné trojciferné číslo. Cílem hry je uhodnout jaké.");
                    pravidla.WriteLine("Na začátku hry zadáte svůj odhad. Dostanete zpětnou vazbu - kolik ze zadaných cifer se nachází v čísle, a kolik z nich je na správné pozici.");
                    pravidla.WriteLine("Hra má neomezený počet pokusů, ale čím rychleji odhalíte odpověď, tím lépe.");
                    pravidla.Flush();
                    pravidla.Close();
                }
                Console.WriteLine("\nExport byl úspěšný. Pro pokračování stiśkněte libovolnou klávesu.");
                Console.ReadKey();
            }
        }
        
        public static void Gameplay() // Jádro hry
        {
            Console.Clear();

            Console.WriteLine("Zadejte váš odhad ve formě trojciferného čísla.");
            Random rnd = new Random();
            int[] target = new int[3];
            while (target.Distinct().Count() != 3) //generování trojciferného čísla
            {
                for (int x = 0; x < 3; x++)
                {
                    target[x] = rnd.Next(10);
                }
            }
            int pokusy = 0;
            while (true)
            {
                string vstup = Console.ReadLine();
                while (vstup.Length != 3) //ochrana proti zadání špatné hodnoty
                {
                    Console.WriteLine("Prosím zadejte TROJCIFERNÉ číslo.");
                    vstup = Console.ReadLine();
                }
                pokusy++;
                int[] zadaneCislo = vstup.Select(v => v - '0').ToArray(); //převádí vstup ze stringu na array
                int spravneCislo = 0;
                int spravnaPozice = 0;
                for (int c = 0; c < 3; c++)  //porovnání vstupu s vygenerovaným číslem, cifru po cifře
                {
                    if (target.Contains(zadaneCislo[c]))
                    {
                        spravneCislo++; //pokud 'target' obsahuje jednu z cifer ze vstupu, zvýší se počítadlo 'spravneCislo'
                    }
                    if (target[c] == zadaneCislo[c])
                    {
                        spravnaPozice++; //pokud 'target' obsahuje cifru ze vstupu na stejné pozici, zvýší se počítadlo 'spravnaPozice'
                    }
                }
                if (spravnaPozice == 3) //konec hry nastává, když se počítadlo 'spravnaPozice' dostane na 3, což znamená že uživatel přišel na hodnotu 'target'
                {
                    Console.WriteLine("Správně! Počet pokusů: {0}. Stisknutím jakéhokoliv tlačitka se vrátite zpět do menu.", pokusy);
                    Console.ReadKey();
                    break;
                }
                Console.Write(spravneCislo + " ze zadaných cifer se nachází v čísle, z toho ");
                Console.WriteLine(spravnaPozice + " na správné pozici. Zadejte další odhad:");
            }
        }

        public static void TabulkaSkore() //generuje soubor se skóre, který se pak načítá v části skóre
        {
            StreamWriter skore = new StreamWriter(@"skore.txt");
            skore.WriteLine("Fanda;3;");
            skore.WriteLine("Máma;4;");
            skore.WriteLine("Petr;5;");
            skore.WriteLine("Paleček;6;");
            skore.WriteLine("Ondra;7;");
            skore.WriteLine("Matouš;9;");
            skore.Flush();
            skore.Close();
        }   //tato metoda je tady jen proto, aby měl program co načítat v metodě Skore

        public static void Skore() //skóre
        {
            Console.Clear();
            Console.WriteLine("Stiskem klávesy 'A' importujete skóre.\nSoubor se skóre je ve formátu .txt a formě [jmeno];[pocet_pokusu]; - např: Dominika;6;\nStiskem jakékoliv jiné klávesy se vrátite zpět do menu");

            char klavesaSkore;  //klávesa výběru
            klavesaSkore = char.ToLower(Console.ReadKey().KeyChar);

            if (klavesaSkore == 'a') //pokud uživatel stiskne 'a', načte se tabulka se skóre, jinak se vrátí do menu
            {
                string radek;
                Console.WriteLine("{0, 10} {1, 5}", "Jmeno", "Skore"); //hlavička tabulky

                StreamReader tabulka = new StreamReader(@"skore.txt");
                while((radek=tabulka.ReadLine()) != null)
                {
                    string[] castiRadku = radek.Split(';');
                    Console.WriteLine("{0, 10} {1, 5}", castiRadku[0], castiRadku[1]);
                }
                tabulka.Close();
            }
            Console.WriteLine("Stisknutím jakéhokoliv tlačitka se vrátite zpět do menu.");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            TabulkaSkore(); //vygeneruje soubor se skóre
            Menu();         //vypíše hlavní menu

            char klavesaMenu;   //klávesa výběru
            bool konecMenu = false;  //vypínač

            do
            {
                klavesaMenu = char.ToLower(Console.ReadKey().KeyChar);   //výběr z menu
                switch (klavesaMenu)
                {
                    case 'n':   //nová hra (New game)
                        Gameplay();
                        Menu();
                        break;

                    case 'h':   //nápověda (Help)
                        Napoveda();
                        Menu();
                        break;

                    case 's': //tabulka skóre
                        Skore();
                        Menu();
                        break;

                    case 'e':  //konec (E xit)
                        konecMenu = true; //nastaví bool konec na true, čímž ukončí do-while loop a tím celý program
                        break;

                    default:
                        Console.WriteLine("\nProsím vyberte jednu z možností");
                        break;
                }
            } while (konecMenu == false); //menu poběží dokud se nepřenastaví vypínač konecMenu na 'true'
        }
    }
}
