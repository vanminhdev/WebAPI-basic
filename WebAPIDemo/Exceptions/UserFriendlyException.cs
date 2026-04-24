using System;

namespace WebAPIDemo.Exceptions;

public class UserFriendlyException : Exception
{
    public ErrorCodes ErrorCode { get; set; }

    public UserFriendlyException(ErrorCodes errorCode, string message) : base(message)
    {
        ErrorCode = errorCode;
    }
}
