using REPR_Pattern.Interfaces;
using REPR_Pattern.Models;

namespace REPR_Pattern.Factories
{
    public static class ResponseFactory
    {
        public static IResponse Success() => Response.Success;
        public static IResponse<T> Success<T>(T data) => new Response<T>(data);

        public static IResponse Failed(IError error) => new Response(error);
        public static IResponse<T> Failed<T>(IError error) => new Response<T>(error);

        public static IResponse NotFound(string message) => new Response(Error.NotFound(message));
        public static IResponse<T> NotFound<T>(string message) => new Response<T>(Error.NotFound(message));

        public static IResponse ServerError(string message) => new Response(Error.ServerError(message));
        public static IResponse<T> ServerError<T>(string message) => new Response<T>(Error.ServerError(message));

        public static IResponse InvalidData(string message) => new Response(Error.InvalidData(message));
        public static IResponse<T> InvalidData<T>(string message) => new Response<T>(Error.InvalidData(message));
    }
}
