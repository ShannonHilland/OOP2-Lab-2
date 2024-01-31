using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class PartTime : Employee
    {
        private double rate;
        private double hours;

        public PartTime()
        {
            this.rate = 0;
            this.hours = 0;
        }
        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours)
            :base(id, name, address, phone, sin, dob, dept)
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
            double workHours = 0;
            if (Hours > 40)
            {
                workHours = 40;
            }
            else
            {
                workHours = Hours;
            }
            double pay = Math.Round((Rate * workHours), 2);
            return pay;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nRate: {Rate}\nHours: {Hours}";
        }
    }
}
