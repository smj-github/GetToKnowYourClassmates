using System;
using System.Collections.Generic;

namespace Lab8_GetToKnowYourClassmates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> studentList = MakeStudentList();
            List<string> stuHomeTown = MakeHomeTownList();
            List<string> stuFood = MakeFoodList();
            List<string> stuCar = MakeCarList();
            
            Console.WriteLine("Welcome to our C# Class");

            int studentCount = studentList.Count;

            char continueSearch = 'y';

            while (continueSearch == 'y')
            {
                // Display current student information
                DisplayStudentInfo(studentList);

                // Provide option to search by student number OR name
                Console.WriteLine("\nChoose Search Option 1/2: \n\t1. Search by Student Number \n\t2. Search by Student Name");
                
                string studentName = "";

                string userOpt = Console.ReadLine();
                while (!ValidateUserOption(userOpt))
                {
                    Console.WriteLine("Invalid Input. Please select 1/2");
                    userOpt = Console.ReadLine();
                }
                int searchOpt = int.Parse(userOpt);

                bool bValidInput = false;
                while (!bValidInput)
                {
                    try
                    {
                        int studentNo = 0;

                        // Get student number or name depending on user search option
                        if (searchOpt == 1)
                        {
                            Console.WriteLine("Which student would you like to learn more about? (Enter a number 1-" + studentCount + ")");
                            studentNo = int.Parse(Console.ReadLine());
                        }
                        else if (searchOpt == 2)
                        {
                            Console.WriteLine("Which student would you like to learn more about? (Enter student name)");
                            bool notFound = true;

                            while (notFound)
                            {
                                studentName = Console.ReadLine();
                                
                                // if student name is valid, get the student number
                                if (studentList.Contains(studentName))
                                {
                                    studentNo = studentList.IndexOf(studentName) + 1;
                                    notFound = false;
                                }
                                else
                                {
                                    Console.WriteLine("Student name not found. Please enter another name");
                                }
                            }
                        }
                        
                        // If student no. is valid, display student details option
                        if ((1 <= studentNo) && (studentNo <= studentCount))
                        {
                            studentName = studentList[studentNo - 1];

                            Console.WriteLine("Student " + studentNo + " is " + studentName + ". What would you like to know about " + studentName + "?");
                            char moreStuInfo = 'y';
                            while (moreStuInfo == 'y')
                            {
                                Console.WriteLine("Enter \n\t1. for hometown \n\t2. for favorite food \n\t3. for favorite car");
                                int stuInfo;
                                while (!int.TryParse(Console.ReadLine(), out stuInfo))
                                {
                                    Console.WriteLine("Invalid Input! Try again");
                                    Console.ReadLine();
                                }
                                // Fetch and display student details as required
                                switch (stuInfo)
                                {
                                    case 1:
                                        Console.WriteLine(studentName + " is from " + stuHomeTown[studentNo-1]);
                                        break;
                                    case 2:
                                        Console.WriteLine(studentName + "'s favorite food is " + stuFood[studentNo-1]);
                                        break;
                                    case 3:
                                        Console.WriteLine(studentName + "'s favorite car is " + stuCar[studentNo-1]);
                                        break;
                                }

                                Console.WriteLine("Would you like to know more about " + studentName + "? (Enter y/n)");
                                moreStuInfo = Console.ReadLine().ToLower()[0];
                            }
                            bValidInput = true;
                        }
                        else
                        {
                            bValidInput = false;
                            Console.WriteLine("That student does not exist. Please try again.");

                        }
                    }
                    catch (FormatException)
                    {
                        bValidInput = false;
                        Console.WriteLine("Invalid number! Please try again.");
                    }
                }

                Console.WriteLine("\nWould you like to learn about another student? (Enter y/n)");
                if(Console.ReadLine().ToLower()[0] != 'y')
                {
                    Console.WriteLine("Thanks!");
                    continueSearch = 'n';
                }
                else
                {
                    Console.Clear();
                }
            }
        }

        public static bool ValidateUserOption(string userOption)
        {
            if (int.TryParse(userOption, out int userOpt))
            {
                if ((userOpt == 1) || (userOpt == 2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }
        public static List<string> MakeStudentList()
        {
            List<string> studentList = new List<string>();
            studentList.Add("Lauren");
            studentList.Add("Justin");
            studentList.Add("Joshua");
            studentList.Add("Ramez");
            studentList.Add("Sean");
            studentList.Add("Simon");
            studentList.Add("Stephen");
            studentList.Add("Robbie");
            studentList.Add("Andoni");
            studentList.Add("Jordan");

            return studentList;
        }
        public static List<string> MakeHomeTownList()
        {
            List<string> studentList = new List<string>();
            studentList.Add("Alabama");
            studentList.Add("Mississipi");
            studentList.Add("San Diego");
            studentList.Add("Colorado");
            studentList.Add("Dallas");
            studentList.Add("Denver");
            studentList.Add("Charlotte");
            studentList.Add("New Jersey");
            studentList.Add("Chicago");
            studentList.Add("Detroit");

            return studentList;
        }
        public static List<string> MakeFoodList()
        {
            List<string> studentList = new List<string>();
            studentList.Add("Pizza");
            studentList.Add("Fries");
            studentList.Add("Burger");
            studentList.Add("Taco");
            studentList.Add("Quesadilla");
            studentList.Add("Noodles");
            studentList.Add("Soup & Bread");
            studentList.Add("Sandwich");
            studentList.Add("Fried Rice");
            studentList.Add("Jordan");

            return studentList;
        }
        public static List<string> MakeCarList()
        {
            List<string> studentList = new List<string>();
            studentList.Add("Chevy Equinox");
            studentList.Add("Ford Fusion");
            studentList.Add("Nissan Ultima");
            studentList.Add("Ford F150");
            studentList.Add("Dodge Caravan");
            studentList.Add("Hyundai Elantra");
            studentList.Add("Jeep");
            studentList.Add("Toyota Camry");
            studentList.Add("Toyota Lexus");
            studentList.Add("Honda Accura");

            return studentList;
        }
        public static void DisplayStudentInfo(List<string> studentList)
        {
            Console.WriteLine("Currently, there are " + studentList.Count + " students in the class");
            for(int i=0; i< studentList.Count; i++)
            {
                Console.WriteLine((i+1) + ": " + studentList[i]);
            }
        }
    }
}
