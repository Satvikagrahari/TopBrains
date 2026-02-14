using System;

namespace BookStoreApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO:
            // 1. Read initial input
            // Format: BookID Title Price Stock

            Book book = new Book();

            BookUtility utility = new BookUtility(book);
            string input = Console.ReadLine();
            string[] inputarr = input.Split(" ");
            book.Id = inputarr[0];
            book.Title = inputarr[1];
            book.Price = int.Parse(inputarr[2]);
            book.Stock = int.Parse(inputarr[3]);

            while (true)
            {
                // TODO:
                // Display menu:
                // 1 -> Display book details
                // 2 -> Update book price
                // 3 -> Update book stock
                // 4 -> Exit

                int choice = int.Parse(Console.ReadLine()); // TODO: Read user choice

                switch (choice)
                {
                    case 1:
                        utility.GetBookDetails();
                        break;

                    case 2:
                        // TODO:
                        // Read new price
                        // Call UpdateBookPrice()
                        int newprice = int.Parse(Console.ReadLine());
                        utility.UpdateBookPrice(newprice);
                        break;

                    case 3:
                        // TODO:
                        // Read new stock
                        // Call UpdateBookStock()
                        int newstock = int.Parse(Console.ReadLine());
                        utility.UpdateBookStock(newstock);
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}
