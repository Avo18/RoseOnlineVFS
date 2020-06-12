using System;

namespace DataTypes
{
    public class AtomicInteger : AtomicBase<int>
    {
        public AtomicInteger(int value = default)
            :base(Convert.ToInt64(value))
        {
        }

        protected override int ConvertFrom(long backingValue)
            => Convert.ToInt32(backingValue);

        protected override long ConvertTo(int backingValue) 
            => Convert.ToInt64(backingValue);
    }
}
