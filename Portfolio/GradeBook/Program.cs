using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> studGrades = new Dictionary<string, string>();
            Console.WriteLine("Welcome to GradeBook ");
            string studName = string.Empty;
            string grades = string.Empty;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a student name, or 'quit' to end: ");
                studName = Console.ReadLine();

                if (studName == "quit")
                {
                    break;
                }
                else
                {

                    Console.WriteLine("Enter student grades in one line. Separate each grade with a space (no commas): ");
                    grades = Console.ReadLine();
                    studGrades.Add(studName, grades);

                }

            } while (studName != "quit");


            foreach (var student in studGrades)
            {
                string[] grades2 = grades.Split(" ");
                string min = grades2.Min();
                string max = grades2.Max();
                Console.WriteLine(student.Key + " " + student.Value);
                Console.WriteLine("Highest: {0}", max);
                Console.WriteLine("Lowest: {0}", min);
                Console.Read();
            }
                        
        }

    }
    }
