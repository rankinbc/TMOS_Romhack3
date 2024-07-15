using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Mods
{
    public class Utility
    {
          public static int HexStringToInt(string hex)
        {
            byte[] bytes = Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();

            return Convert.ToInt32(bytes[0]);
        }

        public static string ToDecimalAndHexDisplayValue(int value)
        {
            return $"{value} ({value.ToString("X2")})";
        }

        public static string ToHexDisplayValue(int value)
        {
            return $"0x{value.ToString("X2")}";
        }

        public static string ToAbsoluteAndRelativeDisplayValue(int absoluteValue, int relativeValue)
        {
            return $"*{absoluteValue} ({relativeValue.ToString("X2")})";
        }
    }
}
