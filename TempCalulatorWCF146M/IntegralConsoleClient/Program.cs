namespace IntegralConsoleClient
{
    using System;
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
            ServiceIntegralClient serviceIntegralClient = new ServiceIntegralClient(instanceContext);

            IntegralOutput output = serviceIntegralClient.IntegralSeqTrapeze(input);
            Console.WriteLine($"Sequential trapeze: {output.result}");

            output = serviceIntegralClient.IntegralParTrapeze(input);
            Console.WriteLine($"Parallel trapeze: {output.result}");

            output = serviceIntegralClient.IntegralSeqRectangleMedium(input);
            Console.WriteLine($"Sequential rectangle medium: {output.result}");

            output = serviceIntegralClient.IntegralParRectangleMedium(input);
            Console.WriteLine($"Parallel rectangle medium: {output.result}");

            output = serviceIntegralClient.IntegralSeqSimpson(input);
            Console.WriteLine($"Sequential simpson medium: {output.result}");

            output = serviceIntegralClient.IntegralParSimpson(input);
            Console.WriteLine($"Parallel simpson medium: {output.result}");

            Console.WriteLine("End of program!");
            Console.ReadKey();
        }

        public class CallBackHandler : IServiceIntegralCallback
        {
            double IServiceIntegralCallback.Integrand(double x)
            {
                return x * x;
            }
        }
    }
}
