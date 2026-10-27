using System;
using System.Numerics;

using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics.Eventing.Reader;
using Microsoft.Win32;
using System.Xml.Serialization;
using System.Threading;

namespace Vehicle_Rental_System

{
    class Program
    {
        static void WelcomePage()     //welcome page.
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                         ====================================");
            Console.WriteLine("                         ------> Welcome to Our System <------ ");
            Console.WriteLine("                         ====================================");
            Console.WriteLine();
            Console.WriteLine(" Press any key to continue ...");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
        //______________________________________
        static void ShowMenu()   // function to show a menu.
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                                 ========== Vehicle Rental System ==========");
            Console.WriteLine("                                 ║     1. Add Vehicle                      ║");
            Console.WriteLine("                                 ║     2. View All Vehicles                ║");
            Console.WriteLine("                                 ║     3. View the maintenance of vehicles.║");
            Console.WriteLine("                                 ║     4. Check Vehicle Availability       ║");
            Console.WriteLine("                                 ║     5. Exit                             ║");
            Console.WriteLine("                                 ===========================================");
            Console.ResetColor();
        }
        //_______________________________________
        static void showmenu2()// function to show a menu.
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("           =========================             ");
            Console.WriteLine("           ║        1- admain.     ║             ");
            Console.WriteLine("           ║        2- customer.   ║              ");
            Console.WriteLine("           =========================              ");
            Console.ResetColor();

        }
        //____________________________________
        static void showmenu3()// function to show a menu.
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("      ===========================     ");
            Console.WriteLine("      ║      1- To sign in .    ║     ");
            Console.WriteLine("      ║      2- To log in .     ║     ");
            Console.WriteLine("      ===========================     ");
            Console.ResetColor();

        }
        //________________________________
        static void showmenu4()// function to show a menu.
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("    ======================    ");
            Console.WriteLine("    ║    1- To rent .    ║    ");
            Console.WriteLine("    ║    2- To return .  ║    ");
            Console.WriteLine("    ======================     ");
            Console.ResetColor();
        }
        //_________________________________
        static void AddVehicle()// function to Add vehicle.
        {
            Vehicle car = new Vehicle();
            Console.Write("Enter Vehicle Id: ");
            car.vehicleId = Console.ReadLine();

            Console.Write("Enter Model: ");
            car.makeModel = Console.ReadLine();
            while (true)
            {
            ReadModel:
                if (car.makeModel.All(char.IsLetter))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("car model must contain letters, Try again.");
                    Console.ResetColor();
                    car.makeModel = Console.ReadLine();
                    goto ReadModel;
                }
            }

            Console.Write("Enter Type (Car/Bike/Van/Bus): ");
            car.type = Console.ReadLine();
            while (true)
            {
            Readtype:
                if (car.type.ToLower() == "car" || car.type.ToLower() == "bike" || car.type.ToLower() == "van" || car.type.ToLower() == "bus")
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("type must be Car , Bike , Van , Bus .. Try Again");
                    Console.ResetColor();
                    car.type = Console.ReadLine();
                    goto Readtype;
                }
            }

            Console.Write("Enter Status (available/rented): ");
            car.status = Console.ReadLine();

            while (true)
            {
            Readstatus:
                if (car.status.ToLower() == "available" || car.status.ToLower() == "rented")
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("type must be available , rented .. Try Again");
                    Console.ResetColor();
                    car.status = Console.ReadLine();
                    goto Readstatus;
                }
            }

            while (true)
            {
                Console.Write("Enter Daily Rate: ");
                string Rate = Console.ReadLine();
                if (double.TryParse(Rate, out double rate) && rate > 0)
                {
                    car.dailyRate = rate;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Daily Rate must be a positive number... Try again");
                    Console.ResetColor();
                }
            }
            Console.Write("Enter Late cost : ");
            car.setlatecost();

            while (true)
            {
                Console.Write("Enter Last Service Day: ");
                string day = Console.ReadLine();
                if (int.TryParse(day, out int Day) && Day > 0 && Day < 32)
                {
                    car.lastServiceDay = Day;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Last service Day must between 1 & 31... Try again");
                    Console.ResetColor();
                }
            }

            while (true)
            {
                Console.Write("Enter Last Service Month: ");
                string month = Console.ReadLine();
                if (int.TryParse(month, out int Month) && Month > 0 && Month < 13)
                {
                    car.lastServiceMonth = Month;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Last service Month must between 1 & 12... Try again");
                    Console.ResetColor();
                }
            }

            while (true)
            {
                Console.Write("Enter Last Service Year: ");
                string year = Console.ReadLine();
                if (int.TryParse(year, out int Year) && Year >= 2000 && Year <= 2025)
                {
                    car.lastServiceYear = Year;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Last service Year must between 2000 & 2025... Try again");
                    Console.ResetColor();
                }
            }
            vehicles.Add(car);
            Console.WriteLine("               Vehicle Added Successfully     ");
        }
        //____________________________________

        public static int checknum()   //function to check the number is valid or not.
        {
        f:
            int x;
            try
            {

                x = int.Parse(Console.ReadLine());

            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("please enter valid number.");
                Console.ResetColor();
                goto f;

            }
            return x;

        }
        //______________________________________
        static void DisplayAll()   //function to display the vehicles.
        {
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles found!");
                return;
            }

            foreach (var v in vehicles)
            {
                v.Display();
            }
        }
        //________________________________________
        public static int checkchoice(int l, int r) //function to check the choice in renge or not.
        {
            int x = 0;
            bool e = false;
            while (e != true)
            {

                x = checknum();
                if (x >= l && x <= r)
                {
                    e = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("please enter valid choice . ");
                    Console.ResetColor();
                }

            }
            return x;

        }
        //_____________________________________

        public static int checkday()  // function to check the day in range or not .

        {
            int d;
        s:
            try
            {
                d = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The Day Must between 1 && 31 ....Try again .");
                Console.ResetColor();
                goto s;
            }
            if (d > 31)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The Day Must between 1 && 31 ....Try again .");
                Console.ResetColor();
                goto s;
            }

            return d;


        }
        //____________________________________________
        public static int checkmonth()  // function to check the month in range or not .

        {
            int d;
        s:
            try
            {
                d = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The Month Must between 1 && 12 ....Try again .");
                Console.ResetColor();
                goto s;
            }
            if (d > 12)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The Month Must between 1 && 12 ....Try again .");
                Console.ResetColor();
                goto s;
            }

            return d;




        }
        //_________________________________________
        public static int checkYear()// function to check the year in range or not .

        {
            int d;
        s:
            try
            {
                d = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The Year Must be more than 2024 ....Try again .");
                Console.ResetColor();
                goto s;
            }
            if (d < 2024)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The Year Must be more than 2024 ....Try again .");
                Console.ResetColor();
                goto s;
            }

            return d;


        }
        //___________________________________________



        static void available(List<Vehicle> vehicles, int d, int m, int y)// function to check the vehicles is available or not.
        {
            bool f = false;
            for (int i = 0; i < vehicles.Count; i++)
            {
                if (vehicles[i].status == "available" && vehicles[i].availableDay == d && vehicles[i].availableMonth == m && vehicles[i].availableYear == y)
                {
                    vehicles[i].Display();
                    f = true;
                }


            }
            if (f == false)
            {
                Console.WriteLine("Sorry , No car is available");
            }

        }
        //@@@@@@@@@@@@@@ Main @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        static List<Vehicle> vehicles = new List<Vehicle>();
        static Rental[] rentals = new Rental[20000];
        static void Main(string[] args)
        {
            WelcomePage();
            admain[] admains = new admain[20000];

            Customer[] customers = new Customer[200000];

            for (int i = 0; i < 20000; i++)
            {
                rentals[i] = new Rental();
                admains[i] = new admain();


            }
            //_____________________________________
            for (int i = 0; i < 20000; i++)
            {

                showmenu2();

                Console.Write("Your choice : ");
                int choice = checkchoice(1, 2);

                switch (choice)
                {

                    case 1:

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Hello ,our dear admain.");
                        showmenu3();
                        Console.WriteLine("Your choice : ");
                        int choice2 = checkchoice(1, 2);

                        if (choice2 == 1)
                        {

                            Console.Write("please enter username : ");
                            string user = "";
                            do
                            {
                                user = Console.ReadLine();

                            } while (admains[i].SetUserName(user) != true);
                            Console.Write("please enter password : ");
                            string password = "";
                            do
                            {
                                password = Console.ReadLine();

                            } while (admains[i].SetPassword(password) != true);



                            string user1;
                            string password1;

                            do
                            {
                                Console.Write("please enter username to login : ");
                                user1 = Console.ReadLine();
                                Console.Write("please enter your password to login : ");
                                password1 = Console.ReadLine();
                            } while (admains[i].LogIn(user1, password1, i) != true);



                        }
                        else
                        {
                            Console.Write("please enter your number : ");
                            int num = checknum();
                            num--;
                            string user1;
                            string password1;

                            do
                            {
                                Console.Write("please enter username to login : ");
                                user1 = Console.ReadLine();
                                Console.Write("please enter your password to login : ");
                                password1 = Console.ReadLine();
                            } while (admains[i].LogIn(user1, password1, i) != true);



                        }
                    Start:
                        ShowMenu();
                        Console.Write("Your Choice : ");
                        int q = checkchoice(1, 4);

                        switch (q)
                        {
                            case 1:
                                AddVehicle();
                                break;
                            case 2:
                                DisplayAll();
                                break;
                            case 3:
                                Console.Write("This Day : ");
                                int d = checkday();
                                Console.Write("This Month : ");
                                int m = checkmonth();
                                Console.Write("This Yeard : ");
                                int y = checkYear();
                                admains[i].VeiwMaintenanceAlerts(vehicles, d, m, y);
                                break;
                            case 4:
                                Console.Write("The Day You want to rent : ");
                                int day = checkday();
                                Console.Write("The Month You want to rent : ");
                                int month = checkmonth();
                                Console.Write("The Year You want to rent : ");
                                int year = checkYear();
                                available(vehicles, day, month, year);
                                break;
                            case 5:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("Exiting program... BYE");
                                Console.ResetColor();
                                return;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid choice .. Please try again");
                                Console.ResetColor();
                                break;
                        }
                        break;

                    case 2:
                        Console.WriteLine("go case 2");
                        //  rentals[i] = new Rental();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Hello ,our dear customer .");
                        Console.ResetColor();
                        Console.WriteLine();

                        customers[i] = new Customer();
                        showmenu4();
                        Console.Write("Your choice : ");
                        int choice3 = checkchoice(1, 2);

                        if (choice3 == 1)
                        {

                            int startday = 0, startmonth = 0, startyear = 0;
                            int endday = 0, endmonth = 0, endyear = 0;



                            Console.Write("The Day you want to rent : ");
                            startday = checkday();
                            Console.Write("The Month you want to rent : ");
                            startmonth = checkmonth();
                            Console.Write("The Year you want to rent : ");
                            startyear = checkYear();
                            rentals[i].SetStartDate(startday, '/', startmonth, '/', startyear);


                            Console.Write("The Day you want to return : ");
                            endday = checkday();
                            Console.Write("The Day you want to return : ");
                            endmonth = checkmonth();
                            Console.Write("The Day you want to return : ");
                            endyear = checkYear();
                            rentals[i].SetEndDate(endday, '/', endmonth, '/', endyear);

                            customers[i].RequestRental(vehicles, rentals, startday, startmonth, startyear, endday, endmonth, endyear);


                        }
                        else
                        {
                            int index = 0;
                            Console.Write("Please enter your code : ");
                        Code:
                            bool f = false;
                            string code = Console.ReadLine();
                            for (int p = 0; p < vehicles.Count; p++)
                            {
                                if (code == rentals[p].rentalld)
                                {
                                    index = p;
                                    f = true;
                                    break;
                                }


                            }
                            if (f == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("No Vehicle has this Id ..... Try again.");
                                Console.ReadLine();
                                goto Code;

                            }
                            Console.Write("The Day you return this vehicle : ");
                            int d = checkday();
                            Console.Write("The month you return this vehicle : ");
                            int m = checkmonth();
                            Console.Write("The Year you return this vehicle : ");
                            int y = checkYear();
                            customers[i].ReturnVehicle(vehicles, rentals, d, m, y, vehicles[index].vehicleId);

                        }
                        break;
                }
            }

        }
    }
}





