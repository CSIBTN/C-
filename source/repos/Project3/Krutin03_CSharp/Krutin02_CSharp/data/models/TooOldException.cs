using System;

namespace Krutin02_CSharp.viewmodels.models
{
    public class TooOldException : Exception
    {
       public TooOldException(string message) : base(message)
    }
}