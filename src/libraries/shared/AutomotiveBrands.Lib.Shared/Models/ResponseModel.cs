namespace AutomotiveBrands.Lib.Response.Models
{
    public class ResponseModel<T>
    {
        public bool Succeeded { get; set; }
        public T Data { get; init; }
        public int StatusCode { get; init; }
        public string StatusMessage { get; set; }
        public List<string> Errors { get; init; }

        public static ResponseModel<T> Success(int statusCode)
        {
            return new ResponseModel<T> { Data = default, StatusCode = statusCode, Succeeded = true };
        }

        public static ResponseModel<T> Success(T data)
        {
            return new ResponseModel<T> { Data = data, StatusCode = 9001, Succeeded = true };
        }

        public static ResponseModel<T> Success(T data, int statusCode)
        {
            return new ResponseModel<T> { Data = data, StatusCode = statusCode, Succeeded = true };
        }

        public static ResponseModel<T> Success(T data, int statusCode, string statusMessage)
        {
            return new ResponseModel<T> { Data = data, StatusCode = statusCode, Succeeded = true, StatusMessage = statusMessage };
        }

        public static ResponseModel<T> Fail(int statusCode)
        {
            return new ResponseModel<T>
            {
                Errors = default,
                StatusCode = statusCode,
                Succeeded = false
            };
        }

        public static ResponseModel<T> Fail(string error, int statusCode)
        {
            return new ResponseModel<T>
            {
                Errors = new List<string>() { error },
                StatusCode = statusCode,
                Succeeded = false
            };
        }

        public static ResponseModel<T> Fail(List<string> errors, int statusCode)
        {
            return new ResponseModel<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                Succeeded = false
            };
        }
    }
}
