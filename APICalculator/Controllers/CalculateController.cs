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

        // GET api/calculate/5
        [Route("result/{id}")]
        [HttpGet]
        public double GetResult([FromRoute]int id)
        {
            return _calculationService.GetResult(id);
        }

        // POST api/calculate/add
        [Route("add")]
        [HttpPost]
        public int Add([FromBody]CalculationModel model)
        {
            ValidateModel();
            return _calculationService.Add(model.X, model.Y);
        }

        // POST api/calculate/subtract
        [Route("subtract")]
        [HttpPost]
        public int Subtract([FromBody]CalculationModel model)
        {
            ValidateModel();
            return _calculationService.Subtract(model.X, model.Y);
        }

        // POST api/calculate/multiply
        [Route("multiply")]
        [HttpPost]
        public int Multiply([FromBody]CalculationModel model)
        {
            ValidateModel();
            return _calculationService.Multiply(model.X, model.Y);
        }

        // POST api/calculate/divide
        [Route("divide")]
        [HttpPost]
        public int Divide([FromBody]CalculationModel model)
        {
            ValidateModel();
            return _calculationService.Divide(model.X, model.Y);
        }

        // POST api/calculate
        [Route("exponente")]
        [HttpPost]  
        public int Exponente([FromBody]CalculationModel model)
        {
            ValidateModel();
            return _calculationService.Exponente(model.X, model.Y);
        }

        private void ValidateModel()
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Model is not valid");
            }
        }
    }
}
