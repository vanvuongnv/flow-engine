using System;
using FlowApp.Concrete;
using FlowApp.Entities;
using FlowApp.Models;

namespace FlowApp.Abstracts
{
	public interface IMatch
    {		
		bool IsMatch(string userData, string input);
	}

	public static class MatchFactory
	{
		public static IMatch? Create(string matchCode)
		{
			if(matchCode == Match.Is.Code)
			{
				return new IsOperate();
			}
			if(matchCode == Match.IsGreaterThan.Code)
			{
				return new IsGreaterThan();
			}

			return null;
		}
	}
}

