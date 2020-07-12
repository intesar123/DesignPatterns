using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID.SingleResponsibilityPrinciple
{
    public class Journal
    {
        //A class should have only one reason to change
        //Every module or class should have resposibility over a single part of the functionality provided by the software
        //and that resposibility should be entirly encapsulated by the class
        // feaures- Maintainablity, testablity and flexiblity , extensiblity, loose coupling and parallel development all the fearurs can be served by following SOLID

        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int addEntry(string text)
        {
            entries.Add($"{++count}:{text}");
            return count;
        }
        public void removeEntry(int index)
        {
            entries.RemoveAt(index);
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine,entries);
        }
        /**********Now the journal class not only keeping the entries but also managing the persistence we might face
        problems when we want to change the persistence or Journal functionality***********/

        //public void Save(string filename)
        //{
        //    File.WriteAllText(filename,ToString());
        //}
        //public static Journal Load(string fileName)
        //{
        //}
    }


    public class Persistence
    {
        public void saveFile(Journal journal, string fileName,bool overwirite)
        {
            if (overwirite||!File.Exists(fileName))
            {
                File.WriteAllText(fileName,journal.ToString());
            }
        }
    }
}

