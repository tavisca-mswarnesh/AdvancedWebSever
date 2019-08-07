using System;
using System.IO;

namespace ExampleSimpleWebserver
{
    class FileHandler: IFileHandler
    {
        public FileStream GetFileStream(string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return fileStream;
        }
        public byte[] ConvertFileTOStream(string filePath)
        {
            byte[] buffer = File.ReadAllBytes(filePath);
            FileStream fileStream = GetFileStream(filePath);
            fileStream.Read(buffer, 0, Convert.ToInt32(fileStream.Length));
            return buffer;
        }
    }
}