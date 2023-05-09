using System;
using FlowApp.Abstracts;

namespace FlowApp.Concrete
{
    public class IsOperate : IMatch
    {
        public bool IsMatch(string userData, string input)
        {
            return userData.Equals(input);
        }
    }
}

