using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WindowsForm
{
    public static class GlobalFunction
    {
        public static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(new Random().Next(v.Length));
        }
    }
}
