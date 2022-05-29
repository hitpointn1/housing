using Housing.Services.Queries.Dto;
using Housing.Services.Queries.Enums;
using NUnit.Framework;

namespace Housing.Tests
{
    public class DateHelpersTests
    {
        [TestCase("2022", "3")]
        public void Month(string year, string month)
        {
            var date = new RequestDto(year, month, ReportType.Monthly).Date.GetValueOrDefault();

            Assert.AreEqual(1, date.Day);
            Assert.AreEqual(3, date.Month);
            Assert.AreEqual(2022, date.Year);
        }

        [TestCase("2022", "2")]
        public void Month_WithoutTypeSpecified(string year, string month)
        {
            var date = new RequestDto(year, month, null).Date.GetValueOrDefault();

            Assert.AreEqual(1, date.Day);
            Assert.AreEqual(2, date.Month);
            Assert.AreEqual(2022, date.Year);
        }

        [TestCase("2022", "1", 1)]
        [TestCase("2022", "2", 1)]
        [TestCase("2022", "3", 1)]
        [TestCase("2022", "4", 4)]
        [TestCase("2022", "5", 4)]
        [TestCase("2022", "6", 4)]
        [TestCase("2022", "7", 7)]
        [TestCase("2022", "8", 7)]
        [TestCase("2022", "9", 7)]
        [TestCase("2022", "10", 10)]
        [TestCase("2022", "11", 10)]
        [TestCase("2022", "12", 10)]
        public void Quarter(string year, string month, int expectedMonth)
        {
            var date = new RequestDto(year, month, ReportType.Quaterly).Date.GetValueOrDefault();

            Assert.AreEqual(1, date.Day);
            Assert.AreEqual(expectedMonth, date.Month);
            Assert.AreEqual(2022, date.Year);
        }
    }
}
