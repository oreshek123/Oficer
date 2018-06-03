using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficer.DAL.Module
{
    [Serializable]
    public class Department
    {
        public string DepartmentName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int NumberOfDepartment { get; set;}
        public List<Person> persons = new List<Person>();

        public void PrintInfoAboutDepartment()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{DepartmentName} №{NumberOfDepartment}\nPhone number: {Phone}\nAdress: {Address}\n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Person item in persons)
            {
                item.PrintInfo();
            }
        }
    }
}
