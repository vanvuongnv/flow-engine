using System;
using System.Collections.Generic;
using System.Linq;
using FlowApp.Abstracts;
using FlowApp.Data;
using FlowApp.Entities;
using FlowApp.Models;

namespace FlowApp.Concrete
{
	public class FlowEngine : IFlowEngine
    {
        private readonly DataContext _context;
        
        public FlowEngine(DataContext context)
        {
            _context = context;
        }

        public bool Run(int questionId, Candidate candidate)
        {
            // load conditions theo câu hỏi
            var conditions = _context.Conditions.Where(x => x.QuestionId == questionId).ToList();

            // xác định operate là AND hay OR
            var lastOperate = conditions.LastOrDefault()?.Operate;

            foreach(var condition in conditions)
            {
                var rule = Rule.GetRule(condition.TargetRule);
                var match = MatchFactory.Create(condition.OperateMatch);

                if (rule == Rule.Age)
                {
                    if(!match.IsMatch(candidate.Age.ToString(), condition.Input))
                    {
                        return false;
                    }
                    continue;
                }
                if(rule == Rule.Location)
                {
                    if (!match.IsMatch(candidate.HomeTown, condition.Input))
                    {
                        return false;
                    }
                    continue;
                }
                if(rule == Rule.University)
                {
                    if (!match.IsMatch(candidate.University, condition.Input))
                    {
                        return false;
                    }
                    continue;
                }
            }

            return true;
        }
    }
}

