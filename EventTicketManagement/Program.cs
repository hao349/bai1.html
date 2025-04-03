using System;
using EventTicketManagement.Models;
using EventTicketManagement.Services;

class Program
{
    static void Main()
    {
        TicketManager manager = new();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== EVENT TICKET MENU ===");
            Console.WriteLine("1. Add Event Ticket / VIP Ticket");
            Console.WriteLine("2. View All Tickets");
            Console.WriteLine("3. Update Ticket");
            Console.WriteLine("4. Delete Ticket");
            Console.WriteLine("5. Calculate Total Cost");
            Console.WriteLine("6. Exit");
            Console.Write("Your choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    try
                    {
                        Console.Write("Enter Ticket ID: ");
                        int id = int.Parse(Console.ReadLine()!);
                        Console.Write("Event Name: ");
                        string name = Console.ReadLine()!;
                        Console.Write("Ticket Price: ");
                        float price = float.Parse(Console.ReadLine()!);
                        Console.Write("Quantity: ");
                        int quantity = int.Parse(Console.ReadLine()!);
                        Console.Write("Event Date (yyyy-MM-dd): ");
                        DateTime date = DateTime.Parse(Console.ReadLine()!);
                        Console.Write("VIP Ticket? (y/n): ");
                        bool isVip = Console.ReadLine()!.ToLower() == "y";

                        EventTicket ticket = isVip
                            ? new VIPEventTicket(id, name, price, quantity, date)
                            : new EventTicket(id, name, price, quantity, date);

                        manager.AddTicket(ticket);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    break;

                case "2": manager.ViewTickets(); break;
                case "3":
                    Console.Write("Enter Ticket ID: ");
                    manager.UpdateTicket(int.Parse(Console.ReadLine()!), float.Parse(Console.ReadLine()!), int.Parse(Console.ReadLine()!));
                    break;
                case "4":
                    Console.Write("Enter Ticket ID: ");
                    manager.DeleteTicket(int.Parse(Console.ReadLine()!));
                    break;
                case "5":
                    Console.Write("Enter Ticket ID: ");
                    manager.CalculateTotalCost(int.Parse(Console.ReadLine()!));
                    break;
                case "6": running = false; break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }
}
