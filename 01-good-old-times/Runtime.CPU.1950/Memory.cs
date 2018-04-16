using System;
using System.Text;

namespace Runtime
{
    public class Memory
    {
        private readonly int capacity;
        private readonly Memory<byte> memory;

        public int Capacity => capacity;

        public Memory(int capacity = 1024)
        {
            this.capacity = capacity;
            this.memory = new Memory<byte>(new byte[capacity]);
        }

        public byte this[int index]
        {
            get
            {
                if (index >= capacity)
                {
                    throw new IndexOutOfRangeException();
                }

                return memory.Span[index];
            }

            set
            {
                if (index >= capacity)
                {
                    throw new IndexOutOfRangeException();
                }

                memory.Span[index] = value;
            }
        }

        public int Write(string data, int start, Encoding encoding)
        {
            var bytes = encoding.GetBytes(data);
            var length = bytes.Length;
            var availableBytes = capacity - start;
            length = length > availableBytes ? availableBytes : length;
                
            bytes.CopyTo(memory.Slice(start, length));

            return length;
        }

        public string ReadString(int start, int length, Encoding encoding)
        {
            return encoding.GetString(memory.Slice(start, length).ToArray());
        }

        public int Write(int data, int start, Endianess endianess)
        {
            BitConverter.GetBytes(data);

            var bytes = encoding.GetBytes(data);
            var length = bytes.Length;
            var availableBytes = capacity - start;
            length = length > availableBytes ? availableBytes : length;

            bytes.CopyTo(memory.Slice(start, length));

            return length;
        }

        public string ReadInt(int start, int length, Endianess endianess)
        {
            return encoding.GetString(memory.Slice(start, length).ToArray());
        }

        public int Write(long data, int start, Endianess endianess)
        {
            var bytes = encoding.GetBytes(data);
            var length = bytes.Length;
            var availableBytes = capacity - start;
            length = length > availableBytes ? availableBytes : length;

            bytes.CopyTo(memory.Slice(start, length));

            return length;
        }

        public string ReadLong(int start, int length, Endianess endianess)
        {
            return encoding.GetString(memory.Slice(start, length).ToArray());
        }

        public int Write(float data, int start, Endianess endianess)
        {
            var bytes = encoding.GetBytes(data);
            var length = bytes.Length;
            var availableBytes = capacity - start;
            length = length > availableBytes ? availableBytes : length;

            bytes.CopyTo(memory.Slice(start, length));

            return length;
        }

        public string ReadFloat(int start, int length, Endianess endianess)
        {
            return encoding.GetString(memory.Slice(start, length).ToArray());
        }

        public int Write(double data, int start, Endianess endianess)
        {
            var bytes = encoding.GetBytes(data);
            var length = bytes.Length;
            var availableBytes = capacity - start;
            length = length > availableBytes ? availableBytes : length;

            bytes.CopyTo(memory.Slice(start, length));

            return length;
        }

        public string ReadDouble(int start, int length, Endianess endianess)
        {
            return encoding.GetString(memory.Slice(start, length).ToArray());
        }

        public int Write(byte[] data, int start)
        {
            var bytes = encoding.GetBytes(data);
            var length = bytes.Length;
            var availableBytes = capacity - start;
            length = length > availableBytes ? availableBytes : length;

            bytes.CopyTo(memory.Slice(start, length));

            return length;
        }

        public string ReadByteArray(int start, int length)
        {
            return encoding.GetString(memory.Slice(start, length).ToArray());
        }
    }
}
