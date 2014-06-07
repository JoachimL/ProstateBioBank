using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProstateBioBank.ObjectExtensions
{
    public static class Object
    {
        public static T GetOrThrowArgumentNullException<T>(this object obj, T value, string argumentName) where T : class
        {
            if (value == null)
                throw new ArgumentNullException(argumentName);
            return value;
        }
    }
}
