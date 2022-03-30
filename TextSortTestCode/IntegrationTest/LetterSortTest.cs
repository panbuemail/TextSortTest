using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTest;
using Moq;
using System;

namespace IntegrationTest
{
    [TestClass]
    public class LetterSortTest
    {
        private ILogger logger = new ConsoleLogger();
        private LetterSorting letterSort;

        [TestInitialize]
        public void UnitTestInitialize()
        {
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(m => m.Log(It.IsAny<string>()));
            letterSort = new LetterSorting(mockLogger.Object);
            letterSort.AddFilter(new SpecialCharacterFilter());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Empty string was allowed as input.")]
        public void NullExceptionForEmptyStringInput()
        {
            letterSort.LetterSortingByAlphabetCase("");
        }

        [TestMethod]
        public void WordSort()
        {
            Assert.AreEqual("Boom Zoom", letterSort.LetterSortingByAlphabetCase("Zoom Boom"));
        }

        [TestMethod]
        public void CaseSort()
        {        
            Assert.AreEqual("Boom boom", letterSort.LetterSortingByAlphabetCase("boom Boom"));
        }

         [TestMethod]
        public void RemoveInvalidChars()
        {
            Assert.AreEqual("b b", letterSort.LetterSortingByAlphabetCase("b, b"));
        }

        [TestMethod]
        public void RemoveInvalidComma_SortByAlphabetCase()
        {
            Assert.AreEqual("baby Go go", letterSort.LetterSortingByAlphabetCase("Go baby, go"));
        }

        [TestMethod]
        public void RemoveInvalidPeriodChar_SortByAlphabetCase()
        {
            Assert.AreEqual("ABC aBc abc CBA CBA cba", letterSort.LetterSortingByAlphabetCase("CBA, abc aBc ABC cba CBA."));
        }
    }
}