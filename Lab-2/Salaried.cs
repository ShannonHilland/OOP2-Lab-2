using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class Salaried : Employee 
    {
        private double salary;

        public Salaried()
        {
            this.salary = 0;
        }
        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary) 
            : base(id, name, address, phone, sin, dob, dept) 
        { 
            this.salary = salary;
        }
        public double Salary
        { get { return this.salary; } set { this.salary = value; } }

        public override double GetPay()
        {
            double pay = Math.Round((Salary / 52), 2);
            return pay;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nSalary: {Salary}";
        }
    }
}
