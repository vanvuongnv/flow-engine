using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowApp.Abstracts;
using FlowApp.Entities;
using FlowApp.Models;
using FlowApp.Models.ApiModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlowApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IRepository _repository;
        public ValuesController(IRepository repository)
        {
            _repository = repository;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ConditionModel request)
        {
            // validation input
            if (!Operate.IsValid(request.OperateCode))
            {
                ModelState.AddModelError("", "Invalid operate");
            }
            if (!Rule.IsValid(request.TargetRuleCode))
            {
                ModelState.AddModelError("", "Invalid rule");
            }
            if (!Match.IsValid(request.OperateMatchCode))
            {
                ModelState.AddModelError("", "Invalid match");
            }
            var question = Question.Items.FirstOrDefault(x => x.QuestionId == request.QuestionId);
            if(question is null)
            {
                ModelState.AddModelError("", "Question not found");
            }

            if (ModelState.IsValid)
            {
                var condition = new Condition()
                {
                    Input = request.Input,
                    QuestionId = request.QuestionId,
                    Operate = request.OperateCode,
                    OperateMatch = request.OperateMatchCode,
                    TargetRule = request.TargetRuleCode
                };
                _repository.Add(condition);

                var result = await _repository.SaveChangesAsync();

                if (result)
                {
                    return NoContent();
                }
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] ConditionModel request)
        {
            // check condition exist
            var condition = _repository.Conditions.FirstOrDefault(x => x.Id == id);
            if(condition is null)
            {
                return NotFound();
            }
            // validation input
            if (!Operate.IsValid(request.OperateCode))
            {
                ModelState.AddModelError("", "Invalid operate");
            }

            if (!Rule.IsValid(request.TargetRuleCode))
            {
                ModelState.AddModelError("", "Invalid rule");
            }

            if (!Match.IsValid(request.OperateMatchCode))
            {
                ModelState.AddModelError("", "Invalid match");
            }

            var question = Question.Items.FirstOrDefault(x => x.QuestionId == request.QuestionId);
            if (question is null)
            {
                ModelState.AddModelError("", "Question not found");
            }

            if (ModelState.IsValid)
            {
                condition.Input = request.Input;
                condition.QuestionId = request.QuestionId;
                condition.Operate = request.OperateCode;
                condition.OperateMatch = request.OperateMatchCode;
                condition.TargetRule = request.TargetRuleCode;
                
                _repository.Update(condition);

                var result = await _repository.SaveChangesAsync();

                if (result)
                {
                    return NoContent();
                }
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            // check condition exist
            var condition = _repository.Conditions.FirstOrDefault(x => x.Id == id);
            if (condition is null)
            {
                return NotFound();
            }

            _repository.Delete(condition);

            var result = await _repository.SaveChangesAsync();

            if (result)
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CollectUser(int? userId,
            int questionId,
            string input)
        {            
            var question = Question.Items.FirstOrDefault(x => x.QuestionId == questionId);
            if (question is null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Candidate? candidate = null;
                if (userId is null)
                {
                    candidate = new Candidate();
                    _repository.Add(candidate);

                    var addResult = await _repository.SaveChangesAsync();

                    if (!addResult)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    candidate = _repository.Candidates.FirstOrDefault(x => x.Id == userId);
                    if(candidate is null)
                    {
                        return NotFound();
                    }
                }

                switch (questionId)
                {
                    case 1:
                        candidate.Age = Convert.ToInt32(input);
                        break;
                    case 2:
                        candidate.HomeTown = input;
                        break;
                    case 3:
                        candidate.University = input;
                        break;
                }

                _repository.Update(candidate);

                var result = await _repository.SaveChangesAsync();

                if (result)
                {
                    return Ok(candidate);
                }
            }

            return BadRequest();
        }
    }
}

