using System;

namespace Runtime
{
    public class CPU : IDisposable
    {
        private const int MEMORY_SIZE = 1024;

        private readonly Memory memory = new Memory(MEMORY_SIZE);
        private readonly Disk disk = new Disk();
        private readonly Endianess endianess = Endianess.LittleEndian;

        public Memory Memory => memory;
        public Disk Disk => disk;
        public Endianess Endianess => endianess;

        public void Dispose()
        {
            disk?.Dispose();
        }
    }
}
