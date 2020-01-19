using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeatBalance.Class
{
    [Serializable]
    public class Param
    {
        public Param() { }

        public Param(Double inValue) { Value = inValue; }
        [NonSerialized()]
        private Double _value;
        public Double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _propertyName;
        public string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }

        private Boolean _isreport;
        public Boolean IsReport
        {
            get { return _isreport; }
            set { _isreport = value; }
        }

        public static Param operator +(Param valF, Param valS)
        {
            return new Param(valF.Value + valS.Value);
        }

        public static Param operator -(Param valF, Param valS)
        {
            return new Param(valF.Value - valS.Value);
        }

        public static Param operator *(Param valF, Param valS)
        {
            return new Param(valF.Value * valS.Value);
        }

        public static Param operator /(Param valF, Param valS)
        {
            return new Param(valF.Value / valS.Value);
        }

        public static implicit operator double(Param inP)
        {
            return inP.Value;
        }

        public static implicit operator Param(double inD)
        {
            return new Param(inD);
        }
    }

    [Serializable]
    public class cParamInput : Param
    {
    }
    [Serializable]
    public class cParamOutput : Param
    {
    }
    
}
