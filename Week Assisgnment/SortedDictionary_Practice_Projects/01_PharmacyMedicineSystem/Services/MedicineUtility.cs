using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class MedicineUtility
    {
        private SortedDictionary<int, List<Medicine>> _Medicines = new SortedDictionary<int, List<Medicine>>();

        public void AddMedicine(Medicine medicine)
        {

            if (_Medicines.ContainsKey(medicine.ExpiryYear))
            {
                _Medicines[medicine.ExpiryYear].Add(medicine);
            }
            else
            {
                _Medicines[medicine.ExpiryYear] = new List<Medicine>{medicine};
            }
        }


        public void GetAllMedicine()
        {
            foreach(var item in _Medicines)
            {
                Console.WriteLine(item.Key);
                foreach (var x in item.Value)
                {
                    Console.WriteLine($"{x.Id} {x.Name} {x.Price} {x.ExpiryYear}");
                }
                Console.WriteLine();
                
            }
            
        }

        public void UpdateMedicinePrice(string id, int newPrice)
        {
            foreach (var item in _Medicines)
            {
                foreach (var x in item.Value)
                {
                    if (x.Id == id)
                    {
                        x.Price = newPrice;
                    }
                    return;
                }
            }

        }

    }
}

