namespace WcfMathLibrary.Matrix
{
    using System.Runtime.Serialization;

    [DataContract]
    public class MatrixInput
    {
        [DataMember]
        public int[][] matrix1 { get; set; }
        [DataMember]
        public int[][] matrix2 { get; set; }
    }
}
