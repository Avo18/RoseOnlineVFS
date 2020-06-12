using System;

namespace DataTypes
{
    public class AtomicBoolean : AtomicBase<bool>
    {
        public AtomicBoolean(bool value = default)
            :base(value ? 1 : 0)
        {

        }
        protected override bool ConvertFrom(long backingValue) => backingValue != 0;

        protected override long ConvertTo(bool backingValue) => backingValue ? 1 : 0;
    }
}
