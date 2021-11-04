using BlueBadge.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BlueBadge.Tests
{
    [TestClass]
    public class QuestionTests
    {
        [TestMethod]
        public void Title_ShouldReturnCorrectString()
        {
            var content = new Question();
            content.Title = "Test";
            string expected = "Test";
            string actual = content.Title;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PollQuestion_ShouldReturnCorrectString()
        {
            var content = new Question();
            content.PollQuestion = "Test";
            string expected = "Test";
            string actual = content.PollQuestion;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreatedUtc_ShouldReturnCorrectDate()
        {
            var content = new Question();
            content.CreatedUtc = DateTimeOffset.UtcNow;
            var expected = DateTimeOffset.UtcNow;
            var actual = content.CreatedUtc;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ModifiedUtc_ShouldReturnCorrectDate()
        {
            var content = new Question();
            content.ModifiedUtc = DateTimeOffset.UtcNow;
            var expected = DateTimeOffset.UtcNow;
            var actual = content.ModifiedUtc;

            Assert.AreEqual(expected, actual);
        }
    }
}
