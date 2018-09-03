using System.IO;

namespace Mockery
{
    public class FileWrapper :IFileWrapper
    {
        public string ReadAllText(string filename)
        {
            return File.ReadAllText(filename);
        }

        public void WriteAllText(string fileToWriteTo, string textToWrite)
        {
            File.WriteAllText(fileToWriteTo,textToWrite);
        }
    }
}