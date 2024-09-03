using REPR_Pattern.Enums;

namespace REPR_Pattern.Interfaces
{
    public interface IError
    {
        string Type { get; }

        string Message { get; }
    }
}
