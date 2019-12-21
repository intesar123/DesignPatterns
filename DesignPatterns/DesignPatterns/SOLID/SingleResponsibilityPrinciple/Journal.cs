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

