namespace WcfMathLibrary.Temperature
{
    using Array3DLibrary;
    using System.Runtime.Serialization;

    [DataContract]
    public class OutputForTemp3D : OutputForTempBase
    {
        [DataMember]
        public Array3D<double> U
        {
            get;
            set;
        }
    }
}
