using System;

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
