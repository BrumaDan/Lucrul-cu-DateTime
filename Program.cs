using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHomework
{
    class Program
    {
        enum Gender { 
            Male,
            Female
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your birth year");
            int birthYear = GetValidYear();

            Console.WriteLine("Enter your birth month");
            int birthMonth = GetValidMonth();

            Console.WriteLine("Enter your birth day");
            int birthDay = GetValidDay(birthYear, birthMonth);

            DateTime birthDate = new DateTime(birthYear, birthMonth, birthDay);
            DateTime currentDate = DateTime.Now;
            TimeSpan userAge = currentDate.Subtract(birthDate);
            int daysInYear = 365;

            Console.WriteLine($"Today's date is {currentDate.ToString("D")}");
            Console.WriteLine($"Your Birthdate is {birthDate.ToString("D")}");
            Console.WriteLine($"Your age is {(int)userAge.TotalDays / daysInYear} years");

            int age = int.Parse((userAge.Days/ daysInYear).ToString());

            Gender? userGender= null;
            SetGender(ref userGender);

            Console.WriteLine($"User is {userGender}");

            if (userGender != null)
            {
                GetRetirementInformations(userGender,age);
            }
        
    }
        static void GetRetirementInformations(Gender? gender, int age)

        {
            if (gender == Gender.Female)
            {
                GetFemaleRetirement(age);
            }
            else
            {
                GetMaleRetirement(age);
            }
        }

        static void GetFemaleRetirement(int age)
        {
            int femaleLegalRetirementAge = 63;
            if (age > femaleLegalRetirementAge)
            {
                Console.WriteLine($"User is retired for {age - femaleLegalRetirementAge} years");
            }
            else if (age < femaleLegalRetirementAge)
            {
                Console.WriteLine($"User has {femaleLegalRetirementAge - age} years until retirement");
            }
            else
            {
                Console.WriteLine("User has the retirement age and will retire this year");

            }

        }

        static void GetMaleRetirement(int age)
        {
            int maleLegalRetirementAge = 65;
            if (age > maleLegalRetirementAge)
            {
                Console.WriteLine($"User is retired for {age - maleLegalRetirementAge} years");
            }
            else if (age < maleLegalRetirementAge)
            {
                Console.WriteLine($"User has {maleLegalRetirementAge - age} years until retirement");
            }
            else
            {
                Console.WriteLine("User has the retirement age and will retire this year");

            }

        }

        static void SetGender(ref Gender? gender)
        {
            Console.WriteLine("Enter your gender M-for male and  F-for female");
            string genderInput = Console.ReadLine();

            if (genderInput.ToUpper() == "M")
            {
                gender = Gender.Male;
            }else if(genderInput.ToUpper() == "F")
            {
                gender = Gender.Female;
            }
            else
            {
                gender = null;
              
            }


        }


    static int GetValidDay(int year, int month)
        {
            int result = GetValidInput();
            bool flag = true;

            while (flag)
            {
                
                if (DateTime.DaysInMonth(year, month) >= result)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"this day {result} is not valid for this year {year}, Try again");
                    result = GetValidInput();
                }
            }
            return result;
        }



        static int GetValidYear()
        {

            int result = GetValidInput();
            bool flag = true;
            while (flag)
            {
                DateTime moment = DateTime.Now;
                if (result < 1 || result > moment.Year)
                {
                    Console.WriteLine("Enter a valid year");
                    result = GetValidInput();
                }
                else
                {
                    flag = false;
                }
            }
            return result;
        }

        static int GetValidMonth()
        {

            int result = GetValidInput();
            bool flag = true;
            while (flag)
            {
                DateTime moment = DateTime.Now;
                if (result < 1 || result > 12)
                {
                    Console.WriteLine("Enter a valid month");
                    result = GetValidInput();
                }
                else
                {
                    flag = false;
                }
            }
            return result;
        }


        static int GetValidInput()
        {
            int result;
            string userInput = Console.ReadLine();

            while (!int.TryParse(userInput, out result))
            {
                Console.WriteLine("Input is not valid, Please enter a number");
                userInput = Console.ReadLine();
            }
            return result;
        }

    }
}
