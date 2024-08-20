using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using LinqTeste.Entities;
using System.Linq;


namespace LinqTeste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter full file path: ");
            string path = Console.ReadLine();
            Console.Write("Enter salary: ");
            
                double limit = double.Parse(Console.ReadLine());    
                List<Funcionario> list = new List<Funcionario>();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] data = sr.ReadLine().Split(',');
                        string name = data[0];
                        string email = data[1];
                        double salary = double.Parse(data[2], CultureInfo.InvariantCulture);
                        list.Add(new Funcionario(name, email, salary));
                    }
                }

                var emails = list.Where(obj => obj.Salary > limit).OrderBy(obj => obj.Email).Select(obj => obj.Email);

                var sum = list.Where(obj => obj.Name[0] == 'A').Sum(obj => obj.Salary);

                Console.WriteLine("Email of people whose salary's more than " + limit.ToString("F2", CultureInfo.InvariantCulture));
                foreach(string email in emails)
                {
                    Console.WriteLine(email);
                }

                Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch (IOException e) 
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
            


        }
    }
}
