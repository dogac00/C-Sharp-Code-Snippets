using System;

namespace Extensions
{
    public static class Converter
    {
        public static byte[] ToByteArray(int value)
        {
            var bytes = BitConverter.GetBytes(value);

            if (BitConverter.IsLittleEndian)
                return bytes;

            return bytes.Reverse();
        }
    }
}
