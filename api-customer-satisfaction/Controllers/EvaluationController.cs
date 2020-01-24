using api_customer_satisfaction.Models;
using api_customer_satisfaction.Models.Repository;
using api_customer_satisfaction.ServiceSoap.DataContract;
using api_customer_satisfaction.ServiceSoap.ServiceContract;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace api_customer_satisfaction.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        private readonly IDataRepository<Evaluation> _dataRepository;
        private readonly IEvaluationService _evaluationService;        
        public EvaluationController(IDataRepository<Evaluation> dataRepository, IEvaluationService evaluationService)
        {
            _dataRepository = dataRepository;
            _evaluationService = evaluationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Evaluation> evaluations = _dataRepository.GetAll();
            return Ok(evaluations);
        }

        [HttpPost("AddEvaluation")]
        public IActionResult Post([FromBody] Evaluation evaluation)
        {
            if (evaluation == null)
            {
                return BadRequest("Evaluación erronea.");
            }
            _dataRepository.Add(evaluation);
            return Ok(evaluation);
        }

        [HttpGet("GetEvaluationById")]
        public IActionResult Get(int id)
        {
            Evaluation evaluation = _dataRepository.GetById(id);
            if (evaluation == null)
            {
                return NotFound("No se encontró la evaluación.");
            }
            return Ok(evaluation);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Evaluation evaluation)
        {
            if (evaluation == null)
            {
                return BadRequest("Evaluación erronea.");
            }

            Evaluation evaluationToUpdate = _dataRepository.GetById(id);
            if (evaluationToUpdate == null)
            {
                return NotFound("Evaluación no encontrada.");
            }

            _dataRepository.Update(evaluationToUpdate, evaluation);
            return Ok(evaluationToUpdate);
        }

        [HttpGet("GetAllByDateRange")]
        public IActionResult GetAllByDateRange(DateTime begin, DateTime end)
        {
            IEnumerable<Evaluation> evaluations = _dataRepository.GetAllByDateRange(begin, end);
            return Ok(evaluations);
        }

        [HttpPost("GetAllSoap")]
        public IEnumerable<EvaluationModel> GetAllSoap()
        {
            return _evaluationService.GetAllSoap();
        }
        [HttpPost("GetByIdSoap")]
        public EvaluationModel GetByIdSoap(int id)
        {
            return _evaluationService.GetByIdSoap(id);
        }
    }
}