namespace WcfMathLibrary.Temperature
{
    using System.Runtime.Serialization;
    [DataContract]
    public class OutputForTemp : OutputForTempBase
    {
        [DataMember]
        public double[][] U
        {
            get;
            set;
        }
    }
}
