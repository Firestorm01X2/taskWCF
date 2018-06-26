namespace WcfMathLibrary.Integrals
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class IntegralInput
    {
        private double _a;
        private double _b;
        private int _n;
        private Func<double, double> _integrand;

        [DataMember]
        public double A
        {
            get
            {
                return _a;
            }
            set
            {
                _a = value;
            }
        }

        [DataMember]
        public double B
        {
            get
            {
                return _b;
            }
            set
            {
                if (value < _a) { throw new ArgumentException("b<a"); }
                _b = value;
            }
        }

        [DataMember]
        public int N
        {
            get { return _n; }
            set { _n = value; }
        }

        [DataMember]
        public Func<double, double> Integrand
        {
            get { return _integrand; }
            set { _integrand = value; }
        }
    }
}
