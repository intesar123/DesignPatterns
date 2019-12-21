using DesignPatterns.SOLID.SingleResponsibilityPrinciple;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1
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
            var filename =Path.Combine(directory, "JOURNAL.txt");
            p.saveFile(journal, filename, true);
            #endregion


            Console.ReadKey();
        }
    }
}
