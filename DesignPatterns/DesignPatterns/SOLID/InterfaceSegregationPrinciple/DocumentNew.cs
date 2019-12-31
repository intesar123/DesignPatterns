using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID.InterfaceSegregationPrinciple
{
    public class DocumentNew
    {
        //Interface segregation principle is something that u r likely to encounter in the real world u buld the 
        //interfaces which are too large, the idea is quite simple the interface should be segregated so nobody 
        //who implements the iterface need to implement all the methods

    }

    
    public interface IPrinter
    {
        void Print(DocumentNew d);
    }
    public interface IScanner
    {
        void Scan(DocumentNew d);
    }
    public interface IFax
    {
        void Fax(DocumentNew d);
    }
    public interface IMachineNew:IPrinter,IScanner,IFax
    {
      
    }
    public class MultiFunctionPrinterNew : IMachineNew
    {
        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }

        public void Fax(DocumentNew d)
        {
            throw new NotImplementedException();
        }

        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Print(DocumentNew d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(DocumentNew d)
        {
            throw new NotImplementedException();
        }
    }

    public class OldFashionedPrinterNew : IPrinter, IScanner
    {
        public void Print(DocumentNew d)
        {
            throw new NotImplementedException();
        }

        public void Scan(DocumentNew d)
        {
            throw new NotImplementedException();
        }
    }
// Suppose we have already implementations for these methods somewhere else. Here we'll have to use decorator pattern
//here we can just delegate the printer,scanner and fax
    public class NewFashionedPrinterNew : IMachineNew
    {
        private IScanner scanner;
        private IFax fax;
        private IPrinter printer;

        public NewFashionedPrinterNew(IScanner scanner, IFax fax, IPrinter printer)
        {
            this.scanner = scanner;
            this.fax = fax;
            this.printer = printer;
        }

        public void Scan(DocumentNew d)
        {
            scanner.Scan(d);
            //decorator
        }
        public void Fax(DocumentNew d)
        {
            fax.Fax(d);
            //decorator
        }
        public void Print(DocumentNew d)
        {
            printer.Print(d);
            //decorator
        }
    }
}
