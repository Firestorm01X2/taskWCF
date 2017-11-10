using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ConsoleApplication1.ServiceReference1;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            InputForTemp input = new InputForTemp();
            
            //InputForTemp
            input.C = 1.0;
            input.H = 1;
            input.Tau = 0.1;
            input.TimeSteps = 3;

            double [,]U1 = new double[4,4] { { 0, 0, 0, 0 }, { 1, 0, 0, 0 }, { 2, 0, 0, 0 }, { 3, 0, 0, 0 } };
            input.U = Utils.ToJagged(U1);
            
            Service1Client serv = new Service1Client();
            OutputForTemp out1 = serv.CalculateTemp(input);
            //serv.CalculateTemp()
                
        }
    }
}
