using NUnit.Framework;

namespace Mockery
{
    [TestFixture]
    public class TestUsingSelfShunt :IFileWrapper
    {
        private string fileWrittenTo;
        private string textWrittenToFile;

        [Test]
        public void SpudulikePrependsSpudBeforeSaving()
        {
            var spudulike = new Spudulike(this);

            spudulike.Save("Maris Piper");

            Assert.AreEqual("spud: Maris Piper", textWrittenToFile);
            Assert.AreEqual("spudfile.txt", fileWrittenTo);
        }

        // implementation of IFileWrapper
        public string ReadAllText(string filename)
        {
            return string.Empty;
        }

        public void WriteAllText(string fileToWriteTo, string textToWrite)
        {
            fileWrittenTo = fileToWriteTo;
            textWrittenToFile = textToWrite;
        }
    }
}
