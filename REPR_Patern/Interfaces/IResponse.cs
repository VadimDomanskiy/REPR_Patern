using static System.Runtime.InteropServices.JavaScript.JSType;

namespace REPR_Pattern.Interfaces
{
    public interface IResponse
    {
        bool IsSuccess { get; }
        IError Error { get; }
    }

    public interface IResponse<T> : IResponse
    {
        T Data { get; }
    }
}
