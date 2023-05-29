namespace BY.Toolkit.Responses.Service
{
    public class SuccessServiceResponse<T> : ServiceResponse<T>
    {
        public SuccessServiceResponse(T data, IList<string> message) : base(data, true, message) { }

        public SuccessServiceResponse(T data) : base(data, true) { }

        public SuccessServiceResponse(IList<string> message) : base(default, true, message) { }

        public SuccessServiceResponse() : base(default, true) { }
    }
}
