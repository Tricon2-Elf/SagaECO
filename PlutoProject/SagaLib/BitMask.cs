using System;

namespace SagaLib
{
    public class BitMask<T>
    {
        BitMask ori;

        public BitMask()
        {
            this.ori = new BitMask();
        }

        public BitMask(BitMask ori)
        {
            this.ori = ori;
        }

        public bool Test(T Mask)
        {
            return ori.Test(Mask);
        }

        public void SetValue(T bitmask, bool val)
        {
            ori.SetValue(bitmask, val);
        }

        public int Value
        {
            get { return ori.Value; }
            set { ori.Value = value; }
        }

        public ulong LongValue
        {
            get { return ori.LongValue; }
            set { ori.LongValue = value; }
        }

        public static implicit operator BitMask<T>(BitMask ori)
        {
            return new BitMask<T>(ori);
        }
    }

    [Serializable]
    public class BitMask
    {
        ulong value;

        public int Value
        {
            get { return unchecked((int)this.value); }
            set { this.value = (uint)value; }
        }

        public ulong LongValue
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public BitMask()
        {
            value = 0;
        }

        public BitMask(int value)
        {
            this.value = (uint)value;
        }

        public BitMask(ulong value)
        {
            this.value = value;
        }

        public BitMask(bool[] values)
        {
            this.value = 0;
            for (byte i = 0; i < values.Length; i++)
            {
                if (i >= 64)
                    break;
                this.SetValue(1UL << i, values[i]);
            }
        }

        public bool Test(object Mask)
        {
            return Test(Convert.ToUInt64(Mask));
        }

        public bool Test(int Mask)
        {
            return Test((ulong)(uint)Mask);
        }

        public bool Test(ulong Mask)
        {
            return (value & Mask) != 0;
        }

        public void SetValue(object bitmask, bool val)
        {
            SetValue(Convert.ToUInt64(bitmask), val);
        }

        public void SetValue(int bitmask, bool val)
        {
            SetValue((ulong)(uint)bitmask, val);
        }

        public void SetValueForNum(double n, bool val)
        {
            ulong bitmask = (ulong)Math.Pow(2, (n - 1));
            SetValue(bitmask, val);
        }

        public void SetValue(ulong bitmask, bool val)
        {
            if (this.Test(bitmask) != val)
            {
                if (val)
                    value = value | bitmask;
                else
                    value = value ^ bitmask;
            }
        }
    }
}
