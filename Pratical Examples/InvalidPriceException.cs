using System;
using System.Runtime.Serialization;

internal class InvalidPriceException : Exception
{
    public InvalidPriceException()
    {
    }

    public InvalidPriceException(string message) : base(message)
    {
    }
}