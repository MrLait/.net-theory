using System.IO;

namespace TemplateMethod.TemplateMethodElse
{
    class FakeLogFileReader : LogFileReaderBase
    {
        private readonly MemoryStream _mockStream;
        public FakeLogFileReader(MemoryStream mockStream)
            : base(string.Empty)
        {
            _mockStream = mockStream;
        }

        protected override Stream OpenFileStream(string fileName)
        {
            return _mockStream;
        }

        //public void TestFakedMemoryStreamProvidedOneElement()
        //{
        //    // Arrange
        //    LogFileReaderBase cut = new FakeLogFileReader(GetMemoryStreamWithOneElement());
        //    // Act
        //    var logEntries = cut.ReadLogEntry();
        //    // Assert
        //    Assert.That(logEntries.Count(), Is.EqualTo(1));
        //}


    }
}
