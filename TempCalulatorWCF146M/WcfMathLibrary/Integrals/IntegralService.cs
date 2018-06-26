namespace WcfMathLibrary.Integrals
{
    using Interfaces.IntegralInterfaces;
    using System.ServiceModel;
    using SolveIntegralLib;

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    class IntegralService : IServiceIntegral
    {
        IntegralOutput IServiceIntegral.IntegralSeqRectangleMedium(IntegralInput Input)
        {
            IntegralOutput result = new IntegralOutput();
            SeqMeth integral = new SeqMeth();
            result.result = integral.RectangleMedium(Input.A, Input.B, Input.N, OperationContext.Current.GetCallbackChannel<IServiceInteralCallBack>().Integrand);
            return result;
        }

        IntegralOutput IServiceIntegral.IntegralParRectangleMedium(IntegralInput input)
        {
            IntegralOutput result = new IntegralOutput();
            ParallelMets integral = new ParallelMets();
            result.result = integral.RectangleMedium(input.A, input.B, input.N, OperationContext.Current.GetCallbackChannel<IServiceInteralCallBack>().Integrand);
            return result;
        }

        IntegralOutput IServiceIntegral.IntegralParSimpson(IntegralInput input)
        {
            IntegralOutput result = new IntegralOutput();
            ParallelMets integral = new ParallelMets();
            result.result = integral.Simpson(input.A, input.B, input.N, OperationContext.Current.GetCallbackChannel<IServiceInteralCallBack>().Integrand);
            return result;
        }

        IntegralOutput IServiceIntegral.IntegralSeqTrapeze(IntegralInput input)
        {
            IntegralOutput result = new IntegralOutput();
            SeqMeth integral = new SeqMeth();
            result.result = integral.Trapeze(input.A, input.B, input.N, OperationContext.Current.GetCallbackChannel<IServiceInteralCallBack>().Integrand);
            return result;
        }

        IntegralOutput IServiceIntegral.IntegralParTrapeze(IntegralInput input)
        {
            IntegralOutput result = new IntegralOutput();
            ParallelMets integral = new ParallelMets();
            result.result = integral.Trapeze(input.A, input.B, input.N, OperationContext.Current.GetCallbackChannel<IServiceInteralCallBack>().Integrand);
            return result;
        }

        IntegralOutput IServiceIntegral.IntegralSeqSimpson(IntegralInput input)
        {
            IntegralOutput result = new IntegralOutput();
            SeqMeth integral = new SeqMeth();
            result.result = integral.Simpson(input.A, input.B, input.N, OperationContext.Current.GetCallbackChannel<IServiceInteralCallBack>().Integrand);
            return result;
        }
    }
}
