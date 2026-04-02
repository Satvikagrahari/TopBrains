// E‑Commerce: Order Intake Manager
// Arjun manages a busy online store where new customer orders arrive constantly. He prefers to review the most recent orders first. Utilise your C# programming skills to help Arjun track each order as it is received and process them in reverse order of arrival using a Stack. Provide functionality to add new orders, get the most recent order, and remove it when processed.
// Functionalities:
// In class Program, implement the below given public static property.
// Data Type
	
// Property Name
// Stack<Order>
	
// OrderStack
// In class Order, implement the below given properties and methods.
// Data Type
	
// Property Name


// int
	
// OrderId


// string
	
// CustomerName


// string
	
// Item
 
// Method
	
// Description


// public Stack<Order> AddOrderDetails(int orderId, string customerName, string item)
	
// Add the order details to OrderStack and return it.


// public string GetOrderDetails()
	
// Get the most recently added order details from OrderStack and return them as a string separated by one space.


// Format: OrderId" "CustomerName" "Item
	 

// public Stack<Order> RemoveOrderDetails()
	
// Remove the most recently added order from OrderStack and return the remaining stack.

// In Program class - Main method,
// Get the values from the user.
// Call the methods accordingly and display the result as per the Sample Output.
// Note:
// Keep the methods and classes as public.
// Please read the method rules clearly.
// Do not use Environment.Exit() to terminate the program.
// Do not change the given code template.
// Summary:
// This task reinforces working with the generic collection Stack<T> in C#, which represents a last-in, first-out (LIFO) collection.

using System;
public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public string Item { get; set; }
    
}
class Program
{
    public static Stack<Order> OrderStack = new Stack<Order>();
    public static Stack<Order> AddOrderDetails(int orderId, string customerName, string item)
    {
        Order order = new Order();
        order.OrderId= orderId;
        order.CustomerName = customerName;
        order.Item = item;
        Program.OrderStack.Push(order);
        return Program.OrderStack;
    }
    public static string GetOrderDetails()
    {
      
        if (Program.OrderStack.Count == 0)
        {
            return "No items available";
        }
       
        var order = Program.OrderStack.Peek();
        return $"{order.OrderId} {order.CustomerName} {order.Item}";
    }
    public static Stack<Order> RemoveOrderDetails()
    {
        if (Program.OrderStack.Count == 0)
        {
            System.Console.WriteLine("No items available");
        }
        else
        {
            Program.OrderStack.Pop();
        }        
        return Program.OrderStack;
    }
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. Add Order");
            Console.WriteLine("2. Get Most Recent Order");
            Console.WriteLine("3. Remove Most Recent Order");
            Console.WriteLine("4. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter OrderId: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Enter Customer Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Item: ");
                    string item = Console.ReadLine();

                    AddOrderDetails(id, name, item);
                    Console.WriteLine("Order Added Successfully");
                    break;

                case 2:
                    Console.WriteLine(GetOrderDetails());
                    break;

                case 3:
                    RemoveOrderDetails();
                    Console.WriteLine("Order Removed");
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }


    }
}