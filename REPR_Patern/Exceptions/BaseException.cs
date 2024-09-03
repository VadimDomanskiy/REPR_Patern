using REPR_Pattern.Enums;
using REPR_Pattern.Interfaces;
using REPR_Pattern.Models;

namespace REPR_Pattern.Exceptions
{
    public abstract class BaseException : Exception
    {
        public IError Error { get; }

        public BaseException(IError error)
        {
            Error = error;
        }

        public BaseException(ErrorType type, string message)
        {
            Error = new Error(type, message);
        }
    }
}
