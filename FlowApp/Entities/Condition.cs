using System;
using System.ComponentModel.DataAnnotations;

namespace FlowApp.Entities
{
	public class Condition
	{
		[Key]
		public int Id { get; set; }
		public string Operate { get; set; }
		public string TargetRule { get; set; }
		public string OperateMatch { get; set; }
		public string Input { get; set; }
		public int QuestionId { get; set; }
	}
}

