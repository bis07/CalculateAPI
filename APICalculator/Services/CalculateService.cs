using System;
using System.Collections.Generic;
using System.Linq;
using APICalculator.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace APICalculator.Services
{
    public class CalculateService : ICalculateService
    {
        private static Dictionary<int, double> _resultsStorage;
        private static int _increment;
        private static ILogger _logger;

        public CalculateService(ILogger<CalculateService> logger)
        {
            _resultsStorage = new Dictionary<int, double>();
            _increment = 0;
            _logger = logger;
        }

        public int Add(double x, double y)
        {
            _logger.LogInformation($"Adding number {x} and {y}");
            _resultsStorage.Add(++_increment, x + y);
            _logger.LogInformation($"Result saved with id {_increment}");
            return _increment;
        }

        public int Subtract(double x, double y)
        {
            _logger.LogInformation($"Subtracting number {x} and {y}");
            _resultsStorage.Add(++_increment, x - y);
            _logger.LogInformation($"Result saved with id {_increment}");
            return _increment;
        }

        public int Multiply(double x, double y)
        {
            _logger.LogInformation($"Multiplying number {x} and {y}");
            _resultsStorage.Add(++_increment, x * y);
            _logger.LogInformation($"Result saved with id {_increment}");
            return _increment;
        }

        public int Divide(double x, double y)
        {
            if (y.Equals(0))
            {
                throw new DivideByZeroException("Can not divide by zero");
            }
            _logger.LogInformation($"Dividing number {x} and {y}");
            _resultsStorage.Add(++_increment, x / y);
            _logger.LogInformation($"Result saved with id {_increment}");
            return _increment;
        }

        public int Exponente(double x, double y)
        {
            _logger.LogInformation($"Exponente number {x} {y} times");
            _resultsStorage.Add(++_increment, Math.Pow(x, y));
            _logger.LogInformation($"Result saved with id {_increment}");
            return _increment;
        }

        public double GetResult(int id)
        {
            return _resultsStorage.Single(x => x.Key == id).Value;
        }
    }
}
