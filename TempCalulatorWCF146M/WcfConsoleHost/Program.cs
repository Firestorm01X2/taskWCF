namespace WcfConsoleHost
{
    using System;
    using System.ServiceModel;

    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WcfMathLibrary.MatrixTemperatureService)))
            {
                host.Open();
                Console.WriteLine("Host started @ " + DateTime.Now.ToString());
                Console.ReadKey();
            }
        }
    }
}
