using System;
using System.IO;
using System.Text;

namespace ExampleSimpleWebserver
{
    class FileHandler: IFileHandler
    {
        public FileStream GetFileStream(string filePath)
        {
            FileStream fileStream;
            fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            
            
            return fileStream;
        }
        public byte[] ConvertFileTOStream(string filePath)
        {
            byte[] buffer;
            try
            {
                buffer = File.ReadAllBytes(filePath);
                FileStream fileStream = GetFileStream(filePath);
                fileStream.Read(buffer, 0, Convert.ToInt32(fileStream.Length));
            }
            catch (FileNotFoundException e)
            {

                string page= "<html><body>404 Not Found</body></html>";
                buffer= Encoding.ASCII.GetBytes(page);
            }
            
            return buffer;
        }
    }
}