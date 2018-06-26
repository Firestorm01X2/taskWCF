namespace WcfMathLibrary.Integrals
{
    using System.Runtime.Serialization;

    [DataContract]
    public class IntegralOutput
    {
        [DataMember]
        public double result { get; set; }

    }
}
