using System;

namespace Mockery
{
    public class Spudulike
    {
        private readonly IFileWrapper file;

        public Spudulike(IFileWrapper fileWrapper)
        {
            file = fileWrapper;
        }

        public int Status { get; private set; }

        public void Save(string textToSave)
        {
             file.WriteAllText("spudfile.txt", "spud: " + textToSave);
        }
    }
}