using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class Wages : Employee
    {
        private double rate;
        private double hours;

        public Wages()
        {
            this.rate = 0;
            this.hours = 0;
        }
        public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours)
            : base(id, name, address, phone, sin, dob, dept)
        {
            this.rate = rate;
            this.hours = hours;
        }
        public double Rate
        { get { return this.rate; } set { this.rate = value; } }
        public double Hours
        { get { return this.hours; } set { this.hours = value; } }

        public override double GetPay()
        {
            double time = 0;
            if (Hours > 40)
            {
                double overtime = (Hours - 40);
                overtime = overtime * 1.5;
                time = 40 + overtime;
            } 
            else
            {
                time = Hours;
            }
            double pay = Math.Round((time * Rate), 2);
            return pay;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nRate: {Rate}\nHours: {Hours}";
        }
    }
}
