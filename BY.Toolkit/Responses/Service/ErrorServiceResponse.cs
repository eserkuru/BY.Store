namespace BY.Toolkit.Responses.Service
{
    public class ErrorServiceResponse<T> : ServiceResponse<T>
    {
        public ErrorServiceResponse(T data, IList<string> message) : base(data, false, message) { }

        public ErrorServiceResponse(T data) : base(data, false) { }

        public ErrorServiceResponse(IList<string> message) : base(default, false, message) { }

        public ErrorServiceResponse() : base(default, false) { }
    }
}
