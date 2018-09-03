namespace Mockery
{
    public interface IFileWrapper
    {
        string ReadAllText(string filename);
        void WriteAllText(string fileToWriteTo, string textToWrite);
    }
}