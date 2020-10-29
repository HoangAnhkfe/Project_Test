using System;
using System.Collections.Generic;
using System.Linq;

namespace Bai1_OOP_NguyenHoangAnh
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Create main object */
            Management main = new Management();
            while (true)
            {
                Console.WriteLine("\n-----Office Management Application-----");
                Console.WriteLine("-----Select function-----");
                Console.WriteLine("1. Enter new Office information.");
                Console.WriteLine("2. Search by name.");
                Console.WriteLine("3. Displays information about the list of Office.");
                Console.WriteLine("4. Exit");
                int choice = 0;
                do
                {
                    Console.Write(">");
                    choice = Convert.ToInt32(Console.ReadLine());
                } while (choice < 0 || choice > 4);
                switch (choice)
                {
                    case 1:
                        main.AddOffice();
                        break;
                    case 2:
                        Console.WriteLine("Enter search name: ");
                        string search = Console.ReadLine();
                        main.SearchByName(search);
                        break;
                    case 3:
                        main.GetListCader();
                        break;
                    case 4:
                        return;
                    default:
                        break;
                }
            }
        }
    }
    /*Define Management Class*/
    public class Management
    {
        private List<Office> offices;
        /*Constructor*/
        public Management()
        {
            offices = new List<Office>();
        }
        /*Add Office*/
        public void AddOffice()
        {
            Console.WriteLine("1. Worker.");
            Console.WriteLine("2. Engineer.");
            Console.WriteLine("3. Staff.");
            int choice = 0;
            do
            {
                Console.Write(">");
                choice = Convert.ToInt32(Console.ReadLine());
            } while (choice < 0 || choice > 3);
            Console.WriteLine("\nPlease enter the information for this Office:");
            Console.Write("FullName: ");
            string fullName = Console.ReadLine();
            Console.Write("Year Of Birth: ");
            int yearOfBirth = Convert.ToInt32(Console.ReadLine());
            Console.Write("Gender: ");
            byte gender = Convert.ToByte(Console.ReadLine());
            Console.Write("Address: ");
            string address = Console.ReadLine();
            switch (choice)
            {
                case 1:
                    
                    int level;
                    do
                    {
                        Console.Write("Level: ");
                        level = Convert.ToInt32(Console.ReadLine());
                    } while (level < 0 || level > 7);
                    Worker worker = new Worker(fullName, yearOfBirth, gender, address, level);
                    offices.Add(worker);
                    break;
                case 2:
                    Console.Write("Category: ");
                    string category = Console.ReadLine();
                    Engineer engineer = new Engineer(fullName, yearOfBirth, gender, address, category);
                    offices.Add(engineer);
                    break;
                default:
                    Console.Write("Job: ");
                    string job = Console.ReadLine();
                    Staff staff = new Staff(fullName, yearOfBirth, gender, address, job);
                    offices.Add(staff);
                    break;
            }
        }

        /*Search by name*/
        public void SearchByName(string fullName)
        {
            this.offices.Where(x => x.fullName.Contains(fullName)).ToList().ForEach(x => x.GetInfo());
        }

        /*Show data*/
        public void GetListCader()
        {
            this.offices.ForEach(x => x.GetInfo());
        }

    }

    /*Define Class Office*/
    public class Office
    {
        public string fullName;
        protected int yearOfBirth;
        protected byte gender;
        protected string address;

        /*Constructor*/
        public Office(string fullName, int yearOfBirth, byte gender, string address)
        {
            this.fullName = fullName;
            this.yearOfBirth = yearOfBirth;
            this.gender = gender;
            this.address = address;
        }
        public virtual void GetInfo() { }
    }

    /*Define Class Worker extend Class Office*/
    public class Worker : Office
    {
        private int level;
        public Worker(string fullName, int yearOfBirth, byte geder, string address, int level) :
            base(fullName, yearOfBirth, geder, address)
        {
            this.level = level;
        }
        /*Create method get data of Worker, extends from Office*/
        public override void GetInfo()
        {
            Console.WriteLine("Full Name: " + fullName);
            Console.WriteLine("Year Of Birth: " + yearOfBirth);
            Console.WriteLine("Gender: " + ((gender == 0) ? "Female" : "Male"));
            Console.WriteLine("Address: " + address);
            Console.WriteLine("Level: " + level + "/7");
        }

    }

    /*Define Class Engineer extend Class Office*/
    public class Engineer : Office
    {
        private string category;

        /*Constructor*/
        public Engineer(string fullName, int yearOfBirth, byte geder, string address, string category) :
            base(fullName, yearOfBirth, geder, address)
        {
            this.category = category;
        }
        /*Create method get data of Engineer, extends from Office*/
        public override void GetInfo()
        {
            Console.WriteLine("Full Name: " + fullName);
            Console.WriteLine("Year Of Birth: " + yearOfBirth);
            Console.WriteLine("Gender: " + ((gender == 0) ? "Female" : "Male"));
            Console.WriteLine("Address: " + address);
            Console.WriteLine("Category: " + category);
        }

    }

    /*Define Class Staff extend Class Office*/
    public class Staff : Office
    {
        private string job;

        /*Constructor*/
        public Staff(string fullName, int yearOfBirth, byte geder, string address, string job) :
            base(fullName, yearOfBirth, geder, address)
        {
            this.job = job;
        }

        /*Create method get data of Staff, extends from Office*/
        public override void GetInfo()
        {
            Console.WriteLine("Full Name: " + fullName);
            Console.WriteLine("Year Of Birth: " + yearOfBirth);
            Console.WriteLine("Gender: " + ((gender == 0) ? "Female" : "Male"));
            Console.WriteLine("Address: " + address);
            Console.WriteLine("Job: " + job);
        }
    }

}
