// See https://aka.ms/new-console-template for more information
using CareAdvance_Database.Data;
using CareAdvance_Database.Models;
using CareAdvance_Database.Repositories;
using CareAdvance_Database.Utilities;

static void MenuOptions()
{
    Console.WriteLine("-------- Menu --------");
    Console.WriteLine("1 - Add Users");
    Console.WriteLine("2 - Get All Users in Database");
    Console.WriteLine("3 - Save Database to File");
    Console.WriteLine("q - To Quit");
}

static void AddingUsersMenu()
{
    Console.WriteLine("-------- Adding Users Menu --------");
    Console.WriteLine("1 - Add a User");
    Console.WriteLine("2 - Stop");
}

static void SaveFileMenu()
{
    Console.WriteLine("-------- Save File Menu --------");
    Console.WriteLine("1 - Change File Name");
    Console.WriteLine("2 - Overwrite File");
    Console.WriteLine("q - quit");
}

static List<User> GetListOfUsers()
{
    List<User> users = new();
    string? choice = "1";
    
    while (choice != "2")
    {
        switch (choice)
        {
            case "1":
                Console.Write("Username: ");
                string? username = Console.ReadLine();

                Console.Write("First Name: ");
                string? firstName = Console.ReadLine();

                Console.Write("Last Name: ");
                string? lastName = Console.ReadLine();

                users.Add(new User { Username = username, FirstName = firstName, LastName = lastName });
                break;

            case "2":
                Console.WriteLine("Exiting User Creation");
                break;

            default:
                Console.WriteLine("Invalid Choice");
                Console.WriteLine("Please try again");
                break;
        }

        AddingUsersMenu();
        Console.Write("Choice: ");
        choice = Console.ReadLine();
    }

    return users;
}

static async void SaveDatabaseToFile(CareAdvanceRepository repository, FileAccessor fileAccessor)
{
    Console.Write("Enter the name of the file to save: ");
    string? filename = Console.ReadLine();
    string choice = "";

    while (File.Exists(filename) && choice != "q" && choice != "2") 
    {
        Console.Clear();
        SaveFileMenu();
        Console.WriteLine($"file {filename} already exists");
        Console.WriteLine("Would you like to overwrite it?");
        Console.Write("Choice: ");
        choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Enter new file name: ");
                filename = Console.ReadLine();
                break;

            case "2":
                choice = "2";
                break;

            case "q":
                Console.WriteLine("Exiting Save File Creation");
                break;

            default:
                Console.WriteLine("Invalid Choice");
                break;
        }
    }

    if (choice != "q")
    {
        Console.WriteLine($"Saving file {filename}");
        List<User> users = await repository.GetAllUsers();
        fileAccessor.SaveDatabaseToFile(filename, users);
    }
}

static void DisplayAllUsers(List<User> users)
{
    foreach (User user in users)
    {
        Console.WriteLine($"{user.UserId} {user.Username} {user.FirstName} {user.LastName} {user.CreatedDate}");
    }
}

/* 
 * -----------------------------------------------------------
 * MAIN
 * -----------------------------------------------------------
 */

CareAdvanceContext dbContext = new CareAdvanceContext(); 
CareAdvanceRepository repository = new CareAdvanceRepository(dbContext);
FileAccessor fileAccessor = new FileAccessor("Users.txt");
string? choice = "";

while (choice != "q")
{
    MenuOptions();
    Console.Write("Choice: ");
    choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Console.WriteLine("------------ Adding Users ------------");
            fileAccessor.WriteToFile(GetListOfUsers());
            await repository.AddUsers(fileAccessor.ReadFromFile());
            break;

        case "2":
            Console.Clear();
            Console.WriteLine("-------- Users In The Database --------");
            DisplayAllUsers(await repository.GetAllUsers());
            break;

        case "3":
            Console.WriteLine("-------- Saving the Database To A File --------");
            SaveDatabaseToFile(repository, fileAccessor);
            break;

        case "q":
            Console.WriteLine("Quitting...");
            break;

        default:
            Console.WriteLine("Invalid Choice");
            Console.WriteLine("Please try again");
            break;
    }
}

Console.WriteLine("Good Bye!");