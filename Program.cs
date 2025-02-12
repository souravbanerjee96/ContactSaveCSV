using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ContactSaveCSV;
using System.Drawing;


class Program
{
    public static void Main()
    {
        //make console color green
        ContactManager contactManager = new();
        Console.ForegroundColor = ConsoleColor.DarkCyan;

        //menu driven program
        Console.WriteLine(
            "1. Add Contact\n" +
            "2. Delete Contact\n" +
            "3. Update Contact\n" +
            "4. List All Contacts\n" +
            "5. List All Contacts sorted by name\n" +
            "6. Exit\n"
        );
        while (true)
        {
            Console.WriteLine();
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine() ?? string.Empty;
            switch (choice)
            {
                case "1":
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine() ?? string.Empty;
                    Console.Write("Enter Phone Number: ");
                    string phoneNo = Console.ReadLine() ?? string.Empty;
                    Console.Write("Enter Email: ");
                    string email = Console.ReadLine() ?? string.Empty;
                    contactManager.AddContact(name, phoneNo, email);
                    break;
                case "2":
                    Console.Write("Enter Id: ");
                    int id = int.Parse(Console.ReadLine() ?? "0");
                    contactManager.DeleteContact(id);
                    break;
                case "3":
                    Console.Write("Enter Id: ");
                    int id1 = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Enter Name: ");
                    string name1 = Console.ReadLine() ?? string.Empty;
                    Console.Write("Enter Phone Number: ");
                    string phoneNo1 = Console.ReadLine() ?? string.Empty;
                    Console.Write("Enter Email: ");
                    string email1 = Console.ReadLine() ?? string.Empty;
                    contactManager.UpdateContact(id1, name1, phoneNo1, email1);
                    break;
                case "4":
                    contactManager.GetAllContacts();
                    break;
                case "5":
                    contactManager.GetAllContactsSortedByName();
                    break;
                case "6":
                    //close window

                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}
