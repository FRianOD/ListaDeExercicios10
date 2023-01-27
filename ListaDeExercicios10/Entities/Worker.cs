using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using ListaDeExercicios10.Entities.Enums;

namespace ListaDeExercicios10.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public WorkLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }

        public List<HourContract> Contracts { get; set; } = new List<HourContract>();
        
        public Worker(string name, WorkLevel level, double baseSalary, Department department) 
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void addContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void removeContract(HourContract contract) 
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach (HourContract contract in Contracts) 
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }

    }
}
