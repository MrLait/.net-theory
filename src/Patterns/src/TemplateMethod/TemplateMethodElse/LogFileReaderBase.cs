using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace TemplateMethod.TemplateMethodElse
{
    public abstract class LogFileReaderBase : LogImporter, IDisposable
    {
        private Lazy<Stream> _stream;

        protected LogFileReaderBase(string fileName)
        {
            _stream = new Lazy<Stream>(() => OpenFileStream(fileName));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        protected virtual Stream OpenFileStream(string fileName)
        {
            return new FileStream(fileName, FileMode.Open);
        }
    }
}
