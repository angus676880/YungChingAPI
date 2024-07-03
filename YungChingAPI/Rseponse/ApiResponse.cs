namespace YungChingAPI.Rseponse
{
    public class ApiResponse<T>
    {
        public string Code { get; set; }
        public T Result { get; set; }

        public ApiResponse(string code, T result)
        {
            Code = code;
            Result = result;
        }
    }

}
