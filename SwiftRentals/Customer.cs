using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SwiftRentals.RentalAgent;

namespace SwiftRentals
{
    public class Customer
    {
        private int _customerId;
        private string _customerName;
        private readonly List<CarDetails> _bookCars;

        Inventory inventory = new Inventory();

        public Customer()
        {
            _bookCars = new List<CarDetails>();
        }

        public Customer(int id, string name)
            :this()
        {
            _customerId = id;
            _customerName = name;
        }

        public void BookCar(IEnumerable<CarDetails> AvaialbleCars)
        {
            Console.WriteLine("Enter Customer Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Customer Name : ");
            string name = Console.ReadLine();
           
            if(AvaialbleCars != null && AvaialbleCars.Any())
            {
                Console.WriteLine("Here is the list of available cars");
                foreach (var item in AvaialbleCars)
                {
                    Console.WriteLine($"Car Model: {item.CarModel}, Car Brand: {item.CarBrand}, Rental Rate: {item.CarRentalRates}, Registration Number: {item.CarRegistationDate} \n");
                }

                Console.WriteLine("Enter Registration Number of car to book :");
                string RegistrationNumber = Console.ReadLine();

                try
                {
                    var foundedCar = AvaialbleCars.FirstOrDefault(car => car.CarRegistationDate == RegistrationNumber);

                    if (foundedCar != null)
                    {
                        Console.WriteLine("The car you have booked for rent is : ");
                        Console.WriteLine($"Car Model: {foundedCar.CarModel}, Car Brand: {foundedCar.CarBrand}, Rental Rate: {foundedCar.CarRentalRates}, Registration Number: {foundedCar.CarRegistationDate} \n");
                        _bookCars.Add(foundedCar);
                        inventory.AvailableCars.Remove(foundedCar);
                    }
                    else
                    {
                        Console.WriteLine("You have entered wrong registration number!..");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Car not founded !. An error occured while booking a car!..");
                }
            }
            else
            {
                Console.WriteLine("Sorry for our inconvenience!. There is no car currently available for you!..");
            }
        }

        public void ShowBookCars()
        {
            if(_bookCars.Count > 0)
            {
                Console.WriteLine("Here is list of all cars that are book");
                foreach (var item in _bookCars)
                {
                    Console.WriteLine($"Car Model: {item.CarModel}, Car Brand: {item.CarBrand}, Rental Rate: {item.CarRentalRates}, Registration Number: {item.CarRegistationDate} \n");
                }
            }
            else
            {
                Console.WriteLine("No book car yet!..");
            }
        }
    }
}
