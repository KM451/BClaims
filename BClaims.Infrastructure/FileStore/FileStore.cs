using BClaims.Application.Common.Interfaces;

namespace BClaims.Infrastructure.FileStore
{
    public class FileStore(IFileWrapper _fileWrapper, IDirectoryWrapper _directoryWrapper) : IFileStore
    {
        public string SafeWriteFile(byte[] content, string sourceFileName, string path)
        {
            _directoryWrapper.CreateDirectory(path);
            var outputFile = Path.Combine(path, sourceFileName);
            _fileWrapper.WriteAllBytes(outputFile, content);
            return outputFile;
        }
    }
}
