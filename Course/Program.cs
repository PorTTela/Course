using System;
using Course.Entities.Enums;
using Course.Entities;
using System.Globalization;
using System.Collections.Generic;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nome do Departamento: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Entre com os dados do funcinário");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Nível (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Sálario Base: ");
            double basySalary = double.Parse(Console.ReadLine());
            Console.Write("Quantos contratos para este funcionário: ");
            int numContract = int.Parse(Console.ReadLine());

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, basySalary, dept);

            for (int i = 0; i < numContract; i++)
            {
                Console.WriteLine($"Entre com as informações do Contrato {i}:");
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                double valuePerHour = double.Parse(Console.ReadLine());
                Console.Write("Duração (horas): ");
                int hour = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hour);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Entre com o mes e ano para calcular o salário (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine("Nome: " + worker.Name);
            Console.WriteLine("Departamento: " + worker.Department.Name);
            Console.WriteLine("Salário em " + monthAndYear + " : " + worker.Income(year,month).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
