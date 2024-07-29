using SwiftRentals;
using System;

namespace SwiftRentals
{
    public class Program
    {
        static async void Main(string[] args)
        {
            RentalAgent agent = new RentalAgent();
            CarDetails carDetails = new CarDetails();
            Inventory inventory = new Inventory();
            Customer customer = new Customer();


            bool NoExit = true;

            while (NoExit)
            {
                Console.WriteLine("                     ......Welcome To Swift Rentals......                       ");
                Console.WriteLine("\n Press 1 : Rental Agent \n Press 2 : Customer \n Press 3 : Exit \n ");
                int UserInput = Convert.ToInt32(Console.ReadLine());
                switch (UserInput)
                {
                    case 1:
                        bool NoExit2 = true;
                        while (NoExit2)
                        {
                            Console.WriteLine("\n                     ......Welcome To The Agent Dashboard......                       ");
                            Console.WriteLine("\n Press 1 : Add New Car To Inventory \n Press 2 : Display Inventory \n Press 3 : Remove Car From Inventory \n Press 4 : Show Book Cars \n Press 5 : Show Available Cars for rent \n Press 6 : Exit.");
                            int CustomerInput = Convert.ToInt32(Console.ReadLine());
                            switch (CustomerInput)
                            {
                                case 1:
                                    var cardetails = agent.AddCarToInventory();
                                    inventory.AddingToInventory(cardetails);
                                    break;
                                case 2:
                                    var AvailabaleCars = inventory.GetCarDetails();
                                    agent.DisplayCarInventory(AvailabaleCars);
                                    break;
                                case 3:
                                   await agent.RemoveCarFromInventory(inventory);
                                    break;
                                case 4:
                                    customer.ShowBookCars();
                                    break;
                                case 5:
                                    inventory.ShowAvailableCars();
                                    break;
                                case 6:
                                    NoExit2 = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid Input, Try Again!..");
                                    break;
                            }
                        }
                        break;
                    case 2:
                        bool NoExit3= true;
                        while (NoExit3)
                        {
                            Console.WriteLine("\n                     ......Welcome To The Customer Dashboard......                       ");
                            Console.WriteLine("\n Press 1 : Book a Car \n Press 2 : Exit \n ");
                            int CustomerInput = Convert.ToInt32(Console.ReadLine());
                            switch (CustomerInput)
                            {
                                case 1:
                                    var AvailableCars = inventory.GetCarDetails();
                                    customer.BookCar(AvailableCars);   
                                    break;
                                case 2:
                                    NoExit3 = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid Input, Try Again!..\"");
                                    break;
                            }
                        }
                        break;
                    case 3:
                        NoExit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input, Try Again!..\"");
                        break;
                }
            }
        }
    }
}