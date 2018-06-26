namespace WcfMathLibrary.Interfaces.IntegralInterfaces
{
    using System.ServiceModel;

    /// <summary>
    /// Interface which describes callback methods
    /// </summary>
    public interface IServiceInteralCallBack
    {
        /// <summary>
        /// Callback function description for the integrand
        /// </summary>
        /// <param name="x">x-coordinate</param>
        /// <returns>The integrand value by X</returns>
        [OperationContract]
        double Integrand(double x);
    }
}
