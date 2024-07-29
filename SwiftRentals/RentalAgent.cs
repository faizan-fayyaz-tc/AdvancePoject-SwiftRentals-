using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SwiftRentals
{
    public class RentalAgent
    {
        public int AgentId;
        public string AgentName;
        public CarDetails CarDetails;

        public RentalAgent()
        {
            
        }

        public RentalAgent(int id)
            :this()
        {
            AgentId = id;
        }

        public RentalAgent(int id, string name, CarDetails carDetails)
            :this(id)
        {
            AgentId=id;
            AgentName = name;
            CarDetails = carDetails;
        }

        public CarDetails AddCarToInventory()
        {
            Console.WriteLine("Enter your Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your name : ");
            string name = Console.ReadLine();
            Console.WriteLine("==============================");
            Console.WriteLine("Enter Car Model : ");
            string model = Console.ReadLine();
            Console.WriteLine("Enter Car Brand : ");
            string brand = Console.ReadLine();
            Console.WriteLine("Enter Registration Number : ");
            string registration = Console.ReadLine();
            Console.WriteLine("Enter Rental Rates : ");
            int rates = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n Car Added To The Inventory Successfully!..");
            return new CarDetails(model, brand, registration, rates);
        }

        public void DisplayCarInventory(IEnumerable<CarDetails> CarAvailability)
        {
           var displayCars = CarAvailability.Where(a => a.CarRentalRates > 100);
           if(CarAvailability != null && CarAvailability.Any())
            {
                foreach (var item in displayCars)
                {
                    Console.WriteLine($"Car Model: {item.CarModel}, Car Brand: {item.CarBrand}, Rental Rate: {item.CarRentalRates}, Registration Number: {item.CarRegistationDate}");
                }
            }
            else
            {
                Console.WriteLine("No car added yet!.");
            }
            
        }
        public async Task RemoveCarFromInventory(Inventory inventory)
        {
            Console.WriteLine("Please Enter Registration Number Of Car You Want To Delete: ");
            string userInput = Console.ReadLine();

            var removedCar = await inventory.RemoveCarFromInventory(userInput);
            if (removedCar != null)
            {
                Console.WriteLine($"Car Removed - Model: {removedCar.CarModel}, Brand: {removedCar.CarBrand}, Registration: {removedCar.CarRegistationDate}");
            }
            else
            {
                Console.WriteLine("Car not found.");
            }
        }
    }
}
