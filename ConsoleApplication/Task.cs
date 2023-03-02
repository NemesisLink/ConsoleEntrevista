using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication
{
    class Task
    {
        public string taskname { get; set; }
        public string description { get; set; }
        public DateTime duedate { get; set; }
        public bool completed { get; set; }


        public Task(string Taskname, string Desciption, DateTime DueDate)
        {
            taskname = Taskname;
            description = Desciption;
            duedate = DueDate;
            completed = false;
        }


    }



}
