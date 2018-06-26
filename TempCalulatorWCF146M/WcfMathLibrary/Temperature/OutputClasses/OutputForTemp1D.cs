namespace WcfMathLibrary.Temperature
{
    using System.Runtime.Serialization;

    [DataContract]
    public class OutputForTemp1D : OutputForTempBase
    {
        [DataMember]
        public double[] U { get; set; }
    }
}
