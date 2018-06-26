namespace IntegralConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ServiceReference1;
    using System.ServiceModel;
    class Program
    {
        static void Main(string[] args)
        {
            IntegralInput input = new IntegralInput
            {
                A = 0,
                B = 5,
                N = 100
            };

            CallBackHandler handler = new CallBackHandler();
            InstanceContext instanceContext = new InstanceContext(handler);

            Service1Client client = new Service1Client(instanceContext);
            IntegralOutput output = client.IntegralParTrapeze(input);

            Console.WriteLine(output.result);
            Console.WriteLine("End of program!");
            Console.ReadKey();
        }

        public class CallBackHandler : IService1Callback
        {
            public double F(double x)
            {
                return x * x;
            }
        }
    }
}
