using NUnit.Framework;

namespace Mockery
{
    [TestFixture]
    public class TestUsingFileWrapper
    {
        [Test]
        public void SpudulikePrependsSpudBeforeSaving()
        {
            var fileWrapper = new FileWrapper();
            var spudulike = new Spudulike(fileWrapper);

            spudulike.Save("Maris Piper");

            Assert.AreEqual("spud: Maris Piper", fileWrapper.ReadAllText("spudfile.txt"));
        }
    }
}
