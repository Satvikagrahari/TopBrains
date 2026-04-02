using System;
using Services;
using Domain;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SupportUtility service = new SupportUtility();

            while (true)
            {
                Console.WriteLine("\n1. Display Ticket");
                Console.WriteLine("2. Add Ticket");
                Console.WriteLine("3. Escalate Ticket");
                Console.WriteLine("4. Exit");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            service.DisplayTicket();
                            break;

                        case 2:
                            Console.Write("TicketId: ");
                            string id = Console.ReadLine();

                            Console.Write("IssueDescription: ");
                            string desc = Console.ReadLine();

                            Console.Write("SeverityLevel: ");
                            int severity = int.Parse(Console.ReadLine());

                            SupportTicket tkt = new SupportTicket
                            {
                                TicketId = id,
                                IssueDiscription = desc,
                                SeverityLevel = severity
                            };

                            service.AddTicket(tkt);
                            break;

                        case 3:
                            Console.Write("Enter TicketId to Escalate: ");
                            string escId = Console.ReadLine();
                            service.EscalateTicket(escId);
                            break;

                        case 4:
                            Console.WriteLine("Thank You");
                            return;

                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
