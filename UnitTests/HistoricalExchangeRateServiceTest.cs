using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.Threading.Tasks;
using Take_Home_Assignment.Controllers;
using Take_Home_Assignment.Models;

namespace UnitTests
{
    [TestClass]
    public class HistoricalExchangeRateServiceTest
    {
        [TestMethod]
        public async Task GetHistoricalExchangeRate_WithAverage2_ShouldReturnAverage2()
        {
            // Arrange
            string response = File.ReadAllText(@"TestData\HistoryWithAverage2.json");
            Mock<IHttpClientWrapper> httpClientWrapperMock = new Mock<IHttpClientWrapper>();
            httpClientWrapperMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(response));
            HistoricalExchangeRateService historicalExchangeRateService = 
                new HistoricalExchangeRateService(httpClientWrapperMock.Object);

            // Act
            HistoricalExchangeRate historicalExchangeRate = await historicalExchangeRateService
                .GetHistoricalExchangeRate(new DateTime(2018,2,1), new DateTime(2018,2,3), "SEK", "NOK");

            // Assert
            decimal avg = 2;
            Assert.AreEqual(historicalExchangeRate.AverageExchangeRate, avg);
        }

        // TODO more tests
    }
}
