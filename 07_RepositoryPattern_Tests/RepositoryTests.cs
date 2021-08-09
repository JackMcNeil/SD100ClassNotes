using _07_RepositoryPattern_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_RepositoryPattern_Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private StreamingContentRepository _repo;
        private StreamingContent _content;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new StreamingContentRepository();
            _content = new StreamingContent("Sharknado", "Shark's take over NYC", 5.0, MaturityRating.PG13, GenreType.Comedy);

            _repo.AddContentToDirectory(_content);
        }

        [TestMethod]
        public void AddContent_ShouldReturnTrue()
        {
            // Arrange
            StreamingContentRepository repo = new StreamingContentRepository();
            StreamingContent content = new StreamingContent();
            content.Title = "Over the Hedge";
            // Act
            bool addResult = repo.AddContentToDirectory(content);
            // Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            StreamingContentRepository repo = new StreamingContentRepository();

            StreamingContent content = new StreamingContent();
            content.Title = "Con Air";

            repo.AddContentToDirectory(content);

            List<StreamingContent> contents = repo.GetContents();

            bool directoryHasContent = contents.Contains(content);

            Assert.IsTrue(directoryHasContent);
        }

        [TestMethod]
        public void GetContentByTitle_ShouldGetCorrectContent()
        {
            StreamingContent content = _repo.GetContentByTitle("SHARKNADO");

            Assert.AreEqual(_content, content);
        }

        [TestMethod]
        public void GetFamilyFriendlyContent_ShouldAllBeFamilyFriendly()
        {
            StreamingContent safeItem = new StreamingContent();
            StreamingContent unSafeItem = new StreamingContent();

            safeItem.MaturityRating = MaturityRating.G;
            unSafeItem.MaturityRating = MaturityRating.R;

            _repo.AddContentToDirectory(safeItem);
            _repo.AddContentToDirectory(unSafeItem);

            List<StreamingContent> familyFriendlyContents = _repo.GetFamilyFriendlyContent();

            int numOfUnsafeItems = familyFriendlyContents.Where(s => !s.IsFamilyFriendly).ToList().Count;

            Assert.AreEqual(0, numOfUnsafeItems);
        }

        [TestMethod]
        public void MyTestMethod()
        {
            StreamingContent newData = new StreamingContent("Sharknado", "Sharks inside a tornado", 4.5, MaturityRating.PG13, GenreType.Action);

            _repo.UpdateExistingContent("SHARKNADO", newData);

            var expected = GenreType.Action;
            var actual = _content.GenreType;

            Assert.AreEqual(expected, actual);
        }
    }
}
