using CheckPoint2SQL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ToDoList = new Dictionary<int, ToDoItem>();
            string choice;
            int i = 1;
            int numberToUpdate;
            int numberToDelete;

            Console.WriteLine();
            Console.WriteLine("Welcome to your To-Do List");
          

            do
            {
                ToDoItem item = new ToDoItem();
                Console.Clear();
                Console.WriteLine("Welcome to your To-Do List");
                Console.WriteLine();
                Console.WriteLine("Press enter to start new to-do list item, or enter 'quit' to finish:");
                choice = Console.ReadLine().ToLower();

                if (choice == "quit")
                {
                    break;
                }
                else
                {
                    
                    Console.WriteLine("Add a description for the new list item: ");
                    item.description = Console.ReadLine();
                    Console.WriteLine("When is this item due?: ");
                    item.date = Console.ReadLine();
                    ToDoList.Add(i, item);
                    i = i + 1;

                }

            } while (choice != "quit");


           

            do
            {
                Console.Clear();
                Console.WriteLine("Item # | Description | Due Date");
                Console.WriteLine("_________________________________");

                foreach (var key in ToDoList)
                {
                    Console.WriteLine(key.Key + " | " + key.Value.description + " | " + key.Value.date);

                }
                Console.WriteLine();
                Console.WriteLine("Enter an item number to mark as done, or 0 when you're finished: ");
                numberToUpdate = Convert.ToInt32(Console.ReadLine());

                if (numberToUpdate >= 1)
                {
                    ToDoList[numberToUpdate].date = ("DONE!");
                }
                else if (numberToUpdate < 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            } while (numberToUpdate != 0);

            do
            {
                Console.Clear();
                Console.WriteLine("Item # | Description | Due Date");
                Console.WriteLine("_________________________________");

                foreach (var key in ToDoList)
                {
                    Console.WriteLine(key.Key + " | " + key.Value.description + " | " + key.Value.date);

                }
                Console.WriteLine();
                Console.WriteLine("Enter an item number to delete, or 0 to end: ");
                numberToDelete = Convert.ToInt32(Console.ReadLine());

                if (numberToDelete >= 1)
                {
                    ToDoList.Remove(numberToDelete);
                }
                else if (numberToDelete < 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            } while (numberToDelete != 0);


        }


    }
}
    

        
           
  