namespace WcfMathLibrary.Temperature
{
    using System.Runtime.Serialization;

    [DataContract]
    public class InputForTemp1D : InputForTempBase
    {
        [DataMember]
        public double[] U
        {
            get;
            set;
        }
    }
}
