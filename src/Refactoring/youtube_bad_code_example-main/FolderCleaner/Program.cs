using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;

namespace FolderCleaner
{
    public enum FileAction
    {
        None,
        Delete,
        Compress,
    }
    class Program
    {
        private static string _pathName = @"C:\Sandbox\Test";
        private static FileAction _action = FileAction.None;
        private static string _searchPattern = FolderCleanerConstants.TxtSearchPattern;
        private static bool _isAllDirectories = true;

        static void Main(string[] args)
        {
            var fileSystem = new FileSystem();
            var files = GetFiles(fileSystem);
            _action = FileAction.Delete;
            GetFileAction(files, _action);

            Console.WriteLine(FolderCleanerConstants.StatusOk);
            Console.ReadKey();

        }

        private static void GetFileAction(IEnumerable<string> files, Enum action)
        {
            switch (action)
            {
                case FileAction.Delete:
                    var fileRemover = new FileRemover();
                    fileRemover.Remove(files);
                    break;
                case FileAction.Compress:
                    var fileCompressor = new FileCompressor();
                    fileCompressor.Compress(files);
                    break;
                default:
                    throw new Exception(FolderCleanerConstants.ActionIsUnsuported);
            }
        }

        private static IEnumerable<string> GetFiles(FileSystem fileSystem)
        {
            IEnumerable<string> files;

            try
            {
                if (_isAllDirectories)
                {
                    files = fileSystem.Directory.EnumerateFiles(_pathName, _searchPattern, SearchOption.AllDirectories);
                }
                else
                {
                    files = fileSystem.Directory.EnumerateFiles(_pathName, _searchPattern, SearchOption.TopDirectoryOnly);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return files;
        }
    }

    class FileRemover : IFileRemover
    {
        private readonly IFileSystem _fileSystem;
        public FileRemover(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void Remove(IEnumerable<string> files)
        {
            foreach (var file in files)
            {
                _fileSystem.File.Delete(file);
            }
        }
    }

    class FileCompressor : IFileCompressor
    {
        public void Compress(IEnumerable<string> files)
        {
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                var directoryName = Path.GetDirectoryName(file);
                var zipFileFullPath = Path.Combine(directoryName, $"{fileName}{FolderCleanerConstants.ZipType}");

                using (ZipOutputStream zipOutputStream = new ZipOutputStream(File.Create(zipFileFullPath)))
                {
                    zipOutputStream.SetLevel(FolderCleanerConstants.LevelNine);

                    var buffer = new byte[4098];

                    ZipEntry entryName = new ZipEntry(Path.GetFileName(file)) { DateTime = DateTime.Now };
                    zipOutputStream.PutNextEntry(entryName);

                    using (FileStream fileStream = File.OpenRead(file))
                    {
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fileStream.Read(buffer, 0, buffer.Length);
                            zipOutputStream.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }

                    zipOutputStream.Finish();
                    zipOutputStream.Close();
                }

                Console.WriteLine(FolderCleanerConstants.ArchiveHasCreated);
            }
        }
    }
}
