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

    // Storing information
    public void Phonebook_Store() {
        Console.Write("Student Number: ");
        Student_Number = Console.ReadLine();
        Console.Write("Surname: ");
        Surname = Console.ReadLine();
        Console.Write("First Name: ");
        First_Name = Console.ReadLine();
        Console.Write("Occupation: ");
        Occupation = Console.ReadLine();
        Console.Write("Gender [Male (M) | Female (F)]: ");
        Gender = Console.ReadLine();
        Console.Write("Country Code (Malaysia - 60, Indonesia - 62, Philippines - 63, Singapore - 65, Thailand - 66): ");
        Country_Code = int.Parse(Console.ReadLine());
        Console.Write("Area Code: ");
        Area_Code = int.Parse(Console.ReadLine());
        Console.Write("Phone Number: ");
        Phone_Number = Convert.ToInt64(Console.ReadLine());

        Console.WriteLine("\nSaving...");
        System.Threading.Thread.Sleep(5000);
        Console.WriteLine("Save Complete!");
        System.Threading.Thread.Sleep(1000);

        Dictionary<string, object> phonebook_info = new Dictionary<string, object> {
            {"Student Number", Student_Number},
            {"Surname", Surname},
            {"First Name", First_Name},
            {"Occupation", Occupation},
            {"Gender", Gender},
            {"Country Code", Country_Code},
            {"Area Code", Area_Code},
            {"Phone Number", Phone_Number}
        };

        if (Country_Code == 60)
            book_malay.Add(phonebook_info);
        else if (Country_Code == 62)
            book_indo.Add(phonebook_info);
        else if (Country_Code == 63)
            book_phil.Add(phonebook_info);
        else if (Country_Code == 65)
            book_sing.Add(phonebook_info);
        else if (Country_Code == 66)
            book_thai.Add(phonebook_info);

        Console.Write("\nEnter Another entry? (Y/N): ");
        string another_entry = Console.ReadLine().ToUpper();
        if (another_entry == "Y") {
            Phonebook_Store();
        }
        else {
            Console.WriteLine("\nReturning to Main Menu...\n");
            System.Threading.Thread.Sleep(3000);
        }
    }

    // Edit stored information
    public void Edit_Phonebook() {
        while (true) {
        Console.Write("Enter student number: ");
        string find_student_number = Console.ReadLine();
        foreach (var phonebook_entry in book_malay.Concat(book_indo).Concat(book_phil).Concat(book_sing).Concat(book_thai)) {
            if (find_student_number == phonebook_entry["Student Number"].ToString()) {
                Console.WriteLine($"Existing info about {find_student_number}:");
                Console.WriteLine($"{phonebook_entry["First Name"]} {phonebook_entry["Surname"]} is a/an {phonebook_entry["Occupation"]}. {phonebook_entry["First Name"]} {phonebook_entry["Surname"]}'s number is {phonebook_entry["Country Code"]}-{phonebook_entry["Area Code"]}-{phonebook_entry["Phone Number"]}");

                while (true) {
                    Console.WriteLine("Which of these info you wish to change?");
                    Console.WriteLine("[1] Student Number\n[2] Surname\n[3] Gender\n[4] Occupation\n[5] Country Code\n[6] Area Code\n[7] Phone Number\n[8] None - Return to Main Menu");
                    Console.Write("Enter here: ");
                    int change_info = int.Parse(Console.ReadLine());

                    if (change_info == 8) {
                        Console.WriteLine("\nReturning to Main Menu...\n");
                        System.Threading.Thread.Sleep(3000);
                        return;
                    }
                    else if (change_info >= 1 && change_info <= 7) {
                        Console.Write($"Enter new {phonebook_entry.Keys.ElementAt(change_info - 1)}: ");
                        string new_info = Console.ReadLine();
                        phonebook_entry[phonebook_entry.Keys.ElementAt(change_info - 1)] = new_info;
                        Console.WriteLine("\nUpdating...\n");
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine($"{phonebook_entry.Keys.ElementAt(change_info - 1)} successfully updated!");
                    }
                    else {
                        Console.WriteLine("Selection doesn't exist.");
                    }
                }
            }
        }
        Console.WriteLine($"\nNo info found in student number {find_student_number}. Register this person first before editing any new information.\n");
        }
    }

    // Search phonebook
    public void Search_Phonebook() {
        Dictionary<int, string> country_names = new Dictionary<int, string> {
            {1, "Philippines"},
            {2, "Thailand"},
            {3, "Singapore"},
            {4, "Indonesia"},
            {5, "Malaysia"},
            {6, "All ASEAN Countries"},
            {0, "No More"}
        };

        Console.WriteLine("From which country/ies?");
        foreach (var pair in country_names) {
            Console.WriteLine($"[{pair.Key}] {pair.Value}");
        }

        HashSet<int> selected_countries = new HashSet<int>();

        int counting = 1;
        while (true) {
            Console.Write($"Select Country #{counting}: ");
            int country_select;

            if (int.TryParse(Console.ReadLine(), out country_select)) {
                if (country_select == 0) {
                    break;
                }
                else if (country_names.ContainsKey(country_select)) {
                    selected_countries.Add(country_select);
                    counting++;
                }
                else {
                    Console.WriteLine("Selection doesn't exist.");
                }
            }
            else {
                Console.WriteLine("Selection doesn't exist.");
            }
        }

        List<Dictionary<string, object>> entries = new List<Dictionary<string, object>>();

        foreach (var selection in selected_countries) {
            switch (selection) {
                case 1:
                    entries.AddRange(book_phil);
                    break;
                case 2:
                    entries.AddRange(book_thai);
                    break;
                case 3:
                    entries.AddRange(book_sing);
                    break;
                case 4:
                    entries.AddRange(book_indo);
                    break;
                case 5:
                    entries.AddRange(book_malay);
                    break;
                case 6:
                    entries.AddRange(book_phil.Concat(book_thai).Concat(book_sing).Concat(book_indo).Concat(book_malay));
                    break;
            }
        }

        if (entries.Count == 0) {
        Console.WriteLine("\nNo information found in selected countries. Returning to Main Menu...\n");
        System.Threading.Thread.Sleep(3000);
        return;
        }

        // Sort surnames alphabetically
        entries.Sort((x, y) => string.Compare(x["Surname"].ToString(), y["Surname"].ToString(), StringComparison.Ordinal));

        // Print information for each entry
        foreach (var entry in entries) {
            Console.WriteLine("\nSearching...\n");
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine($"Here are the students from {string.Join(", ", selected_countries.Select(c => country_names[c]))}:");
            Console.WriteLine($"{entry["Surname"]}, {entry["First Name"]}, with a student number {entry["Student Number"]}, is a {entry["Occupation"]}. {entry["First Name"]}'s phone number is {entry["Country Code"]}-{entry["Area Code"]}-{entry["Phone Number"]}.\n");
        }

        Console.WriteLine("Searching Finished!");
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("Returning to Main Menu...\n");
        System.Threading.Thread.Sleep(3000);
    }
} // class Phonebook

// Master class
class Master {
    static void Main() {
        // Initiate object
        Phonebook phonebook_obj = new Phonebook();
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
                        phonebook_obj.Phonebook_Store();
                        break;
                    case 2:
                        txt = "Selected: Edit Entry in ASEAN Phonebook";
                        centerTxt = txt.PadLeft((50 + txt.Length) / 2).PadRight(50);
                        Console.WriteLine(centerTxt);
                        phonebook_obj.Edit_Phonebook();               
                        break;
                    case 3:
                        txt = "Selected: Search ASEAN Phonebook by Country";
                        centerTxt = txt.PadLeft((50 + txt.Length) / 2).PadRight(50);
                        Console.WriteLine(centerTxt);
                        phonebook_obj.Search_Phonebook();
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