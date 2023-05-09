using System;
using System.ComponentModel.DataAnnotations;

namespace FlowApp.Models.ApiModels
{
	public class ConditionModel
	{
		[Required]
		public string OperateCode { get; set; }

        [Required]
        public string TargetRuleCode { get; set; }

        [Required]
        public string OperateMatchCode { get; set; }

        [Required]
        public string Input { get; set; }

        [Required]
        public int QuestionId { get; set; }
	}
}

