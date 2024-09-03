using REPR_Pattern.Interfaces;

namespace REPR_Pattern.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(IError error) : base(error)
        {
        }

        public static void Throw(IError error) => throw new NotFoundException(error);
    }
}
