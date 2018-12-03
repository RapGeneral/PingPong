using System;

namespace PingPong.Providers.Validation
{
    public static class Validator
    {
        public static void IfNull(object o, string msg)
        {
            if (o is null)
                throw new ArgumentNullException(msg);
        }
		public static void IfNull(object o)
		{
			if (o is null)
				throw new ArgumentNullException();
		}
		public static void IfIsInRangeInclusive<T>(T item, T min, T max, string msg) where T : IComparable
		{
			if (item.CompareTo(min) < 0 || item.CompareTo(max) > 0)
				throw new ArgumentOutOfRangeException(msg);
		}
		public static void IsNonNegative(int item, string msg)
		{
			if (item < 0)
				throw new ArgumentOutOfRangeException(msg);
		}
		public static void IsPositive(int item, string msg)
		{
			if (item <= 0)
				throw new ArgumentOutOfRangeException(msg);
		}
		public static void IsLetter(char symbol, string msg)
		{
			if (!Char.IsLetter(symbol))
				throw new ArgumentException(msg);
		}
    }
}
