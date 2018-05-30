using System;
using APICalculator.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Tests
{
    public class CalculateServiceTests
    {
        private readonly CalculateService _calculateService;
        private Mock<ILogger<CalculateService>> _loggerMock;

        public CalculateServiceTests()
        {
            _loggerMock = new Mock<ILogger<CalculateService>>();
            _calculateService= new CalculateService(_loggerMock.Object);
        }

        [Fact]
        public void Add_Positive()
        {
            var index = _calculateService.Add(3, 5);
            var result = _calculateService.GetResult(index);

            Assert.Equal(8, result);
        }

        [Fact]
        public void Add_Negative()
        {
            var index = _calculateService.Add(6, 5);
            var result = _calculateService.GetResult(index);

            Assert.NotEqual(8, result);
        }

        [Fact]  
        public void Divide_Positive()
        {
            var index = _calculateService.Divide(4, 2);
            var result = _calculateService.GetResult(index);

            Assert.Equal(2, result);
        }

        [Fact]
        public void Divide_Negative()
        {
            Assert.Throws<DivideByZeroException>(() => _calculateService.Divide(6, 0));
        }

        [Fact]
        public void Exponente_Positive()
        {
            var index = _calculateService.Exponente(2, 3);
            var result = _calculateService.GetResult(index);

            Assert.Equal(8, result);
        }

        [Fact]
        public void Exponente_Negative()
        {
            var index = _calculateService.Exponente(1, 5);
            var result = _calculateService.GetResult(index);

            Assert.NotEqual(8, result);
        }
    }
}
