using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID.OpenClosedPrinciple
{
    abstract class EmolyeeNew
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public EmolyeeNew()
        {

        }
        public EmolyeeNew(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public abstract decimal calculateBonus(decimal Salary);

        public override string ToString()
        {
            return string.Format("id: {0} name : {1}", this.Id, this.Name);
        }
    }

    class PermanentEmployee : EmolyeeNew
    {
        public PermanentEmployee()
        {

        }
        public PermanentEmployee(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public override decimal calculateBonus(decimal Salary)
        {
            return Salary * .1M;
        }
    }
    class ContractEmployee : EmolyeeNew
    {
        public ContractEmployee()
        {

        }
        public ContractEmployee (int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public override decimal calculateBonus(decimal Salary)
        {
            return Salary * .05M;
        }
    }
}
