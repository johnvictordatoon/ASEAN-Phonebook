using System;
using System.Collections.Generic;

// Master class
class Master {
    static void Main() {
        // Main menu
        while (true) {
            string txt = "ASEAN PHONEBOOK";
            string centerTxt = txt.PadLeft((50 + txt.Length) / 2).PadRight(50);
            Console.WriteLine(centerTxt);
            Console.WriteLine("Main Menu");
            Console.WriteLine("[1] Store to ASEAN Phonebook\n[2] Edit Entry in ASEAN Phonebook\n[3] Search ASEAN Phonebook by Country\n[4] Exit");
            Console.Write("Type Here: ");
            string main_menu = Console.ReadLine();

            if (int.TryParse(main_menu, out int main_menu_option)) {
                switch (main_menu_option) {
                    case 1:
                        txt = "Selected: Store to ASEAN Phonebook";
                        centerTxt = txt.PadLeft((50 + txt.Length) / 2).PadRight(50);
                        Console.WriteLine(centerTxt);
                        break;
                    case 2:
                        txt = "Selected: Edit Entry in ASEAN Phonebook";
                        centerTxt = txt.PadLeft((50 + txt.Length) / 2).PadRight(50);
                        Console.WriteLine(centerTxt);               
                        break;
                    case 3:
                        txt = "Selected: Search ASEAN Phonebook by Country";
                        centerTxt = txt.PadLeft((50 + txt.Length) / 2).PadRight(50);
                        Console.WriteLine(centerTxt);
                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Selection doesn't exist.");
                        break;
                }
            }
            else {
                Console.WriteLine("Selection doesn't exist.");
            }
        }
    }
}