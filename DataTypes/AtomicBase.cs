﻿using System;
using System.Linq.Expressions;
using System.Threading;

namespace DataTypes
{
    public abstract class AtomicBase<T> where T : struct, IEquatable<T>
    {
        protected AtomicBase(Int64 value)
        {
            ConvertedValue = value;
        }
        public T Value
        {
            get => ConvertFrom(ConvertedValue);
            set => ConvertedValue = ConvertTo(value);
        }
        private Int64 _convertedValue;

        public Int64 ConvertedValue
        {
            get => Interlocked.Read(ref _convertedValue);
            set => Interlocked.Exchange(ref _convertedValue, value);
        }

        protected abstract T ConvertFrom(Int64 backingValue);

        protected abstract Int64 ConvertTo(T backingValue);

        public static bool operator !=(AtomicBase<T> a, AtomicBase<T> b) => a.Equals(b) == false;

        public static bool operator ==(AtomicBase<T> a, AtomicBase<T> b) => a.Equals(b) == true;

        public static AtomicBase<T> operator ++(AtomicBase<T> a)
        {
            Interlocked.Increment(ref a._convertedValue);
            return a;
        }

        public static AtomicBase<T> operator --(AtomicBase<T> a)
        {
            Interlocked.Decrement(ref a._convertedValue);
            return a;
        }

        public sealed override bool Equals(object obj)
        {
            if(obj is AtomicBase<T>)
            {
                var atomic = obj as AtomicBase<T>;
                if (atomic._convertedValue == _convertedValue) return true;
            }
            return false;
        }

        public sealed override int GetHashCode()
        {
            return Value.GetHashCode() ^ 365;
        }

    }
}
