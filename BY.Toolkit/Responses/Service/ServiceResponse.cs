namespace BY.Toolkit.Responses.Service
{
    public class ServiceResponse<T> : IServiceResponse<T>
    {
        public ServiceResponse(T data, bool isSuccess, IList<string> message) : this(isSuccess, message) => Data = data;
        public ServiceResponse(T data, bool isSuccess) : this(isSuccess) => Data = data;
        public ServiceResponse(bool isSuccess, IList<string> messages) : this(isSuccess) => Messages = messages;
        public ServiceResponse(bool isSuccess) => IsSuccess = isSuccess;
        public bool IsSuccess { get; set; }
        public IList<string> Messages { get; set; }
        public T Data { get; set; }
    }
}
