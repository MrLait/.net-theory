using System.Collections.Generic;

namespace FolderCleaner
{
    internal interface IFileRemover
    {
        void Remove(IEnumerable<string> files);
    }
}