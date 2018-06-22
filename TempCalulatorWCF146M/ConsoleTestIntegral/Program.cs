using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ConsoleTestIntegral.ServiceReference1;
using WcfMathLibrary;

namespace ConsoleTestIntegral
{
    class Program
    {
        static void Main(string[] args)
        {
            IntegralInput input = new IntegralInput();
            Func<double, double>  F = (x) => x * x;
            input.A = 1;
            input.B = 10000;
            input.N = 100000;
            input.F = F;
            Service1Client client = new Service1Client();
            IntegralOutput output = client.IntegralParRectangleMedium(input);
            Console.WriteLine(output.result);
            Console.ReadKey();
        }
    }
}
