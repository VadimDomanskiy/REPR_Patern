using REPR_Pattern.Enums;
using REPR_Pattern.Interfaces;

namespace REPR_Pattern.Models
{
    public class Error : IError
    {
        public string Type { get; set; }

        public string Message { get; set; }

        public Error(ErrorType type, string message)
        {
            Type = type.ToString();
            Message = message;
        }

        public static Error ServerError(string message)
            => new Error(ErrorType.InternalServerError, message);

        public static Error NotFound(string message)
            => new Error(ErrorType.NotFound, message);

        public static Error InvalidData(string message)
            => new Error(ErrorType.InvalidData, message);
    }
}
