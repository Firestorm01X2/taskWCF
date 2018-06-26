namespace WcfMathLibrary.Interfaces.IntegralInterfaces
{
    using Integrals;
    using System.ServiceModel;

    /// <summary>
    /// Interface which describes the methods of integral calculation
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IServiceInteralCallBack))]
    public interface IServiceIntegral
    {
        /// <summary>
        /// Method description for the integral calculation by the trapeze method
        /// </summary>
        /// <param name="input">Input parameters for the integral</param>
        /// <returns>Output parameters for the integral</returns>
        [OperationContract]
        IntegralOutput IntegralParTrapeze(IntegralInput input);

        /// <summary>
        /// Method description for the integral calculation by the medium rectangle method
        /// </summary>
        /// <param name="input">Input parameters for the integral</param>
        /// <returns>Output parameters for the integral</returns>
        [OperationContract]
        IntegralOutput IntegralParRectangleMedium(IntegralInput input);

        /// <summary>
        /// Method description for the integral calculation by the simpson method
        /// </summary>
        /// <param name="input">Input parameters for the integral</param>
        /// <returns>Output parameters for the integral</returns>
        [OperationContract]
        IntegralOutput IntegralParSimpson(IntegralInput input);

        /// <summary>
        /// Method description for the integral calculation by the sequential trapeze method
        /// </summary>
        /// <param name="input">Input parameters for the integral</param>
        /// <returns>Output parameters for the integral</returns>
        [OperationContract]
        IntegralOutput IntegralSeqTrapeze(IntegralInput input);

        /// <summary>
        /// Method description for the integral calculation by the sequential rectangle medium method
        /// </summary>
        /// <param name="input">Input parameters for the integral</param>
        /// <returns>Output parameters for the integral</returns>
        [OperationContract]
        IntegralOutput IntegralSeqRectangleMedium(IntegralInput input);

        /// <summary>
        /// Method description for the integral calculation by the sequential simpson method
        /// </summary>
        /// <param name="input">Input parameters for the integral</param>
        /// <returns>Output parameters for the integral</returns>
        [OperationContract]
        IntegralOutput IntegralSeqSimpson(IntegralInput input);
    }
}
