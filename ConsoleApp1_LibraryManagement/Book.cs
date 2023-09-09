using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_LibraryManagement
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; } = true;

        public void CheckOut()
        {
            IsAvailable = false;
        }

        public void CheckIn()
        {
            IsAvailable = true;
        }
    }

}
