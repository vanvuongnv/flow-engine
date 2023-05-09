using System;
using FlowApp.Entities;

namespace FlowApp.Abstracts
{
	public interface IFlowEngine
	{
		bool Run(int questionId, Candidate candidate);
	}
}

