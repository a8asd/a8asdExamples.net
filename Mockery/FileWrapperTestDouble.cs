namespace Mockery
{
    public class FileWrapperTestDouble:IFileWrapper
    {
        public string FileWrittenTo;
        public string TextWrittenToFile;

        public string ReadAllText(string filename)
        {
            return string.Empty;
        }

        public void WriteAllText(string fileToWriteTo, string textToWrite)
        {
            FileWrittenTo = fileToWriteTo;
            TextWrittenToFile = textToWrite;
        }
    }
}