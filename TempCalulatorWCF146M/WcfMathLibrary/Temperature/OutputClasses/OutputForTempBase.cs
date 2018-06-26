namespace WcfMathLibrary.Temperature
{
    using System.Runtime.Serialization;

    [DataContract]
    public class OutputForTempBase
    {
        [DataMember]
        public string OutputMessage
        {
            get;
            set;
        }
    }
}
