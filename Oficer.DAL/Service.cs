using Oficer.DAL.Module;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Oficer.DAL
{
    [Serializable]
    public class Service
    {
        
        public Dictionary<int, string> Slujba = new Dictionary<int, string>();
        public List<Region> Regions = new List<Region>();
        public BinaryFormatter formatter = new BinaryFormatter();
        private Random Rnd = new Random();
        public void SlujbasGenerator()
        {
            Slujba.Add(101, "Pojarka");
            Slujba.Add(102, "Police");
            Slujba.Add(103, "Med");
            Slujba.Add(104, "Gas");
            Slujba.Add(105, "MCHS");
        }

        public void RegionGenerator()
        {
            
            for (int i = 0; i < Rnd.Next(1,20); i++)
            {
                Region region = new Region()
                {
                    IdRegion = Rnd.Next(1000, 9999),
                    Departments = GenerateDepartments()
                   
                };
                Regions.Add(region);
            }
        }
        public List<Department> GenerateDepartments()
        {
            List<Department> dep = new List<Department>();
            for (int i = 0; i < Rnd.Next(1,20); i++)
            {
                Department department = new Department()
                {
                    Address = "Street" + Rnd.Next(1, 200),
                    Phone = Rnd.Next(10000, 99999).ToString(),
                    DepartmentName = Slujba.ElementAt(Rnd.Next(0, Slujba.Count)).Value,
                    NumberOfDepartment = Rnd.Next(1, 100),
                    persons = GeneratePersons()
                };
                dep.Add(department);
            }
            return dep;
        }
        public List<Person> GeneratePersons()
        {
            List<Person> Persons = new List<Person>();
            for (int i = 0; i < Rnd.Next(1,50); i++)
            {
                Person person = new Person()
                {
                    Name = "#" + Rnd.Next(100, 999),
                    Rank = (Rank)Rnd.Next(1, 5),

                };
                Persons.Add(person);
            }
            return Persons;
        }

        public void BinarySerialize()
        {
            
            using (FileStream fs = new FileStream("regions.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Regions);
                Console.WriteLine(":ss");
            }
        }

        public void BinaryDeserialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("regions.dat", FileMode.OpenOrCreate))
            {
                List<Region> regions = (List<Region>)formatter.Deserialize(fs);
                foreach (Region item in regions)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Id region: "+item.IdRegion);
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (Department dep in item.Departments)
                    {
                        dep.PrintInfoAboutDepartment();
                    }
                }
                Console.WriteLine(":ss");
            }
        }

    }
}
