using System;
using System.Collections.Generic;
using System.Text;

namespace RoseOnline.Streaming.VFS
{
    public static class Validations
    {
        public static T NotNull<T>(T value) where T : class
        {
            if (value == null)
                throw new NullReferenceException($"{nameof(T)} is null");
            return value;
        }

        public static string NotNullOrEmpty(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new Exception("the string value is empty or null");
            return value;
        }
    }
}
