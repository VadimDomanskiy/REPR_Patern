using REPR_Pattern.Interfaces;

namespace REPR_Pattern.Exceptions
{
    public class InvalidDataException : BaseException
    {
        public InvalidDataException(IError error) : base(error)
        {
        }

        public static void Throw(IError error) => throw new InvalidDataException(error);
    }
}
