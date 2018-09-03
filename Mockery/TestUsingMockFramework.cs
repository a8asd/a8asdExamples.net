using Moq;
using NUnit.Framework;

namespace Mockery
{
    [TestFixture]
    public class TestUsingMockFramework
    {
        [Test]
        public void SpudulikePrependsSpudBeforeSaving()
        {
            var fileWrapper = new Mock<IFileWrapper>();
            var spudulike = new Spudulike(fileWrapper.Object);

            spudulike.Save("Maris Piper");

            fileWrapper.Verify(foo => foo.WriteAllText("spudfile.txt","spud: Maris Piper"));
        }
    }
}
