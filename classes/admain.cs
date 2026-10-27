using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Rental_System
{
    public class admain     //class for admain.
    {
        private string userName;
        private string password;
        //***************************************

        public admain()   //constructor for set an initial value.
        {
            userName = "";
            password = "";
        }
        //____________________________________________
        public bool SetUserName(string x)  //function to set value for user name.
        {
            if (x.Length < 8)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Name Must be more than 8 chars ");
                Console.ResetColor();
                return false;
            }
            else
            {
                userName = x;
                return true;
            }
        }
        //_______________________________________
        public bool SetPassword(string y)//function to set value for password.
        {
            if (y.Length >= 8)
            {
                password = y;
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("please enter password has at least 8 chars");
                Console.ResetColor();
                return false;
            }
        }
        //_______________________________________________
        public bool LogIn(string x, string y, int index)  //function to log in.
        {
            if (x == userName)
            {
                if (y == password)
                {

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($" ****** WELCOME {userName}******");
                    Console.WriteLine($"Your turn : {index} ");
                    Console.ResetColor();
                    Console.WriteLine();
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("please enter valid password ");
                    Console.ResetColor();
                    return false;
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("please enter valid user name ");
                if (y != password)
                {

                    Console.WriteLine("please enter valid password ");

                }
                Console.ResetColor();

                return false;
            }

        }
        //_________________________________________
        //function to Add vehicle.
        public void AddVehicle(Vehicle x, string code, string model, string type, string status, string availableday, string availablemonth, string availableyear, string dailyRate, int lastServiceday, int lastServicemonth, int lastServiceyear)
        {

            x.setVehicleId(code);
            x.setmakeModel(model);
            x.settype(type);
            x.setstatus(status);
            x.setavailable(availableday, availablemonth, availableyear);
            x.setdailyRate(dailyRate);
            x.setlastdate(lastServiceday, lastServicemonth, lastServiceyear);
        }
        //_________________________________________
        public void GetVehicle(Vehicle x) //function to Display the vehicles.
        {

            Console.WriteLine($"Model :{x.makeModel} \nCode : {x.vehicleId} \nType : {x.type}\nStatus : {x.status}\nDaily rate : {x.dailyRate}\nLast service date : {x.lastServiceDay}/{x.lastServiceMonth}/{x.lastServiceYear}");

        }
        //______________________________________
        public void available(List<Vehicle> cars, int day, int month, int year)//function to check the vehicle is available or not. 
        {

            bool f = false;
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].status == "available" && cars[i].availableDay == day && cars[i].availableMonth == month && cars[i].availableYear == year)
                {
                    cars[i].Display();
                    f = true;
                }


            }
            if (f == false)
            {
                Console.WriteLine("Sorry , No car is available");
            }
        }
        //_______________________________
        // function to Veiw Maintenance Alerts.
        public bool VeiwMaintenanceAlerts(List<Vehicle> cars, int thisday, int thismonth, int thisyear)
        {

            for (int i = 0; i < cars.Count; i++)
            {
                int day = Math.Abs(cars[i].lastServiceDay - thisday) + Math.Abs(cars[i].lastServiceMonth - thismonth) * 30 + Math.Abs(cars[i].lastServiceYear - thisyear) * 12 * 30;
                if (day > 90)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Vehicle {cars[i].makeModel} needs maintenance . ");
                    Console.ResetColor();
                    cars[i].setlastdate(thisday, thismonth, thisyear);

                }


            }

            return true;
        }

    }
}
