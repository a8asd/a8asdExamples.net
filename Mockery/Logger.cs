namespace Mockery
{
    public class Logger
    {
        private readonly IFileWrapper file;

        public Logger(IFileWrapper fileWrapper)
        {
            file = fileWrapper;
        }

        public int Status { get; private set; }

        public void Save(string textToSave)
        {
             file.WriteAllText("spudfile.txt", "log: " + textToSave);
        }
    }
}