using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfMathLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // TODO: Add your service operations here
        [OperationContract]
        OutputForTemp CalculateTemp(InputForTemp input);
        
    }
    [DataContract]
    public class OutputForTemp
    {
        [DataMember]
        public double[,] U
        {
            get; set;
        }

        [DataMember]
        public string OutputMessage
        {
            get; set;
        }
    }

    [DataContract]
    public class InputForTemp
    {
        private double _h;
        private double _tau;
        private double _c;
        private int _timeSteps;
        [DataMember]
        public string InputMessage
        {
            get; set;
        }

        [DataMember]
        public double[,] U
        {
            get; set;
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
}
