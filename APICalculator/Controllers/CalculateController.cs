using System;
using APICalculator.Models;
using APICalculator.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace APICalculator.Controllers
{
    [Route("api/[controller]")]
    public class CalculateController : Controller
    {
        private readonly ICalculateService _calculationService;
        public CalculateController(ICalculateService calculationService)
        {
            _calculationService = calculationService;
        }

        // GET api/Calculate/5
        [Route("result/{id}")]
        [HttpGet]
        public decimal GetResult([FromRoute]int id)
        {
            return _calculationService.GetResult(id);
        }

        // POST api/Calculate
        [Route("add")]
        [HttpPost]
        public int Add([FromBody]CalculationModel model)
        {
            return _calculationService.Add(model.X, model.Y);
        }

        // POST api/Calculate
        [Route("subtract")]
        [HttpPost]
        public int Subtract([FromBody]CalculationModel model)
        {
            return _calculationService.Subtract(model.X, model.Y);
        }

        // POST api/Calculate
        [Route("multiply")]
        [HttpPost]
        public int Multiply([FromBody]CalculationModel model)
        {
            return _calculationService.Multiply(model.X, model.Y);
        }

        // POST api/Calculate
        [Route("divide")]
        [HttpPost]
        public int Divide([FromBody]CalculationModel model)
        {
            if (model.Y.Equals(0m))
            {
                throw new DivideByZeroException("Can not divide by zero");
            }
            return _calculationService.Divide(model.X, model.Y);
        }
    }
}
