using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID.InterfaceSegregationPrinciple
{
    public class Document
    {
        //Interface segregation principle is something that u r likely to encounter in the real world u buld the 
        //interfaces which are too large, the idea is quite simple the interface should be segregated so nobody 
        //who implements the iterface need to implement all the methods

    }

    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }
    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }

        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }
    // Here you will find the problem with the OldFashionedPrinter now u r obliged to implement all the methods
    // here the idea is people dont pay for the things they dont need
    public class OldFashionedPrinter : IMachine
    {
        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }

        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }
}
