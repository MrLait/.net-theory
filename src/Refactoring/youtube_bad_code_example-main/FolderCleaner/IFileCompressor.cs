using System.Collections.Generic;

namespace FolderCleaner
{
    internal interface IFileCompressor
    {
        void Compress(IEnumerable<string> files);
    }
}