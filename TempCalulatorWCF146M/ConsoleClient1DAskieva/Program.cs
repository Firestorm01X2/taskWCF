namespace ConsoleClient1DAskieva
{
    using System;
    using ServiceReference1;

    class Program
    {
        static void Main(string[] args)
        {
            double T1 = 10;
            double T2 = 10;
            double length = 15;
            double tau = 0.001;
            double h = 0.1;
            double a = 1;
            int freq = 5;

            int N = Convert.ToInt32(length / h) + 1;
            double[] U = new double[N];
            U[0] = T1;
            U[N - 1] = T2;
            for (int i = 1; i < N - 1; i++)
            {
                U[i] = 0;
            }

            while (true)
            {
                ServiceClient client = new ServiceClient();
                InputForTemp1D input = new InputForTemp1D();
                input.C = a;
                input.H = h;
                input.Tau = tau;
                input.U = U;
                input.TimeSteps = freq;

                OutputForTemp1D output = client.CalculateTemp1D(input);
                U = output.U;

                for (int i = 0; i < N; i++)
                {
                    Console.Write("{0} ", U[i]);
                }

                Console.WriteLine("\n");

                Console.ReadKey();
            }
        }
    }
}
