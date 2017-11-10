using ClientConsole.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello World";
            InputForTemp input = new InputForTemp();
            input.InputMessage = str;
            Service1Client client = new Service1Client();
            OutputForTemp output=client.CalculateTemp(input);
            Console.WriteLine(output.OutputMessage);

            Console.ReadKey();
        }
    }
}
