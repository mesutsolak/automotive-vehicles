namespace AutomotiveBrands.Lib.Response.Models
{
    public class ResponseModel<T>
    {
        public bool Succeeded { get; set; } = true;
        public T Data { get; init; }
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
