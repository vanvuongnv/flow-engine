using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowApp.Models
{
	public class Rule : BaseEnum
    {
        protected Rule() { }
        public Rule(string code, string name) : base(code, name)
        {
        }

        public static Rule Age = new Rule("AGE","Age");
		public static Rule Location = new Rule("LOCATION", "Location");
		public static Rule University = new Rule("UNIVERSITY", "University");

		public static List<Rule> Rules = new List<Rule>() { Age, Location, University };

        public override bool IsValidCode(string code)
        {
            var item = Rules.FirstOrDefault(x => x.Code == code);
            return item is not null;
        }

        public static bool IsValid(string code)
        {
            return new Rule().IsValidCode(code);
        }

        public static Rule GetRule(string code)
        {
            return Rules.FirstOrDefault(x => x.Code == code)!;
        }

    }
}

