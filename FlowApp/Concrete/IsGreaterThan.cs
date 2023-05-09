using System;
using FlowApp.Abstracts;
using FlowApp.Models;

namespace FlowApp.Concrete
{
    public class IsGreaterThan : IMatch
    {
        public bool IsMatch(string userData, string input)
        {
            int userDataInNumber = Convert.ToInt32(userData);
            int inputInNumber = Convert.ToInt32(input);

            return userDataInNumber > inputInNumber;
        }
    }
}

