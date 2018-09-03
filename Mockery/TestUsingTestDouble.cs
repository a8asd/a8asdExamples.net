using NUnit.Framework;

namespace Mockery
{
    [TestFixture]
    public class TestUsingTestDouble
    {
        [Test]
        public void SpudulikePrependsSpudBeforeSaving()
        {
            var fileWrapper = new FileWrapperTestDouble();
            var spudulike = new Spudulike(fileWrapper);

            spudulike.Save("Maris Piper");

            Assert.AreEqual("spud: Maris Piper", fileWrapper.TextWrittenToFile);
            Assert.AreEqual("spudfile.txt", fileWrapper.FileWrittenTo);
        }
    }
}
