using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Array3DLibrary;
using Matrix;

namespace WcfMathLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // TODO: Add your service operations here
        [OperationContract]
        OutputForTemp CalculateTemp(InputForTemp input);


        [OperationContract]
        OutputForTemp3D CalculateTemp3D(InputForTemp3D input3D);

        [OperationContract]
        OutputForTemp1D CalculateTemp1D(InputForTemp1D input1D);

        [OperationContract]
        MatrixOutput MatrixSum(MatrixInput matrixes);

        [OperationContract]
        MatrixOutput MatrixMul(MatrixInput matrixes);
    }

    [DataContract]
    public class MatrixOutput
    {
        [DataMember]
        public MatrixT<int> matrixResult { get; set; }
    }

    [DataContract]
    public class MatrixInput
    {
        [DataMember]
       public MatrixT<int> matrix1 { get; set; }
        [DataMember]
       public MatrixT<int> matrix2 { get; set; }
    }

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

    [DataContract]
    public class OutputForTemp3D : OutputForTempBase
    {
        //[DataMember]
        //public double[] U
        //{
        //    get; set;
        //}
        [DataMember]
        public Array3D<double> U
        {
            get;
            set;
        }
    }

    [DataContract]
    public class InputForTempBase
    {
        private double _h;
        private double _tau;
        private double _c;
        private int _timeSteps;
        [DataMember]
        public string InputMessage
        {
            get;
            set;
        }

        [DataMember]
        public double H
        {
            get
            {
                return _h;
            }

            set
            {
                if (value <= 0)
                    throw new ArgumentException("h <= 0");
                _h = value;
            }
        }

        [DataMember]
        public double Tau
        {
            get
            {
                return _tau;
            }

            set
            {
                if (value <= 0)
                    throw new ArgumentException("tau <= 0");
                _tau = value;
            }
        }

        [DataMember]
        public double C
        {
            get
            {
                return _c;
            }

            set
            {
                if (value <= 0)
                    throw new ArgumentException("c <= 0");
                _c = value;
            }
        }

        [DataMember]
        public int TimeSteps
        {
            get
            {
                return _timeSteps;
            }

            set
            {
                _timeSteps = value;
            }
        }
    }

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

    [DataContract]
    public class InputForTemp3D : InputForTempBase
    {
        //[DataMember]
        //public double[] U
        //{
        //    get; set;
        //}

        [DataMember]
        public Array3D<double> U
        {
            get;
            set;
        }
    }

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

    [DataContract]
    public class OutputForTemp1D : OutputForTempBase
    {
        [DataMember]
        public double[] U { get; set; }
    }
}
