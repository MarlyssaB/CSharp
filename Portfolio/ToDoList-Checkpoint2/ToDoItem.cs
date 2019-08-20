using System;
using System.Collections.Generic;
using System.Text;

namespace CheckPoint2SQL
{
    public class ToDoItem
    {
        
        public string description { get; set; }
        public string date { get; set; }

        public ToDoItem(string Description, string Date)
        {
           
            description = Description;
            date = Date;
        }
        public ToDoItem()
        {

        }
    }

}
