using System;
using System.Globalization;
using System.Collections.Generic;
using ListaDeExercicios10.Entities;
using ListaDeExercicios10.Entities.Enums;

namespace ListaDeExercicios10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter departmant's name: ");
            string departName = Console.ReadLine();
            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkLevel level = Enum.Parse<WorkLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Department department = new Department(departName);
            Worker trabalhador = new Worker(name, level, baseSalary, department);

            Console.Write("\nHow many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter contract #{i+1} data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int duration = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date,valuePerHour,duration);
                trabalhador.addContract(contract);
            }

            Console.Write("\nEnter mouth and year to calculate income (MM/YYYY): ");
            string mouthAndYear = Console.ReadLine();
            int mouth = int.Parse(mouthAndYear.Substring(0, 2));
            int year = int.Parse(mouthAndYear.Substring(3));

            Console.WriteLine($"\nName: {trabalhador.Name}");
            Console.WriteLine($"Departmant: {trabalhador.Department.Name}");
            Console.WriteLine($"Income for {mouth}/{year}: {trabalhador.Income(year,mouth).ToString("F2", CultureInfo.InvariantCulture)}");

        }
    }
}