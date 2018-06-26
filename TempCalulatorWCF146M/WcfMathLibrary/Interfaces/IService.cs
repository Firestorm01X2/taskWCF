namespace WcfMathLibrary.Interfaces
{
    using System.ServiceModel;
    using Matrix;
    using Temperature;

    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        OutputForTemp CalculateTemp(InputForTemp input);

        [OperationContract]
        OutputForTemp3D CalculateTemp3D(InputForTemp3D input3D);

        [OperationContract]
        OutputForTemp1D CalculateTemp1D(InputForTemp1D input1D);

        [OperationContract]
        MatrixOutput MatrixSum(MatrixInput Input);

        [OperationContract]
        MatrixOutput MatrixMul(MatrixInput Input);
    }
}
