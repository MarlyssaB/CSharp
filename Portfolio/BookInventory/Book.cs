using System;
using System.Collections.Generic;
using System.Text;

namespace BookInventory
{
    class Book
    {
        public int ID { get; private set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public Book (string Title, string Author)
        {
            this.Title = Title;
            this.Author = Author;
        }
    }
}
