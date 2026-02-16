using System;
using Domain;
using Services;

namespace ConsoleApp
{
    class Program
    {
        public static void Main()
        {
            Medicine medi = new Medicine();
            MedicineUtility medicineUtility = new MedicineUtility();

            while (true)
            {
                Console.WriteLine("1. Display All medicine");
                Console.WriteLine("2. Update medicine Price");
                Console.WriteLine("3. Add medicine");
                Console.WriteLine("4. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        medicineUtility.GetAllMedicine();
                        break;
                    case 2:
                        Console.WriteLine("Enter the medicine id");
                        string id = Console.ReadLine();
                        Console.WriteLine("Enter the new price");
                        int price = Convert.ToInt32(Console.ReadLine());
                        medicineUtility.UpdateMedicinePrice(id, price);
                        break;
                    case 3:
                        string[] input = Console.ReadLine().Split(' ');

                        Medicine med = new Medicine
                        {
                            Id = input[0],
                            Name = input[1],
                            Price = int.Parse(input[2]),
                            ExpiryYear = int.Parse(input[3])
                        };
                        medicineUtility.AddMedicine(med);
                        break;

                    case 4:
                        return;
                    default:
                        Console.WriteLine("Enter valid date");
                        break;
                }
            }
        }
    }
}
