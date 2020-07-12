using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID.OpenClosedPrinciple
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmployeeType { get; set; }
        public Employee()
        {

        }
        public Employee(int Id,string Name,string EmployeeType)
        {
            this.Id = Id;
            this.Name = Name;
            this.EmployeeType = EmployeeType;
        }

        public decimal calculateBonus(decimal Salary)
        {
            if (this.EmployeeType == "Permanent")
            {
                return Salary * .1M;
            }
            else
            {
                return Salary * .05M;
            }
        }

        public override string ToString()
        {
            return string.Format("id: {0} name : {1}",this.Id,this.Name);
        }
    }
}
