using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nASEAN PHONEBOOK");
            Console.WriteLine("Main Menu");
            Console.WriteLine("[1] Store to ASEAN Phonebook\n[2] Exit");
            int mainMenu = int.Parse(Console.ReadLine());

            switch (mainMenu)
            {
                case 1:
                    //phonebook.StoreEntry();
                    //break;
                case 2:
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid number.");
                    break;
            }
        }
    }
}