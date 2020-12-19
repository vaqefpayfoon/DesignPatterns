namespace InterfaceSegregation
{
  public class Document
  {
  }

  public interface IMachine
  {
    void Print(Document d);
    void Fax(Document d);
    void Scan(Document d);
  }

  // ok if you need a multifunction machine
  public class MultiFunctionPrinter : IMachine
  {
    public void Print(Document d)
    {
      //
    }

    public void Fax(Document d)
    {
      //
    }

    public void Scan(Document d)
    {
      //
    }
  }
  public interface IPrint
  {
      void Print(Document d);
  }
  public interface IScan
  {
      void Scan(Document d);
  }
    public class PhotoCopier : IPrint, IScan
    {
        public void Print(Document d)
        {
            throw new System.NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new System.NotImplementedException();
        }
    }
    public interface IMultiFunctionDevice : IPrint, IScan
    {

    }
    public class MultiFunctionDevice : IMultiFunctionDevice
    {
        private IPrint printer;
        private IScan scanner;
        public MultiFunctionDevice(IPrint printer, IScan scanner)
        {
            this.printer = printer;
            this.scanner = scanner;
        }
        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
        }
    }
}