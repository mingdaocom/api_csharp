using System;
using System.Collections.Generic;
using System.Text;

namespace Open.MingdaoSDK.Common
{
    public class Parameter
    {
        string _Name = null;
        string _Value = null;

        public Parameter(string NM, string Val)
        {
            this._Name = NM;
            this._Value = Val;
        }
        public string Name
        {
            get { return _Name; }
        }
        public string Value
        {
            get { return _Value; }
        }
    }

    public class ParameterComparer : IComparer<Parameter>
    {
        public int Compare(Parameter X, Parameter Y)
        {
            if (X.Name.Equals(Y.Name))
            {
                return string.Compare(X.Value, Y.Value);
            }
            else
            {
                return string.Compare(X.Name, Y.Name);
            }
        }
    }
}
