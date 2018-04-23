using System;
using System.Runtime.Serialization;

namespace MathLib
{
   
    
    public interface IHeatFlow
    {
       
        
        OutputForTemp CalculateTemp(InputForTemp input);

    }
    
    public class OutputForTempBase
    {
      
        public string OutputMessage
        {
            get; set;
        }
    }
    
    public class OutputForTemp : OutputForTempBase
    {
        
        public double[][] U
        {
            get; set;
        }
    }

    
    public class OutputForTemp3D : OutputForTempBase
    {
        [DataMember]
        public double[] U
        {
            get; set;
        }
    }

   
    public class InputForTempBase
    {
        private double _h;
        private double _tau;
        private double _c;
        private int _timeSteps;
        
        public string InputMessage
        {
            get; set;
        }

        
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

   
    public class InputForTemp : InputForTempBase
    {
        
        public double[][] U
        {
            get; set;
        }
    }


    public class InputForTemp3D : InputForTempBase
    {
        [DataMember]
        public double[] U
        {
            get; set;
        }
    }
}
