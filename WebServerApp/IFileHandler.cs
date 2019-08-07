using System.IO;

namespace ExampleSimpleWebserver
{
    public interface IFileHandler
    {
         byte[] ConvertFileTOStream(string filePath);
         FileStream GetFileStream(string filePath);
    }
}