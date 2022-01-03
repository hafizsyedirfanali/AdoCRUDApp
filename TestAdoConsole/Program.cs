using System;

namespace TestAdoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //DatabaseLayer.EditSingle(4,"updated name","00000000");
            //DatabaseLayer.InsertSingle("another name", "33242343223");
            
            
            Console.WriteLine("Welcome to CRUD App");
            int id = 0;
            string name = "";
            string mobile = "";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose one of the following:");
                Console.WriteLine("1-Add");
                Console.WriteLine("2-Edit");
                Console.WriteLine("3-Delete");
                Console.WriteLine("4-List");
                Console.WriteLine("5-Exit Application");
                
                switch (Console.ReadLine())
                {
                    case "1":                        
                        Console.WriteLine("Enter Name:");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter Mobile:");
                        mobile = Console.ReadLine();
                        DatabaseLayer.InsertSingle(name, mobile);
                        Console.WriteLine("Done, Press any key");
                        Console.ReadLine();
                        break;
                    case "2":                        
                        Console.WriteLine("Enter Id:");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Name:");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter Mobile:");
                        mobile = Console.ReadLine();
                        DatabaseLayer.EditSingle(id, name, mobile);
                        Console.WriteLine("Done, Press any key");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Enter Id:");
                        id = Convert.ToInt32(Console.ReadLine());
                        DatabaseLayer.DeleteSingle(id);
                        Console.WriteLine("Done, Press any key");
                        Console.ReadLine();
                        break;
                    case "4":
                        DatabaseLayer.PrintList();
                        Console.WriteLine("Done, Press any key");
                        Console.ReadLine();
                        break;
                    case "5":
                        goto exitapp;                        
                    default:
                        goto exitapp;
                }
            }
            exitapp:
            Console.WriteLine("Thanks for using CRUD App");
        }
    }
}
