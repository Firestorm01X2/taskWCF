namespace WcfMathLibrary.Temperature
{
    using System.Runtime.Serialization;

    [DataContract]
    public class InputForTemp : InputForTempBase
    {
        [DataMember]
        public double[][] U
        {
            get;
            set;
        }
    }
}
