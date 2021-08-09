using _07_RepositoryPattern_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _07_RepositoryPattern_Tests
{
    [TestClass]
    public class StreamingContentTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            StreamingContent movie = new StreamingContent();
            Console.WriteLine($"{movie.Title} is a {movie.GenreType} movie about {movie.Description} rated {movie.MaturityRating}");
        }

        [TestMethod]
        public void SetTitle_ShouldSetCorrectstring()
        {
            // AAA pattarn
            // Arrange
            StreamingContent content = new StreamingContent();
            // Act
            content.Title = "Emoji Movie";
            // Assert
            string expected = "EMOJI MOVIE";
            string actual = content.Title;

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(MaturityRating.G, true)]
        [DataRow(MaturityRating.R, false)]
        [DataRow(MaturityRating.PG13, false)]
        [DataRow(MaturityRating.PG, true)]
        [DataRow(MaturityRating.TVMA, false)]
        public void SetMaturityRating_ShouldGetCorrectFamilyFriendy(MaturityRating rating, bool expected)
        {
            // Arrange
            StreamingContent content = new StreamingContent("Shrek", "Swamps and Ogers", 5.0, rating, GenreType.Documentary);
            // Act
            bool actual = content.IsFamilyFriendly;
            // bool expected = true;
            // Assert
            Assert.AreEqual(actual, expected);
            // Assert.IsTrue(content.IsFamilyFriendly);

        }
    }
}
