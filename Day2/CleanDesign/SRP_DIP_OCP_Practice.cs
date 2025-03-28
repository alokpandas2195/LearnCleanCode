    public class PrinterDriver
    {
        IInputDevice myInputDevice;
        Printer myPrinter;
        public PrinterDriver(IInputDevice theInputDevice, Printer thePrinter)
        {
            myInputDevice = theInputDevice;
            myPrinter = thePrinter;
        }
    
        public void Print()
        {
            while (!myInputDevice.IsEndOfTheFile())
            {
                Buffer buffer = myInputDevice.GetNextPage();
                myPrinter.Print(buffer);
            }
        }
    }


    public interface IInputDevice
    {
        bool IsEndOfTheFile();
        Buffer GetNextPage();
    }

    public class Buffer
    {
    // the data which is to be printed
    }

    public class Printer
    {
        public void Print(Buffer buffer)
        {
            // implementation
        }
    }


    public class Scanner : IInputDevice
    {
        public bool IsEndOfTheFile()
        {
            return IsLastPage() && IsScanning();
        }

        public Buffer GetNextPage()
        {
            return ReadPage();
        }

        private bool IsScanning()
        {
            // implementation Scanning is in progress
        }

        private bool IsLastPage()
        {
            // implementation for checking whether only one page is left to be read
        }

        private Buffer ReadPage()
        {
            // implementation
        }
    }

    public class Fax : IInputDevice
    {
        public bool IsEndOfTheFile()
        {
            return IsLastPage() && IsReceiving();
        }

        public Buffer GetNextPage()
        {
            return ReadRecentPage();
        }

        private bool IsReceiving()
        {
            // implementation whether Recieving is in progress
        }

        private bool IsLastPage()
        {
            // implementation for checking whether only one page is left to be read
        }

        private Buffer ReadRecentPage()
        {
            // implementation for giving recent page from all the received pages
        }
    }

    public class File : IInputDevice
    {
        public bool IsEndOfTheFile()
        {
            return IsLastPage();
        }

        public Buffer GetNextPage()
        {
            return ReadRecentPage();
        }

        private bool IsLastPage()
        {
            // implementation for checking whether only one page is left to be read
        }

        private Buffer ReadRecentPage()
        {
            // implementation
        }
    }
