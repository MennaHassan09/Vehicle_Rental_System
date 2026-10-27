using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Rental_System
{
    public class Rental    //class for rental.
    {
        public string rentalld;
        private string code;
        private string customerid;
        //**********************
        private int startdays;
        private int startmonth;
        private int startyear;
        //***********************
        private int endday;
        private int endmonth;
        private int endyear;
        //**********************
        private int actualday;
        private int actualmonth;
        private int actualyear;
        //*****************


        public Rental()    //constructor to set an initial value.
        {
            rentalld = "";
            code = "";
            customerid = "";
            //**********************
            startdays = 0;
            startmonth = 0;
            startyear = 0;
            //***********************
            endday = 0;
            endmonth = 0;
            endyear = 0;
            //**********************
            actualday = 0;
            actualmonth = 0;
            actualyear = 0;



        }
        //______________________________________
        public void setrentalld(string x)   //function to set a value for rentalled.
        {
            this.rentalld = x;
        }

        public void getrentalld()
        {
            Console.WriteLine("Your code : " + this.rentalld);

        }

        //__________________________
        public void setcode(string x)   ////function to set a value for code.
        {
            this.code = x;
        }
        //___________________________
        public bool setcustomerid(string x)  //function to set a value for customer Id.
        {
            if (x.Length != 14)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter valid ID ");
                Console.ResetColor();
                return false;

            }
            else
            {
                bool f = false;
                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] >= '0' && x[i] <= '9')
                    {
                        f = false;

                    }
                    else
                    {
                        f = true;
                        break;
                    }
                }
                if (f)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter valid ID ");
                    Console.ResetColor();
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }
        //_____________________________________________
        public bool SetStartDate(int day, char a, int month, char b, int year)  //function to set the  start date.
        {

            this.startdays = day;
            this.startmonth = month;
            this.startyear = year;
            return true;




        }
        //_________________________________________-

        public bool SetEndDate(int day, char a, int month, char b, int year)  ////function to set the end date.
        {

            this.endday = day;
            this.endmonth = month;
            this.endyear = year;
            return true;



        }
        //__________________________________________
        public bool SetactualDate(int day, char a, int month, char b, int year)  ////function to set the actual date.
        {


            this.actualday = day;
            this.actualmonth = month;
            this.actualyear = year;
            return true;



        }
        //_________________________________________

        public void calculateCharge(bool late, List<Vehicle> x, int index)//function to calclate charge.
        {
            int day;
            if (late == false)
            {
                int days = endday - startdays;
                int months = endmonth - startmonth;
                int year = endyear - startyear;
                day = days + months * 30 + year * 12 * 30;
                Console.WriteLine($"The cost : {day * x[index].dailyRate}");

            }
            else
            {
                int days = actualday - endday;
                int months = actualmonth - endmonth;
                int year = actualyear - endyear;
                day = days + months * 30 + year * 12 * 30;
                Console.WriteLine($"The cost and fine for delay: {day * x[index].latecost + x[index].dailyRate}");

            }

        }
        //_______________________________________________
        public bool isLate()  ////function to check the customer is late or not.
        {
            if (this.endday == this.actualday && this.endmonth == this.actualmonth && this.endyear == this.actualyear)
            {
                return false;
            }
            else if (this.endday > this.actualday && this.endmonth == this.actualmonth && this.endyear == this.actualyear)
            {
                return false;
            }
            else
            {
                return true;
            }




        }




    }
}
