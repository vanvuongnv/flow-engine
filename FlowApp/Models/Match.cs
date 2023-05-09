using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowApp.Models
{
	public class Match : BaseEnum
    {
		protected Match() { }
		public Match(string code, string name) : base(code, name)
		{
		}

		public static Match Is = new Match("==","Is");
		public static Match IsGreaterThan = new Match(">", "Is greater than");
		public static Match IsGreaterThanOrEqualTo = new Match(">=", "Is greater than or equal to");
		public static Match IsLessThan = new Match("<", "Is less than");
        public static Match IsLessThanOrEqualTo = new Match("<=", "Is less than or equal to");
        public static Match IsNotEqualTo = new Match("!=", "Is not equal to");

		public static List<Match> Matches = new List<Match>()
		{
			Is,
			IsGreaterThan,
			IsGreaterThanOrEqualTo,
			IsLessThan,
			IsLessThanOrEqualTo,
			IsNotEqualTo
		};

        public override bool IsValidCode(string code)
        {
			var item = Matches.FirstOrDefault(x => x.Code == code);
			return item is not null;
        }

        public static bool IsValid(string code)
        {
            return new Match().IsValidCode(code);
        }
    }
}

