namespace WcfMathLibrary.Temperature
{
    using System;
    using System.Runtime.Serialization;
    
    [DataContract]
    public class InputForTempBase
    {
        private double _h;
        private double _tau;
        private double _c;
        private int _timeSteps;

        [DataMember]
        public string InputMessage { get; set; }

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
