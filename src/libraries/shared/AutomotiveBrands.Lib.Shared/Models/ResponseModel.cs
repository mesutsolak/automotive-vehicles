namespace AutomotiveBrands.Lib.Response.Models
{
    public class ResponseModel<T>
    {
        public bool Succeeded { get; init; }
        public T Data { get; set; }
        public List<string> Errors { get; init; }

        public static ResponseModel<T> Success(T data)
        {
            return new ResponseModel<T> { Data = data, Succeeded = true };
        }

        public static ResponseModel<T> Fail(params string[] errors)
        {
            return new ResponseModel<T>
            {
                Errors = errors.ToList(),
                Succeeded = false
            };
        }
    }
}
