using System;

namespace GapSharp.Tools
{
    public static class ConvertTools
    {
        public static int? AsInt(this object input)
        {
            int? result = null;
            try
            {
                result = Convert.ToInt32(input);
            }
            catch (Exception)
            {
                // ignored
            }

            return result;
        }
        public static byte? AsByte(this object input)
        {
            byte? result = null;
            try
            {
                result = Convert.ToByte(input);
            }
            catch (Exception)
            {
                // ignored
            }

            return result;
        }
        public static long? AsLong(this object input)
        {
            long? result = null;
            try
            {
                result = Convert.ToInt64(input);
            }
            catch (Exception)
            {
                // ignored
            }

            return result;
        }

        public static int Val(this int? input, int defaultValue = 0)
        {
            return input.GetValueOrDefault(defaultValue);
        }
        public static byte Val(this byte? input, byte defaultValue = 0)
        {
            return input.GetValueOrDefault(defaultValue);
        }
        public static long Val(this long? input, long defaultValue = 0)
        {
            return input.GetValueOrDefault(defaultValue);
        }
    }
}