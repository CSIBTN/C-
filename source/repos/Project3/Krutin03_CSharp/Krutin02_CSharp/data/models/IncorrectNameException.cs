using System;

namespace Krutin02_CSharp.viewmodels.models
{
    public class IncorrectNameException : Exception
    {
        public IncorrectNameException(string message) : base(message)
    }
}