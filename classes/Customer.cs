using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Rental_System
{
    class Customer        // Class for customers.
    {
        private string customerId;
        private string name;
        private string licenseNumber;
        private List<Rental> currentRentals;
        //______________________________________
        public Customer()        // constructor for set an initial value 
        {
            name = ReadName();
            customerId = ReadCustomerId();

            licenseNumber = ReadLicenseNumber();
            currentRentals = new List<Rental>();

        }
        //_______________________________

        private string ReadCustomerId()  // function to set value for Id.
        {

            while (true)
            {
                Console.Write("Enter Customer ID : ");
                try
                {
                    string id = Console.ReadLine();
                    if (id.Length > 0 && id.Length == 14)
                    {
                        return id;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ID must be a positive number and 14 Digits . ");
                        Console.ResetColor();
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("invalid input!");
                    Console.ResetColor();

                }

            }

        }
        //_______________________________________

        private string ReadName()  // function to set value for name.
        {

            while (true)
            {
                Console.Write("Enter Customer Name : ");
                string name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    return name;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Name!");
                    Console.ResetColor();
                }
            }
        }
        //____________________________________-
        private string ReadLicenseNumber()    // function to set value for License .
        {
            while (true)
            {
                Console.Write("Enter License Number : ");
                string LicenseNumber = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(LicenseNumber))
                {
                    return LicenseNumber;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("License Number cannot be Empty!");
                    Console.ResetColor();
                }
            }

        }
        //________________________________________________________
        // function for request rental.
        public void RequestRental(List<Vehicle> v, Rental[] r, int startDay, int startMonth, int startYear, int endDay, int endMonth, int endYear)
        {

            bool f = true;
            for (int i = 0; i < v.Count; i++)
            {
                if (v[i].IsAvailable() == true)
                {
                    r[i].setcode(v[i].vehicleId);

                    r[i].setcustomerid(this.customerId.ToString());
                    r[i].setrentalld("R" + new Random().Next(1000, 9999));
                    r[i].getrentalld();

                    r[i].SetStartDate(startDay, '/', startMonth, '/', startYear);
                    r[i].SetEndDate(endDay, '/', endMonth, '/', endYear);

                    v[i].status = "rented";
                    // r.Add(r[i]);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Rental created to {name}(ID {customerId})");
                    Console.WriteLine($"Vehicle {v[i].makeModel},from ({startDay}/{startMonth}/{startYear}) to ({endDay}/{endMonth}/{endYear})");
                    Console.ResetColor();
                    f = false;
                    break;
                }
            }
            if (f)
            {
                Console.WriteLine("No vehcile is available . ");
            }

        }
        //_____________________________________________
        //function to return vehicle.
        public void ReturnVehicle(List<Vehicle> v, Rental[] r, int actualDay, int acualMonth, int acualYear, string rentalled)
        {
            int index = 0;
            for (int i = 0; i < r.Length; i++)
            {
                if (rentalled == r[i].rentalld)
                {
                    index = i;
                    break;
                }
            }
            r[index].SetactualDate(actualDay, '/', acualMonth, '/', acualYear);
            v[index].status = "available";

            bool late = r[index].isLate();
            r[index].calculateCharge(late, v, index);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Vehicle {v[index].makeModel} returned successfully by {name}.");
            Console.ResetColor();
        }

    }
}
