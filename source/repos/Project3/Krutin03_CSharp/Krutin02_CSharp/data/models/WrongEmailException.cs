using System;

namespace Krutin02_CSharp.viewmodels.models
{
    public class WrongEmailException : Exception
    {
        public WrongEmailException(string message) : base(message)
    }
}