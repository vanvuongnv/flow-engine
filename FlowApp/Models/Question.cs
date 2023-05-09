using System;
using System.Collections.Generic;

namespace FlowApp.Models
{
	public class Question
	{
		public int QuestionId { get; set; }
		public string QuestionContent { get; set; }

		public static List<Question> Items = new List<Question>()
		{
			new Question(){QuestionId = 1, QuestionContent = "Age?" },
            new Question(){QuestionId = 2, QuestionContent = "Hometown?" },
            new Question(){QuestionId = 3, QuestionContent = "Which university they graduated from?" },
        };
	}
}

