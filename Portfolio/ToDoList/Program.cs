using System;
using System.Collections.Generic;

namespace ToDoList
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            var ToDoList = new Dictionary<string, ToDoItem>();
            string choice;

            do
            {
                ToDoItem item = new ToDoItem();
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Press enter to start new to-do lsit item, or enter quit to finish:");
                choice = Console.ReadLine();

                if (choice == "quit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Add the priority for the item(high, medium, or low)");
                    item.priority = Console.ReadLine();
                    Console.WriteLine("Add a description for the new list item: ");
                    item.description = Console.ReadLine();
                    Console.WriteLine("When is this item due?: ");
                    item.date = Console.ReadLine();
                    ToDoList.Add(item.priority, item);

                }

            } while (choice != "quit");


            Console.Clear();
            Console.WriteLine("     To-Do List      ");
            Console.WriteLine("Priority - Description - Due Date");
            Console.WriteLine("_________________________________");
            
            foreach (var key in ToDoList)
            {
                Console.WriteLine(key.Key + " - " + key.Value.description + " - " + key.Value.date);

            }
            Console.Read();

        }

    
    }

    public class ToDoItem
    {
        public string priority = string.Empty;
        public string description { get; set; }
        public string date { get; set; }

        public ToDoItem(string Priority, string Description, string Date)
        {
            priority = Priority;
            description = Description;
            date = Date;
        }
        public ToDoItem()
        {

        }
    }
}


