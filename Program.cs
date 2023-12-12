using System;
using System.Collections.Generic;

// Main class
class Phonebook {
    private List<Dictionary<string, object>> book_malay;
    private List<Dictionary<string, object>> book_indo;
    private List<Dictionary<string, object>> book_phil;
    private List<Dictionary<string, object>> book_sing;
    private List<Dictionary<string, object>> book_thai;

    private string student_number;
    private string surname;
    private string first_name;
    private string occupation;
    private string gender;
    private int country_code;
    private int area_code;
    private long phone_number;

    public string Student_Number {
        get { return student_number; }
        set { student_number = value; }
    }

    public string Surname {
        get { return surname; }
        set { surname = value; }
    }

    public string First_Name {
        get { return first_name; }
        set { first_name = value; }
    }

    public string Occupation {
        get { return occupation; }
        set { occupation = value; }
    }

    public string Gender {
        get { return gender; }
        set { gender = value; }
    }

    public int Country_Code {
        get { return country_code; }
        set { country_code = value; }
    }

    public int Area_Code {
        get { return area_code; }
        set { area_code = value; }
    }

    public long Phone_Number {
        get { return phone_number; }
        set { phone_number = value; }
    }

    public Phonebook() {
        book_malay = new List<Dictionary<string, object>>();
        book_indo = new List<Dictionary<string, object>>();
        book_phil = new List<Dictionary<string, object>>();
        book_sing = new List<Dictionary<string, object>>();
        book_thai = new List<Dictionary<string, object>>();
    }
} // class Phonebook

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