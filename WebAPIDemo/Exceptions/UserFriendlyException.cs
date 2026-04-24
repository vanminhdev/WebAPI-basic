using System;

namespace WebAPIDemo.Exceptions;

public class UserFriendlyException : Exception
{
    public UserFriendlyException(string message) : base(message)
    {
    }
}
