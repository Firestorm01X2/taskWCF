using ClientConsole.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Array3DLibrary;

namespace ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 100;
            Array3D<double> array3D=new Array3D<double>(N, N, N);
            for(int i=0; i< N;i++)
                for (int j = 0; j < N; j++)
                    for (int k = 0; k < N; k++)
                        array3D[i, j, k] = 666;

            string str = "Hello World";
            InputForTemp3D input = new InputForTemp3D();
            input.InputMessage = str;
            input.C = 3;
            input.Tau = 0.001;
            input.H = 0.001;
            input.TimeSteps = 100;
            input.U = array3D;

            Service1Client client = new Service1Client();
            OutputForTemp3D output = client.CalculateTemp3D(input);
            Console.WriteLine(output.OutputMessage);

            
            //string str = "Hello World";
            //InputForTemp input = new InputForTemp();
            //input.InputMessage = str;
            //Service1Client client = new Service1Client();
            //OutputForTemp output=client.CalculateTemp(input);
            //Console.WriteLine(output.OutputMessage);

            Console.ReadKey();
        }
    }
}
