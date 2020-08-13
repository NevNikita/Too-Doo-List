using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Too_Doo_List
{
    public class Task
    {
        public string name { get; set; }
        public string description { get; set; }
        public DateTime datetime { get; set; }
        public string filePath { get; set; }
        public bool isDone { get; set; }

        public Task(string _name, string _description, DateTime _datetime, string _filePath)
        {
            name = _name;
            description = _description;
            datetime = _datetime;
            filePath = _filePath;
        }


        public void HasCurrentDateTime()
        {
            Console.WriteLine("Cheking");
            if (DateTime.Now == datetime)
                Console.WriteLine("YES");
        }
        
    }
}
