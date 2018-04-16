using System;
using System.IO;

namespace Runtime
{
    public class Disk : IDisposable
    {
        private readonly FileStream file;

        public Disk(string filename = "disk.dat")
        {
            this.file = File.Open(filename, FileMode.Truncate, FileAccess.ReadWrite, FileShare.None);
        }

        public void Dispose()
        {
            file?.Flush();
            file?.Dispose();
        }
    }
}
