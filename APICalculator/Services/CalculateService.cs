using System;
using System.Collections.Generic;
using System.Linq;
using APICalculator.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace APICalculator.Services
{
    public class CalculateService : ICalculateService
    {
        private static Dictionary<int, decimal> _resultsStorage;
        private static int _increment;
        private static ILogger _logger;

        public CalculateService(ILogger<CalculateService> logger)
        {
            _resultsStorage = new Dictionary<int, decimal>();
            _increment = 0;
            _logger = logger;
        }
        public int Add(decimal x, decimal y)
        {
            _logger.LogInformation($"Adding number {x} and {y}");
            _resultsStorage.Add(++_increment, x + y);
            _logger.LogInformation($"Result saved with id {_increment}");
            return _increment;
        }

        public int Subtract(decimal x, decimal y)
        {
            _logger.LogInformation($"Subtracting number {x} and {y}");
            _resultsStorage.Add(++_increment, x - y);
            _logger.LogInformation($"Result saved with id {_increment}");
            return _increment;
        }

        public int Multiply(decimal x, decimal y)
        {
            _logger.LogInformation($"Multiplying number {x} and {y}");
            _resultsStorage.Add(++_increment, x * y);
            _logger.LogInformation($"Result saved with id {_increment}");
            return _increment;
        }

        public int Divide(decimal x, decimal y)
        {
            _logger.LogInformation($"Dividing number {x} and {y}");
            _resultsStorage.Add(++_increment, x / y);
            _logger.LogInformation($"Result saved with id {_increment}");
            return _increment;
        }

        public int Exponente(decimal x, decimal y)
        {
            throw new NotImplementedException();
        }

        public decimal GetResult(int id)
        {
            return _resultsStorage.Single(x => x.Key == id).Value;
        }
    }
}
