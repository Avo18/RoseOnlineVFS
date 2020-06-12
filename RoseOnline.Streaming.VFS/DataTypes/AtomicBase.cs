using System;
using System.Threading;

namespace RoseOnline.Streaming.VFS.DataTypes
{
    public abstract class AtomicBase<T> where T : struct
    {
        protected AtomicBase(Int64 value)
        {
            _convertedValue = value;
        }
        protected T Value
        {
            get => ConvertFrom(ConvertedValue);
            set => _convertedValue = ConvertTo(value);
        }
        private Int64 _convertedValue;

        public Int64 ConvertedValue
        {
            get => Interlocked.Read(ref _convertedValue);
            set => Interlocked.Exchange(ref _convertedValue, value);
        }

        protected abstract T ConvertFrom(Int64 backingValue);

        protected abstract Int64 ConvertTo(T backingValue);
    }
}
