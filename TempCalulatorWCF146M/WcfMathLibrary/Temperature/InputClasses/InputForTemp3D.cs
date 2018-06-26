namespace WcfMathLibrary.Temperature
{
    using Array3DLibrary;
    using System.Runtime.Serialization;

    [DataContract]
    public class InputForTemp3D : InputForTempBase
    {
        [DataMember]
        public Array3D<double> U
        {
            get;
            set;
        }
    }
}
