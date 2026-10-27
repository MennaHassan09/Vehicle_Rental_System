using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Rental_System
{
    public class Vehicle    // class for vehicle.
    {
        public string vehicleId;
        public string makeModel;
        public string type;
        public string status;
        public double dailyRate;
        public int lastServiceDay;
        public int lastServiceMonth;
        public int lastServiceYear;
        //************************
        public int availableDay;
        public int availableMonth;
        public int availableYear;
        public int latecost;

        //______________________________________
        public int setlatecost()    //function to set value for late cost.
        {
            string latecost;

            while (true)
            {
                bool f = false;
                latecost = Console.ReadLine();
                for (int i = 0; i < latecost.Length; i++)
                {
                    if (latecost[i] < '0' || latecost[i] > '9')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("please enter valid fine .");
                        Console.ResetColor();
                        f = true;
                        break;


                    }
                }
                if (f == false)
                {
                    this.latecost = int.Parse(latecost);
                    return this.latecost;

                }

            }
        }
        //___________________________________


        public void setVehicleId(string code)  //function to set value for vehicle Id.
        {
            this.vehicleId = code;

        }
        //____________________________________
        public void setmakeModel(string model)  //function to set value for make model.
        {
            this.makeModel = model;

        }
        //-----------------------------------
        public void settype(string type)   //function to set value for type.
        {

            this.type = type;
        }
        //__________________________________-
        public void setstatus(string status)  //function to set value for type.
        {

            this.status = status;
        }
        //_______________________________________
        public bool setdailyRate(string dailyRate)   //function to set value for daily rate.
        {
            for (int i = 0; i < dailyRate.Length; i++)
            {
                if (char.IsDigit(dailyRate[i]) == false && dailyRate[i] != ',')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("please enter valid number .");
                    Console.ResetColor();
                    return false;
                }

            }
            this.dailyRate = double.Parse(dailyRate);
            return true;
        }
        //___________________________________________
        public bool setlastdate(int day, int month, int year)  //function to set value for last date.
        {


            this.lastServiceDay = day;
            this.lastServiceMonth = month;
            this.lastServiceYear = year;
            return true;
        }
        //_______________________________________________
        public bool setavailable(string day, string month, string year)  //function to set value for  available date. 
        {
            if (int.Parse(day) > 30 || int.Parse(month) > 12 || int.Parse(year) > 2025)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("please enter valid date.");
                Console.ResetColor();
                return false;
            }
            for (int i = 0; i < day.Length; i++)
            {
                if (char.IsDigit(day[i]) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("please enter valid date .");
                    Console.ResetColor();
                    return false;
                }
            }
            for (int i = 0; i < month.Length; i++)
            {
                if (char.IsDigit(month[i]) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("please enter valid date .");
                    Console.ResetColor();
                    return false;
                }
            }
            for (int i = 0; i < year.Length; i++)
            {
                if (char.IsDigit(year[i]) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("please enter valid date .");
                    Console.ResetColor();
                    return false;
                }
            }

            this.availableDay = int.Parse(day);
            this.availableMonth = int.Parse(month);
            this.availableYear = int.Parse(year);
            return true;
        }
        //______________________________________________


        public void Display()   //function to Display the vehicles.
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
            Console.WriteLine("                        ** Vehicle Details **");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("                             Vehicle Id: " + "   ----->" + vehicleId);
            Console.WriteLine("                             Model: " + "        ----->" + makeModel);
            Console.WriteLine("                             Type: " + "         ----->" + type);
            Console.WriteLine("                             Status: " + "       ----->" + status);
            Console.WriteLine("                             Daily Rate: " + "   ----->" + dailyRate);
            Console.WriteLine("                             Last Service: " + " ----->" + lastServiceDay + "/" + lastServiceMonth + "/" + lastServiceYear);
        }
        //________________________________________________

        public bool MarkMaintenance(string d, string m, string y) //function to Mark Maintenance. 
        {
            if (int.Parse(d) > 30 || int.Parse(m) > 12 || int.Parse(y) < 2025)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("please enter valid date . ");
                Console.ResetColor();
                return false;
            }
            for (int i = 0; i < d.Length; i++)
            {
                if (d[i] < '0' || d[i] > '9')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("please enter valid date .");
                    Console.ResetColor();
                    return false;
                }
            }
            for (int i = 0; i < m.Length; i++)
            {
                if (m[i] < '0' || m[i] > '9')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("please enter valid date .");
                    Console.ResetColor();
                    return false;
                }
            }
            for (int i = 0; i < y.Length; i++)
            {
                if (y[i] < '0' || y[i] > '9')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("please enter valid date .");
                    Console.ResetColor();
                    return false;
                }
            }

            status = "maintenance";
            lastServiceDay = int.Parse(d);
            lastServiceMonth = int.Parse(m);
            lastServiceYear = int.Parse(y);
            return true;



        }
        //____________________________________________

        public bool IsAvailable() //function to check the vehicle is available or not.
        {
            if (status == "available")
            {
                Display();
                return true;
            }
            else
                return false;
        }
    }
}
