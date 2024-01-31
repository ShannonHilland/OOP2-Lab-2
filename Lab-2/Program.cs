using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.ComponentModel;

namespace Lab_2
{
    public class Program
    {
        static object CreateList()
        {
            string filePath = "C:\\Users\\shann\\Documents\\OOP2\\Lab-2\\res\\employees.txt";
            List<string> lines = new List<string>();
            List<Employee> employees = new List<Employee>();
            lines = File.ReadAllLines(filePath).ToList();
            foreach (string line in lines)
            {
                char firstChar = line[0];
                string[] items = line.Split(':');
                if (firstChar == '0' || firstChar == '1' || firstChar == '2' || firstChar == '3' || firstChar == '4')
                {
                    Salaried salaryEmployee = new Salaried(items[0], items[1], items[2], items[3], long.Parse(items[4]), items[5], items[6], double.Parse(items[7]));
                    employees.Add(salaryEmployee);
                }
                else if (firstChar == '5' || firstChar == '6' || firstChar == '7')
                {
                    Wages wageEmployee = new Wages(items[0], items[1], items[2], items[3], long.Parse(items[4]), items[5], items[6], double.Parse(items[7]), double.Parse(items[8]));
                    employees.Add(wageEmployee);
                }
                else if (firstChar == '8' || firstChar == '9')
                {
                    PartTime partTimeEmployee = new PartTime(items[0], items[1], items[2], items[3], long.Parse(items[4]), items[5], items[6], double.Parse(items[7]), double.Parse(items[8]));
                    employees.Add(partTimeEmployee);
                }
            }
            Console.WriteLine("Employee list created");
            return employees;
        }
        static double AveragePay(List<Employee> employees)
        {
            double wage = 0;
            double count = employees.Count;
            foreach (Employee employee in employees)
            {
                wage += employee.GetPay();
            }
            double averagePay = Math.Round((wage / count), 2);
            return averagePay;
        }
        static void WageHighestPay(List<Employee> employees, out string name, out double pay)
        {
            List<Employee> wageEmployees = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (employee.GetType() == typeof(Wages))
                {
                    wageEmployees.Add(employee);
                }
            }
            name = "";
            pay = 0;
            double highestWage = 0;
            foreach (Employee employee in wageEmployees)
            {
                if (employee.GetPay() > highestWage)
                {
                    name = employee.Name;
                    pay = employee.GetPay();
                }
            }
            
        }
        static void LowestSalary(List<Employee> employees, out string name, out double pay)
        {
            List<Employee> salaryEmployee = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (employee.GetType() == typeof(Salaried))
                {
                    salaryEmployee.Add(employee);
                }
            }
            name = "";
            pay = 0;
            double lowestSalary = 5000000;
            foreach (Salaried employee in salaryEmployee)
            {
                if (employee.Salary < lowestSalary)
                {
                    name = employee.Name;
                    pay = employee.Salary;
                }
            }
        }
        static void EmployeeCategory(List<Employee> employees, out double wages, out double salaried, out double partTime)
        {
            double totalEmployees = employees.Count();
            List<Employee> wageEmployee = new List<Employee>();
            List<Employee> salariedEmployee = new List<Employee>();
            List<Employee> partTimeEmployee = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (employee.GetType() == typeof(Wages))
                {
                    wageEmployee.Add(employee);
                }
                else if (employee.GetType() == typeof(Salaried))
                {
                    salariedEmployee.Add(employee);
                }
                else if (employee.GetType() == typeof(PartTime))
                {
                    partTimeEmployee.Add(employee);
                }

            }
            wages = ((wageEmployee.Count() / totalEmployees) * 100);
            salaried = ((salariedEmployee.Count() / totalEmployees) * 100);
            partTime = ((partTimeEmployee.Count() / totalEmployees)* 100);
        }
        static void Main(string[] args)
        {
            //Create List of Employees
            List<Employee> employees = new List<Employee>();
            employees = (List<Employee>)CreateList();
            
            //Calculate average pay
            Console.WriteLine($"The average weekly pay for all employees is: ${AveragePay(employees)}");

            //Calculate highest pay for wage employees
            string wageName;
            double wagePay;
            WageHighestPay(employees, out wageName, out wagePay);
            Console.WriteLine($"The highest weekly pay for wage employees is ${wagePay}, earned by {wageName}");

            //Calculate lowest salary for salaried employees
            string salaryName;
            double salaryPay;
            LowestSalary(employees, out salaryName, out salaryPay);
            Console.WriteLine($"The lowest salary is ${salaryPay}, earned by {salaryName}");

            //Calculate percent of employees that fall into each category
            EmployeeCategory(employees, out double wages, out double salaried, out double partTime);
            Console.WriteLine($"Employee Distribution by Pay Category:\nWage Employees: {Math.Round(wages, 2)}%\nSalary Employees: {Math.Round(salaried, 2)}%\nPart Time Employees: {Math.Round(partTime, 2)}%");
        }

        
     
    }
}
