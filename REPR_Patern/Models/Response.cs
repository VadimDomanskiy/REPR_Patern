using REPR_Pattern.Interfaces;

namespace REPR_Pattern.Models
{
    public class Response<T> : Response, IResponse<T>
    {
        public T Data { get; set; }

        public Response(IError error)
           : base(error)
        {
        }

        public Response(T data)
            : base()
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            Data = data;
        }
    }

    public class Response : IResponse
    {
        public static readonly Response Success = new Response();

        public static readonly Task<Response> Task = System.Threading.Tasks.Task.FromResult(Success);

        public bool IsSuccess { get; private set; }

        public IError Error { get; private set; }

        public Response()
        {
            IsSuccess = true;
        }

        public Response(IError error)
        {
            IsSuccess = false;
            Error = error;
        }
    }
}
