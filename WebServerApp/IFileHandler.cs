using System.IO;

namespace SimpleWebserver
{
    public interface IFileHandler
    {
         byte[] ConvertFileTOStream(string filePath);
         FileStream GetFileStream(string filePath);
    }
}