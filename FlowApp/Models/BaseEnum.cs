using System;
namespace FlowApp.Models
{
	public abstract class BaseEnum
	{
        public string Code { get; set; }
        public string Name { get; set; }

		protected BaseEnum() { }
        public BaseEnum(string code, string name)
		{
			Code = code;
			Name = name;
		}

		public abstract bool IsValidCode(string code);
	}
}

