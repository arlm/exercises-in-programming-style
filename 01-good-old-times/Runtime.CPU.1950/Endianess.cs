using System;
namespace Runtime
{
    public enum Endianess
    {
        BigEndian,
        LittleEndian,
        MiddleEndian
    }

    public static class EndianessHelper {
        public static byte[] ConvertTo(this Endianess from, byte[] data, Endianess to, int wordSize = 32) {
            return ConvertEndianess(data, from, to, wordSize);
        }

        public static byte[] ConvertEndianess(this byte[] data, Endianess from, Endianess to, int wordSize = 32)
        {
            if (data.Length % wordSize != 0)
            {
                throw new DataMisalignedException($"Data not multiple of word size of {wordSize} bits");
            }

            if (from == to)
            {
                return data;
            }

            switch (from)
            {
                case Endianess.LittleEndian:
                    switch (to)
                    {
                        case Endianess.BigEndian:
                            return LittleToBigEndian(data, wordSize);
                        case Endianess.MiddleEndian:
                            return LittleToMiddleEndian(data, wordSize);
                        default:
                            throw new DataMisalignedException("Unknown endianess (to)");
                    }
                case Endianess.BigEndian:
                    switch (to)
                    {
                        case Endianess.LittleEndian:
                            return BigToLittleEndian(data, wordSize);
                        case Endianess.MiddleEndian:
                            return BigToMiddleEndian(data, wordSize);
                        default:
                            throw new DataMisalignedException("Unknown endianess (to)");
                    }
                case Endianess.MiddleEndian:
                    switch (to)
                    {
                        case Endianess.LittleEndian:
                            return MiddleToLittleEndian(data, wordSize);
                        case Endianess.BigEndian:
                            return MiddleToBigEndian(data, wordSize);
                        default:
                            throw new DataMisalignedException("Unknown endianess (to)");
                    }
                default:
                    throw new DataMisalignedException("Unknown endianess (from)");
            }
        }

        private static byte[] LittleToBigEndian(byte[] data, int wordSize = 32) {
            if (data.Length % wordSize != 0) {
                throw new DataMisalignedException($"Data not multiple of word size of {wordSize} bits");
            }

        }

        private static byte[] BigToLittleEndian(byte[] data, int wordSize = 32)
        {
            if (data.Length % wordSize != 0)
            {
                throw new DataMisalignedException($"Data not multiple of word size of {wordSize} bits");
            }

        }

        private static byte[] LittleToMiddleEndian(byte[] data, int wordSize)
        {
            if (data.Length % wordSize != 0)
            {
                throw new DataMisalignedException($"Data not multiple of word size of {wordSize} bits");
            }

        }

        private static byte[] BigToMiddleEndian(byte[] data, int wordSize = 32)
        {
            if (data.Length % wordSize != 0)
            {
                throw new DataMisalignedException($"Data not multiple of word size of {wordSize} bits");
            }

        }

        private static byte[] MiddleToBigEndian(byte[] data, int wordSize = 32)
        {
            if (data.Length % wordSize != 0)
            {
                throw new DataMisalignedException($"Data not multiple of word size of {wordSize} bits");
            }

        }

        private static byte[] MiddleToLittleEndian(byte[] data, int wordSize = 32)
        {
            if (data.Length % wordSize != 0)
            {
                throw new DataMisalignedException($"Data not multiple of word size of {wordSize} bits");
            }

        }
    }
}
