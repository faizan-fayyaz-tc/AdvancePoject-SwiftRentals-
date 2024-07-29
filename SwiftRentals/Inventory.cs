using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace SwiftRentals
{
    public class Inventory
    {
        private int _carId;
        private readonly List<CarDetails> _carDetails;
        public readonly List<CarDetails> AvailableCars;

        public Inventory()
        {
            _carDetails = new List<CarDetails>();
            AvailableCars = new List<CarDetails>();
        }

        public void AddingToInventory(CarDetails carDetails)
        {
            _carDetails.Add(carDetails);
            AvailableCars.Add(carDetails);
        }

        public IEnumerable<CarDetails> GetCarDetails()
        {
            return _carDetails;
        }

        public async Task<CarDetails> RemoveCarFromInventory(string registrationNumber)
        {
            await Task.Delay(500);
            var carToRemove = _carDetails.FirstOrDefault(car => car.CarRegistationDate == registrationNumber);
            if (carToRemove != null)
            {
                _carDetails.Remove(carToRemove);
                Console.WriteLine($"Car with registration number {registrationNumber} removed successfully.");
            }
            else
            {
                Console.WriteLine($"Car with registration number {registrationNumber} not found.");
            }
            return carToRemove;
        }
        
        public void ShowAvailableCars()
        {
            if(AvailableCars.Count > 0)
            {
                foreach (var item in AvailableCars)
                {
                    Console.WriteLine($"Car Model: {item.CarModel}, Car Brand: {item.CarBrand}, Rental Rate: {item.CarRentalRates}, Registration Number: {item.CarRegistationDate} \n");
                }
            }
            else
            {
                Console.WriteLine("All cars are book!..");
            }
        }
        
    }
}
