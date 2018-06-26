namespace WcfMathLibrary.Matrix
{
    using System.Runtime.Serialization;

    [DataContract]
    public class MatrixOutput
    {
        [DataMember]
        public int[][] matrixResult { get; set; }
    }
}
