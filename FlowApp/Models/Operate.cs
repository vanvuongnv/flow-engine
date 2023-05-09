using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowApp.Models
{
	public class Operate : BaseEnum
    {
        protected Operate() { }

        public Operate(string code, string name) : base(code, name)
        {
        }

        public static Operate If = new Operate("IF","If");
		public static Operate And = new Operate("AND","And");
		public static Operate Or = new Operate("OR","Or");

		public static List<Operate> Operates = new List<Operate>() { If, And, Or };

        public override bool IsValidCode(string code)
        {
            var item = Operates.FirstOrDefault(x => x.Code == code);
            return item is not null;
        }

        public static bool IsValid(string code)
        {
            return new Operate().IsValidCode(code);
        }
    }
}

