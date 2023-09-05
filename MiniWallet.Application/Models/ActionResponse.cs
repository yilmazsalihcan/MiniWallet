using System.Text.Json.Serialization;

namespace MiniWallet.Application.Models
{
    public class ActionResponse<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public ResponseType ResponseType { get; set; }
        public static ActionResponse<T> Success(T data, int statusCode)
        {
            return new ActionResponse<T> { Data = data, StatusCode = statusCode, IsSuccessful = true, ResponseType = ResponseType.Ok };
        }
        public static ActionResponse<T> Success(string statusMessage, int statusCode)
        {
            return new ActionResponse<T> { Data = default, StatusCode = statusCode, IsSuccessful = true, ResponseType = ResponseType.Ok, Message = statusMessage };
        }
        public static ActionResponse<T> Fail(List<string> errors, int statusCode)
        {
            return new ActionResponse<T> { Errors = errors, Data = default, StatusCode = statusCode, IsSuccessful = false };
        }
        public static ActionResponse<T> Fail(string statusMessage, int statusCode)
        {

            return new ActionResponse<T> { Errors = new List<string> { statusMessage }, Data = default, StatusCode = statusCode, IsSuccessful = false, ResponseType = ResponseType.Error, Message = statusMessage };
        }

       
    }

    public enum ResponseType
    {
        Ok = 1,
        Warning = 2,
        Error = 3,
        updatedFromMembershipRegister = 4,
        ConcurrencyException = 5
    }
}
