﻿using DesignPatterns.SOLID.LiskovSubstitutionPrinciple;
using DesignPatterns.SOLID.OpenClosedPrinciple;
using DesignPatterns.SOLID.SingleResponsibilityPrinciple;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns.SOLID.DependencyInversionPrinciple.DependencyInversionPrinciple;

namespace DesignPatterns
{
    class Program
    {
        public static int Area(Rectangle r) => r.Width * r.Height;

        static void Main(string[] args)
        {
            #region //////////////////////////////////////SOLID Principle//////////////////////////////////////
            #region 1 Single Responsibility Principle
            Console.WriteLine("********************Single Responsibility Principle********************");
            /********************Single Responsibility Principle********************/
            Journal journal = new Journal();
            journal.addEntry("I started learning desing pattern");
            journal.addEntry("Learning some principle to design and develop a software");
            Console.WriteLine(journal);


            var p = new Persistence();

            //To get the location the assembly normally resides on disk or the install directory
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

            //once you have the path you get the directory with:
            var directory = System.IO.Path.GetDirectoryName(path);
            var filename = Path.Combine(directory, "JOURNAL.txt");
            p.saveFile(journal, filename, true);
            #endregion

            #region 2 Open closedd loop principle
            Console.WriteLine("********************Open closedd loop principle********************");
            /********************Open closedd loop principle********************/
            var apple = new Product("apple", Color.Green, Size.small);
            var tree = new Product("tree", Color.Green, Size.medium);
            var book = new Product("book", Color.Red, Size.small);
            var pen = new Product("pen", Color.Blue, Size.small);

            Product[] products = { apple, tree, book, pen };

            ProductFilter pf = new ProductFilter();
            Console.WriteLine("Green products(old) :");
            //foreach (Product product in pf.FilterBySize(products, Size.small))
            //{
            //    Console.WriteLine($"-{product.name} is is small");
            //}
            Console.WriteLine("Green products(old) :");
            foreach (Product product in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($"-{product.name} is is green");
            }

            Console.WriteLine("Green products(New) :");
            var newFilter = new NewFilter();
            foreach (Product product in newFilter.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($"-{product.name} is is green");
            }

            Console.WriteLine("Small and Green products(New) :");
            foreach (var product in newFilter.Filter(products, new AndSpecification<Product>(
                new ColorSpecification(Color.Green),
                new SizeSpecification(Size.small)
                )))
            {
                Console.WriteLine($"-{product.name} is is green");
            }

            //without OCP
            Console.WriteLine("----without OCP");
            Employee employee = new Employee(1, "John","Permanent");
            string value = employee.ToString();
            Console.WriteLine("Employee {0} Bonus {1}", employee.ToString(), employee.calculateBonus(10000));

            Employee employee2 = new Employee(1, "Jason", "Contract");
            value = employee2.ToString();
            Console.WriteLine("Employee {0} Bonus {1}", employee2.ToString(), employee2.calculateBonus(10000));
            //with OCP
            Console.WriteLine("----with OCP");
            EmolyeeNew  employeeNew = new PermanentEmployee(1, "John");
            value = employee.ToString();
            Console.WriteLine("Employee {0} Bonus {1}", employeeNew.ToString(), employeeNew.calculateBonus(10000));

            EmolyeeNew employeeNew2 = new ContractEmployee(1, "Jason");
            value = employee2.ToString();
            Console.WriteLine("Employee {0} Bonus {1}", employeeNew2.ToString(), employeeNew2.calculateBonus(10000));

            #endregion

            #region 3 Liskov substitution principle
            /********************Liskov substitution principle********************/
            Console.WriteLine("********************Liskov substitution principle********************");
            Rectangle rectangle = new Rectangle(2,3);
            Console.WriteLine($"{rectangle} has area {Area(rectangle)}");

            //Square square = new Square();
            Rectangle square = new Square();
            square.Width = 5;
            Console.WriteLine($"{square} has area {Area(square)}");
            #endregion

            #region 4 Interface segregation principle
            /********************Interface segregation principle********************/

            #endregion

            #region 5 Dependency inversion principle
            /********************Dependency inversion principle********************/
            Console.WriteLine("********************Dependency inversion principle********************");
            var parent = new Person { name = "Soniya Gandhi" };
            var child1 = new Person { name = "Rahul Gandhi" };
            var child2 = new Person { name = "Priyanka Gandhi" };

            var relationships = new Relaionships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);
            Research research = new Research(relationships);

            #endregion
            #endregion Solid
            Console.ReadKey();
        }
    }
}
