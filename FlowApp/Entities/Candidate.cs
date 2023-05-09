using System;
using System.ComponentModel.DataAnnotations;

namespace FlowApp.Entities
{
	public class Candidate
	{
		[Key]
		public int Id { get; set; }
		public int Age { get; set; }
		public string HomeTown { get; set; }
		public string University { get; set; }
		public string ConditionResult { get; set; }
	}
}

